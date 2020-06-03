using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using TypicalSouthernFoods.Webforms;

namespace TypicalSouthernFoods.Webforms.Views {
    public partial class TasksDataTable : System.Web.UI.Page {
        protected void GridView_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e) {
            e.NewValues["Kind"] = 1;
            e.NewValues["Priority"] = 2;
            e.NewValues["Status"] = 1;
            e.NewValues["IsDraft"] = true;
            e.NewValues["IsArchived"] = false;
        }

        protected void GridView_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) {
            if(e.Parameters == "delete") {
                List<long> selectedIds = GridView.GetSelectedFieldValues("Id").ConvertAll(id => (long)id);
                DataProvider.DeleteIssues(selectedIds);
                GridView.DataBind();
            }
        }

        protected void GridView_DataBound(object sender, EventArgs e) {
            var filterItems = GridView.Toolbars.FindByName("filterToolbar").Items;
            foreach(BootstrapGridViewToolbarItem item in filterItems) {
                item.Checked = GridView.FilterExpression == item.Name;
            }
            UpdateSearchAndFilterItemsState();
        }

        protected void UpdateSearchAndFilterItemsState() {
            GridView.Toolbars.FindByName("mainToolbar").Items.FindByName("filter").Checked = !GridView.SettingsSearchPanel.Visible;
            GridView.Toolbars.FindByName("mainToolbar").Items.FindByName("search").Checked = GridView.SettingsSearchPanel.Visible;
        }

        protected void GridView_ToolbarItemClick(object sender, BootstrapGridViewToolbarItemClickEventArgs e) {
            if(e.Item.GroupName == "filter") {
                GridView.FilterExpression = e.Item.Name;
                e.Item.Checked = true;
            }
            else if(e.Item.GroupName == "second_bar_toggle") {
                GridView.SettingsSearchPanel.Visible = e.Item.Name == "search";
                GridView.Toolbars.FindByName("filterToolbar").Visible = !GridView.SettingsSearchPanel.Visible;
                e.Item.Checked = true;
                UpdateSearchAndFilterItemsState();
                e.Handled = true;
            }
        }
    }
}