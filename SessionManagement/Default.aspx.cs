using System;

namespace SessionManagement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "bgates" && txtPassword.Text == "billions")
            {
                string user = txtUser.Text;
                string pass = txtPassword.Text;
                Response.Redirect("SecondPage.aspx?u=" + txtUser.Text + "&p=" + txtPassword.Text);
            }
            else if (txtUser.Text == "bradley" && txtPassword.Text == "kelly")
            {
                string user = txtUser.Text;
                string pass = txtPassword.Text;
                Response.Redirect("SecondPage.aspx?u=" + txtUser.Text + "&p=" + txtPassword.Text);
            }
            else
            {
                lblMessage.Text = "Account not recognized";
            }

        }
    }
}