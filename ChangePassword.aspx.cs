using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPasswordResetLinkValid())
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Password Reset link has expired or is invalid";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!txtNewPassword.Text.Equals(txtConfirmNewPassword.Text))
        {
            lpsw.Visible = true;
            lpsw.ForeColor = System.Drawing.Color.Red;
            lpsw.Text = "Password does not match";
        }
        else
        {
            lpsw.Visible = false;
            if (ChangeUserPassword())
            {
                string message = "Password Changed Successfully!";
                string url = "login.aspx";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Password Reset link has expired or is invalid";
            }
        }
        
    }

    private bool ExecuteSP(string SPName, List<SqlParameter> SPParameters)
    {
        string CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand(SPName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter parameter in SPParameters)
            {
                cmd.Parameters.Add(parameter);
            }

            con.Open();
            return Convert.ToBoolean(cmd.ExecuteScalar());
        }
    }

    private bool IsPasswordResetLinkValid()
    {
        List<SqlParameter> paramList = new List<SqlParameter>()
    {
        new SqlParameter()
        {
            ParameterName = "@GUID",
            Value = Request.QueryString["uid"]
        }
    };

        return ExecuteSP("spIsPasswordResetLinkValid", paramList);
    }

    private bool ChangeUserPassword()
    {
        List<SqlParameter> paramList = new List<SqlParameter>()
    {
        new SqlParameter()
        {
            ParameterName = "@GUID",
            Value = Request.QueryString["uid"]
        },
        new SqlParameter()
        {
            ParameterName = "@Password",
            Value = Encrypt(txtNewPassword.Text)
        }
    };

        return ExecuteSP("spChangePassword", paramList);
    }


    private string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
}