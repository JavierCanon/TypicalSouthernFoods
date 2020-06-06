<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WidgetsContainer.ascx.cs" Inherits="TypicalSouthernFoods.Webforms.Views.UserControls.WidgetsContainer" %>

<div class="demo-tab-container card <%= CssClass %>">
    <div class="row">
        <asp:PlaceHolder runat="server" ID="WidgetsPlaceholder"></asp:PlaceHolder>
    </div>
    <div class="row demo-area-highlight">
        <div class="col-12">
            <dx:BootstrapTabControl runat="server" OnInit="TabControl_Init">
                <CssClasses Control="demo-widget-tab-control" />
            </dx:BootstrapTabControl>
        </div>
    </div>
</div>