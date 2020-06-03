using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypicalSouthernFoods.Webforms;

namespace TypicalSouthernFoods.Webforms.Views.UserControls
{

    public partial class Widget : System.Web.UI.UserControl, IWidget {

        public string CssClass { get; set; }
        public string ContentCssClass { get; set; }
        public string Title { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        PersistenceMode(PersistenceMode.InnerProperty), MergableProperty(false), AutoFormatDisable]
        public ControlCollection WidgetContent { get { return WidgetContentControl.Controls; } }

        protected int Index { get { return Parent.Controls.OfType<Widget>().ToList().IndexOf(this); } }
    }
}