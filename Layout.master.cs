using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Layout : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else 
        {
            string session= (string)Session["username"];
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            String myquery = "select * from userinfo where email='" + session + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = cn;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            

            if (ds.Tables[0].Rows.Count > 0)
            {
                Image1.ImageUrl = ds.Tables[0].Rows[0]["uimg"].ToString();
                Image2.ImageUrl = ds.Tables[0].Rows[0]["uimg"].ToString();
                Label1.Text = ds.Tables[0].Rows[0]["username"].ToString();
                Label2.Text = ds.Tables[0].Rows[0]["username"].ToString();

                cn.Close();
            }
            else
            {
                Image1.ImageUrl = (string)Session["dp"];
                Image2.ImageUrl = (string)Session["dp"];
                Label1.Text = (string)Session["username"];
                Label2.Text = (string)Session["username"];
                cn.Close();

            }
        }
        

    }

    protected void Sign_out(object sender, EventArgs e)
    {
        Session.Remove("username");
        Session.RemoveAll();
        Response.Redirect("login.aspx");
    }
}
