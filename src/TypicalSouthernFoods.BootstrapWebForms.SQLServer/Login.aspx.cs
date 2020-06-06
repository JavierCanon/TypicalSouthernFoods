using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TypicalSouthernFoods.Webforms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ASPxButtonLogin_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid) return;

            if (FormsAuthentication.Authenticate(UsernameTextbox.Text, PasswordTextbox.Text)) {
                //FormsAuthentication.RedirectFromLoginPage(UsernameTextbox.Text, NotPublicCheckBox.Checked);
                Session["User.ID"] = "DemoUser1";
                Response.Redirect("~/Default.aspx", true);
            }
            else
                Msg.Text = "Login failed. Please check your user name and password and try again.";


        }
    }
}