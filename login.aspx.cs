using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Configuration;
 

public partial class _Default : System.Web.UI.Page
{

    
    protected void Page_Load(object sender, EventArgs e) 
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["userid"] != null)
                txtemail.Text = Request.Cookies["userid"].Value;
            if (Request.Cookies["pwd"] != null)
                txtpass.Attributes.Add("value", Request.Cookies["pwd"].Value);
            if (Request.Cookies["userid"] != null && Request.Cookies["pwd"] != null)
                chkRememberMe.Checked = true;
        }
    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {
 
        string clientid = "1066288860272-7hsrrs5fuc0ppkur6rf37vjkeh2cq35p.apps.googleusercontent.com";
        string clientsecret = "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";  
        string redirection_url = "http://localhost:15066/googleauth.aspx";
        string url = "https://accounts.google.com/o/oauth2/v2/auth?scope=profile&include_granted_scopes=true&redirect_uri=" + redirection_url + "&response_type=code&client_id=" + clientid + "";
        Response.Redirect(url);
        
    

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        String myquery = "select * from userinfo where email='" + txtemail.Text + "'";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = myquery;
        cmd.Connection = cn;
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);
        String email;
        String pass;

        if (ds.Tables[0].Rows.Count > 0)
        {
            email = ds.Tables[0].Rows[0]["email"].ToString();
            pass = ds.Tables[0].Rows[0]["password"].ToString();
            cn.Close();
            Decrypt(pass);
            if (email == txtemail.Text && Decrypt(pass) == txtpass.Text)
            {
                Session["username"] = email;
                if (chkRememberMe.Checked == true)
                {
                    Response.Cookies["userid"].Value = txtemail.Text;
                    Response.Cookies["pwd"].Value = txtpass.Text;
                    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);
                    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(15);
                }
                else
                {
                    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(-1);
                }
                Response.Redirect("home.aspx");
                
            }
            else
            {
                Response.Write("<script>alert('invalid username and password')</script>");
            }

        }
        else
        {
            Response.Write("Error!");
        }
        if (chkRememberMe.Checked)
        {
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
        }
        else
        {
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

        }
        Response.Cookies["UserName"].Value = txtemail.Text.Trim();
        Response.Cookies["Password"].Value = txtpass.Text.Trim();


    }

    private string Decrypt(string cipherText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }

    
}