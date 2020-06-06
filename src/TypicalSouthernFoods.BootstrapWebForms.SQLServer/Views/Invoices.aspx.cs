using DevExpress.Web.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TypicalSouthernFoods.Webforms.Views
{
    public partial class Invoices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ASPxGridViewDetail_BeforePerformDataSelect(object sender, EventArgs e)
        {

            EDDetail.WhereParameters[0].DefaultValue= (sender as BootstrapGridView).GetMasterRowKeyValue().ToString();


        }

        protected void EDDetail_Inserting(object sender, Microsoft.AspNet.EntityDataSource.EntityDataSourceChangingEventArgs e)
        {

            

        }

        protected void ASPxGridViewDetail_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {            
            
        }

        protected void ASPxGridViewDetail_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            e.NewValues["ID_INVOICE"] = (sender as BootstrapGridView).GetMasterRowKeyValue().ToString(); 
        }
    }
}