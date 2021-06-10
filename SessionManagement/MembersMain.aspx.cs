using System;

namespace SessionManagement
{
    public partial class MembersMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string user = Request.QueryString["u"];
            string pass = Request.QueryString["p"];

            lblUser.Text = "Hello, " + user + "! Your password is " + pass;

        }
    }
}