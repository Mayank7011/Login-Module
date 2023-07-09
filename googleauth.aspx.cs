using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
public partial class _Default : System.Web.UI.Page
{
     
    string clientid = "1066288860272-7hsrrs5fuc0ppkur6rf37vjkeh2cq35p.apps.googleusercontent.com";
    string clientsecret = "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";
    string redirection_url = "http://localhost:15066/googleauth.aspx";
    string url = "https://accounts.google.com/o/oauth2/token";
    public class Tokenclass
    {
        public string access_token
        {
            get;
            set;
        }
        public string token_type
        {
            get;
            set;
        }
        public int expires_in
        {
            get;
            set;
        }
        public string refresh_token
        {
            get;
            set;
        }
    }
    public class Userclass
    {
        public string id
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public string given_name
        {
            get;
            set;
        }
        public string family_name
        {
            get;
            set;
        }
        public string link
        {
            get;
            set;
        }
        public string picture
        {
            get;
            set;
        }
        public string gender
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["code"] != null)
            {

                GetToken(Request.QueryString["code"].ToString());
                Response.Redirect("~/home.aspx");
            }
        }

    }
    public void GetToken(string code)
    {
        string poststring = "grant_type=authorization_code&code=" + code + "&client_id=" + clientid + "&client_secret=" + clientsecret + "&redirect_uri=" + redirection_url + "";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        UTF8Encoding utfenc = new UTF8Encoding();
        byte[] bytes = utfenc.GetBytes(poststring);
        Stream outputstream = null;
        try
        {
            request.ContentLength = bytes.Length;
            outputstream = request.GetRequestStream();
            outputstream.Write(bytes, 0, bytes.Length);
        }
        catch { }
        var response = (HttpWebResponse)request.GetResponse();
        var streamReader = new StreamReader(response.GetResponseStream());
        string responseFromServer = streamReader.ReadToEnd();
        JavaScriptSerializer js = new JavaScriptSerializer();
        Tokenclass obj = js.Deserialize<Tokenclass>(responseFromServer);
        GetuserProfile(obj.access_token);
    }
    public void GetuserProfile(string accesstoken)
    {
        string url = "https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=" + accesstoken + "";
        WebRequest request = WebRequest.Create(url);
        request.Credentials = CredentialCache.DefaultCredentials;
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        reader.Close();
        response.Close();
        JavaScriptSerializer js = new JavaScriptSerializer();
        Userclass userinfo = js.Deserialize<Userclass>(responseFromServer);
        Session["username"] = userinfo.name;
        string image = userinfo.picture.ToString();
        Session["dp"] = image;
    }
}