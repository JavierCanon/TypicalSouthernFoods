using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.Bootstrap;

namespace TypicalSouthernFoods.Webforms.Views
{
    public partial class DashboardDaily : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CardViewControl_CustomCallback(object sender, DevExpress.Web.ASPxCardViewCustomCallbackEventArgs e)
        {
            int newPageSize = Int32.Parse(e.Parameters);
            CardViewControl.SettingsPager.ItemsPerPage = newPageSize;
            CardViewControl.DataBind();
        }

        protected void BootstrapScheduler1_Init(object sender, EventArgs e)
        {
            var scheduler = (BootstrapScheduler)sender;
            scheduler.Storage.Appointments.Labels.Clear();
            foreach (SchedulerLabel label in SchedulerLabelsHelper.GetItems())
                scheduler.Storage.Appointments.Labels.Add(label.Id, label.Name, label.BackgroundCssClass, label.TextCssClass);
        }

    }
}