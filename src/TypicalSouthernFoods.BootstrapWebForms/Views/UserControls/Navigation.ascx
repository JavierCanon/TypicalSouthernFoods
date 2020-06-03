<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigation.ascx.cs" Inherits="TypicalSouthernFoods.Webforms.Views.UserControls.Navigation" %>

<dx:BootstrapTreeView runat="server">
    <CssClasses
        IconExpandNode="demo-icon demo-icon-col m-0"
        IconCollapseNode="demo-icon demo-icon-ex m-0"
        NodeList="demo-treeview-nodes m-0" Node="demo-treeview-node" Control="demo-treeview" />
    <Nodes>
        <dx:BootstrapTreeViewNode Text="Home" NavigateUrl="~/Default.aspx"></dx:BootstrapTreeViewNode>

        <dx:BootstrapTreeViewNode Text="Invoices" NavigateUrl="~/Views/Invoices.aspx"></dx:BootstrapTreeViewNode>
        <dx:BootstrapTreeViewNode Text="Queries" NavigateUrl="~/Default.aspx"></dx:BootstrapTreeViewNode>
        <dx:BootstrapTreeViewNode Text="Clients" NavigateUrl="~/Views/Clients.aspx"></dx:BootstrapTreeViewNode>

        <dx:BootstrapTreeViewNode Text="Others" Expanded="true">
            <Nodes>                
                <dx:BootstrapTreeViewNode Text="Daily Dashboard" NavigateUrl="~/Views/DashboardDaily.aspx"></dx:BootstrapTreeViewNode>
                <dx:BootstrapTreeViewNode Text="Tasks data table" NavigateUrl="~/Views/TasksDataTable.aspx"></dx:BootstrapTreeViewNode>
                <dx:BootstrapTreeViewNode Text="Event scheduling" NavigateUrl="~/Views/EventScheduling.aspx"></dx:BootstrapTreeViewNode>
            </Nodes>
        </dx:BootstrapTreeViewNode>

    </Nodes>
</dx:BootstrapTreeView>