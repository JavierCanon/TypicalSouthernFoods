using System;
using System.Linq;

namespace TypicalSouthernFoods.Webforms.Views.Masters
{
    public partial class Site : System.Web.UI.MasterPage {



        protected void Page_Init(object sender, EventArgs e)
        {

            if (Session["User.ID"] == null) Response.Redirect("~/Login.aspx");

        }


    }
}