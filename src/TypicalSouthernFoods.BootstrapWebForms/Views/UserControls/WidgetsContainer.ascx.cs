using DevExpress.Web.Bootstrap;
using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypicalSouthernFoods.Webforms;

namespace TypicalSouthernFoods.Webforms.Views.UserControls
{
    public partial class WidgetsContainer : System.Web.UI.UserControl {

        public string CssClass { get; set; }
        public string TabControlCssClass { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        PersistenceMode(PersistenceMode.InnerProperty), MergableProperty(false), AutoFormatDisable]
        public ControlCollection Widgets { get { return WidgetsPlaceholder.Controls; } }

        protected void TabControl_Init(object sender, EventArgs e) {
            var tabControl = (BootstrapTabControl)sender;
            var widgetsList = Widgets.OfType<IWidget>().ToList();
            for(int i = 0; i < widgetsList.Count; i++) {
                tabControl.Tabs.Add(widgetsList[i].Title, "Item" + (i + 1));
            }
            if(!string.IsNullOrEmpty(TabControlCssClass))
                tabControl.CssClasses.Control += " " + TabControlCssClass;
        }
    }
}