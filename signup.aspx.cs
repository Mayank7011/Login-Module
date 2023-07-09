using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.IO;

public partial class up : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (chktrm.Checked == true)
        {
            Label3.Visible = false;
            lpsw.Visible = false;
            captcha1.ValidateCaptcha(captcha.Text.Trim());
            if (captcha1.UserValidated)
            {
                lcap.Visible = false;
                if (psw.Text.Equals(repsw.Text))
                {
                    lpsw.Visible = false;
                    if (pic.HasFile)
                    {
                        img_ckeck.Visible = true;
                        string fileimg = Path.GetFileName(pic.PostedFile.FileName);
                        pic.SaveAs(Server.MapPath("~/img/") + pic.FileName);
                        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        cn.Open();
                        SqlCommand cmd = new SqlCommand("insert into [dbo].[userinfo](username,password,phone,email,uimg) values(@username, @password, @phone,@email,@uimg)", cn);
                        cmd.Parameters.AddWithValue("@username", name.Text);
                        cmd.Parameters.AddWithValue("@password", Encrypt(psw.Text));
                        cmd.Parameters.AddWithValue("@phone", num.Text);
                        cmd.Parameters.AddWithValue("@email", email.Text);
                        cmd.Parameters.AddWithValue("@uimg", "~/img/" + fileimg);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        string message = "Registration completed successfully!";
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
                        img_ckeck.Visible = true;
                        img_ckeck.ForeColor = System.Drawing.Color.Red;
                        img_ckeck.Text = "Please upload your profile picture";
                    }
                }
                else
                {
                    lpsw.Visible = true;
                    lpsw.ForeColor = System.Drawing.Color.Red;
                    lpsw.Text = "Password does not match";
                }
            }
            else
            {
                lcap.Visible = true;
                lcap.ForeColor = System.Drawing.Color.Red;
                lcap.Text = "Enter Valid Captcha";
            }

        }
        else
        {
            Label3.Visible = true;
            Label3.ForeColor = System.Drawing.Color.Red;
            Label3.Text = "Please accept the terms";
        }
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