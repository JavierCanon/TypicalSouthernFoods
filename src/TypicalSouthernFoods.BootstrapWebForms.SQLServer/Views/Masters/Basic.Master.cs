﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TypicalSouthernFoods.Webforms.Views.Masters
{
    public partial class Basic : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Page.Header.Title))
                Page.Header.Title += " - ";
            Page.Header.Title = Page.Header.Title + " Typical Southern Foods ";

            Page.Header.DataBind();



        }
    }
}