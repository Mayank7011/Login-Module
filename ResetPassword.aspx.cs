using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        string CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spResetpsw", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramUserName = new SqlParameter("@UserName", txtUserName.Text);

            cmd.Parameters.Add(paramUserName);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (Convert.ToBoolean(rdr["ReturnCode"]))
                {
                    SendPasswordResetEmail(rdr["Email"].ToString(), txtUserName.Text, rdr["UniqueId"].ToString());
                    string message = "An email with instructions to reset your password is sent to your registered email";
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
                    lblMessage.Text = "Email not found!";
                }
            }
        }
    }

    private void SendPasswordResetEmail(string ToEmail, string UserName, string UniqueId)
    {
        MailMessage mailMessage = new MailMessage("mail.test8180@gmail.com", ToEmail);
        StringBuilder sbEmailBody = new StringBuilder();
        sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
        sbEmailBody.Append("Please click on the following link to reset your password");
        sbEmailBody.Append("<br/>"); sbEmailBody.Append("http://localhost:15066/ChangePassword.aspx?uid=" + UniqueId);
        sbEmailBody.Append("<br/><br/>");
      

        mailMessage.IsBodyHtml = true;

        mailMessage.Body = sbEmailBody.ToString();
        mailMessage.Subject = "Reset Your Password";
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

        smtpClient.Credentials = new System.Net.NetworkCredential()
        {
            UserName = "mail.test8180@gmail.com",
            Password = "wtgfymwednymlpqm"
        };

        smtpClient.EnableSsl = true;
        smtpClient.Send(mailMessage);
    }
}
    