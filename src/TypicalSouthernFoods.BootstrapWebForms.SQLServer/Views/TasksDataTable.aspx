<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Masters/Site.master" CodeBehind="TasksDataTable.aspx.cs" Inherits="TypicalSouthernFoods.Webforms.Views.TasksDataTable" %>


<%@ Register Src="~/Views/UserControls/Widget.ascx" TagPrefix="demo" TagName="Widget" %>
<%@ Register Src="~/Views/UserControls/WidgetsContainer.ascx" TagPrefix="demo" TagName="WidgetsContainer" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Tasks data table</p>
        </div>
        <div class="row">
            <div class="col-12">
                <dx:BootstrapGridView runat="server" ID="GridView" ClientInstanceName="gridView"
                    KeyFieldName="Id"
                    DataSourceID="GridViewDataSource"
                    OnCustomCallback="GridView_CustomCallback"
                    OnDataBound="GridView_DataBound"
                    OnToolbarItemClick="GridView_ToolbarItemClick"
                    OnInitNewRow="GridView_InitNewRow">
                    <ClientSideEvents ToolbarItemClick="function(s, e) { e.processOnServer = true; }" />
                    <Columns>
                        <dx:BootstrapGridViewCommandColumn Width="50px" ShowSelectCheckbox="True" SelectAllCheckboxMode="AllPages" VisibleIndex="0"></dx:BootstrapGridViewCommandColumn>

                        <dx:BootstrapGridViewHyperLinkColumn Width="200px" FieldName="Id" Caption="Subject" HorizontalAlign="Left">
                            <Settings FilterMode="DisplayText" SortMode="DisplayText" />
                            <PropertiesHyperLinkEdit NavigateUrlFormatString="#" TextField="Subject" />
                            <EditItemTemplate>
                                <dx:BootstrapTextBox runat="server" ID="SubjectTextBox"
                                    Value='<%# Bind("Subject") %>'
                                    ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>">
                                    <ValidationSettings>
                                        <RequiredField IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapTextBox>
                            </EditItemTemplate>
                        </dx:BootstrapGridViewHyperLinkColumn>
                        <dx:BootstrapGridViewComboBoxColumn FieldName="CustomerId" Visible="false">
                            <PropertiesComboBox ValueField="Id" TextField="FullName" ValueType="System.Int64" DataSourceID="ContactsDataSource">
                                <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                            </PropertiesComboBox>
                        </dx:BootstrapGridViewComboBoxColumn>
                        <dx:BootstrapGridViewDataColumn Width="150px" FieldName="Customer.FullName" Caption="Customer Name" />
                        <dx:BootstrapGridViewDataColumn AdaptivePriority="1" FieldName="Customer.Email" />
                        <dx:BootstrapGridViewMemoColumn FieldName="Notes" Visible="false">
                            <PropertiesMemoEdit Rows="3"></PropertiesMemoEdit>
                        </dx:BootstrapGridViewMemoColumn>
                        <dx:BootstrapGridViewComboBoxColumn Width="50px" FieldName="Kind">
                            <DataItemTemplate>
                                <%# Eval("Kind") %>
                            </DataItemTemplate>
                            <PropertiesComboBox>
                                <Items>
                                    <dx:BootstrapListEditItem Text="Bug" Value="1" />
                                    <dx:BootstrapListEditItem Text="Suggestion" Value="2" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:BootstrapGridViewComboBoxColumn>
                        <dx:BootstrapGridViewComboBoxColumn Width="50px" FieldName="Priority">
                            <DataItemTemplate>
                                <%# Eval("Priority") %>
                            </DataItemTemplate>
                            <PropertiesComboBox>
                                <Items>
                                    <dx:BootstrapListEditItem Text="High" Value="1" />
                                    <dx:BootstrapListEditItem Text="Medium" Value="2" />
                                    <dx:BootstrapListEditItem Text="Low" Value="3" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:BootstrapGridViewComboBoxColumn>
                        <dx:BootstrapGridViewComboBoxColumn Width="50px" FieldName="Status">
                            <DataItemTemplate>
                                <%# Eval("Status") %>
                            </DataItemTemplate>
                            <PropertiesComboBox>
                                <Items>
                                    <dx:BootstrapListEditItem Text="Active" Value="1" />
                                    <dx:BootstrapListEditItem Text="Closed" Value="2" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:BootstrapGridViewComboBoxColumn>
                        <dx:BootstrapGridViewDataColumn Width="50px" FieldName="Votes">
                            <DataItemTemplate>
                                <%# Eval("Votes") %>
                            </DataItemTemplate>
                        </dx:BootstrapGridViewDataColumn>
                        <dx:BootstrapGridViewDataColumn FieldName="Created" />
                        <dx:BootstrapGridViewDataColumn FieldName="Updated" />
                        <dx:BootstrapGridViewDataColumn FieldName="Unread" />
                        <dx:BootstrapGridViewDataColumn FieldName="IsDraft" />
                        <dx:BootstrapGridViewDataColumn FieldName="IsArchived" />
                    </Columns>
                    <SettingsAdaptivity AdaptivityMode="HideDataCells"></SettingsAdaptivity>
                    <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="true" AllowEllipsisInText="true" AllowDragDrop="false" />
                    <SettingsEditing Mode="PopupEditForm">
                        <FormLayoutProperties LayoutType="Vertical">
                            <Items>
                                <dx:BootstrapGridViewColumnLayoutItem ColumnName="Subject" Caption="Subject" />
                                <dx:BootstrapGridViewColumnLayoutItem ColumnName="CustomerId" Caption="Customer" />
                                <dx:BootstrapGridViewColumnLayoutItem ColumnName="Notes" />
                                <dx:BootstrapGridViewColumnLayoutItem ColumnName="IsDraft" />
                                <dx:BootstrapGridViewColumnLayoutItem ColumnName="IsArchived" />
                                <dx:BootstrapGridViewColumnLayoutItem ColumnName="Kind" />
                                <dx:BootstrapGridViewColumnLayoutItem ColumnName="Priority" />
                                <dx:BootstrapGridViewColumnLayoutItem ColumnName="Status" />
                                <dx:BootstrapEditModeCommandLayoutItem BeginRow="true"></dx:BootstrapEditModeCommandLayoutItem>
                            </Items>
                        </FormLayoutProperties>
                    </SettingsEditing>
                    <SettingsDataSecurity AllowDelete="true" AllowEdit="true" AllowInsert="true" />
                    <SettingsPager PageSize="15" EnableAdaptivity="true">
                        <PageSizeItemSettings Visible="true"></PageSizeItemSettings>
                    </SettingsPager>
                    <SettingsExport EnableClientSideExportAPI="true" ExportSelectedRowsOnly="true" />
                    <SettingsText Title="Tribe tickets" />
                    <CssClasses Table="border-top-0" />
                    <Toolbars>
                        <dx:BootstrapGridViewToolbar Name="mainToolbar" Position="Top" ShowInsidePanel="true">
                            <SettingsAdaptivity Enabled="true" EnableCollapseRootItemsToIcons="true" />
                            <Items>
                                <dx:BootstrapGridViewToolbarItem CssClass="demo-btn-custom-state active-highlight" Command="New"></dx:BootstrapGridViewToolbarItem>
                                <dx:BootstrapGridViewToolbarItem CssClass="demo-btn-custom-state active-highlight" Command="Edit"></dx:BootstrapGridViewToolbarItem>
                                <dx:BootstrapGridViewToolbarItem CssClass="demo-btn-custom-state active-highlight" Command="Delete">
                                    <SettingsBootstrap RenderOption="Danger" />
                                </dx:BootstrapGridViewToolbarItem>
                                <dx:BootstrapGridViewToolbarItem CssClass="demo-btn-custom-state active-highlight" Command="ExportToXlsx"></dx:BootstrapGridViewToolbarItem>
                                <dx:BootstrapGridViewToolbarItem CssClass="demo-btn-custom-state active-highlight" Command="ShowSearchPanel" GroupName="second_bar_toggle" Name="search"></dx:BootstrapGridViewToolbarItem>
                                <dx:BootstrapGridViewToolbarItem CssClass="demo-btn-custom-state active-highlight" Command="Refresh" Checked="true" GroupName="second_bar_toggle" Name="filter"
                                    Text="Show filter" IconCssClass="demo-icon demo-icon-filter">
                                </dx:BootstrapGridViewToolbarItem>
                            </Items>
                        </dx:BootstrapGridViewToolbar>
                        <dx:BootstrapGridViewToolbar Name="filterToolbar" Position="Top" ShowInsidePanel="true" CssClass="p-0">
                            <SettingsAdaptivity Enabled="true" EnableAutoHideRootItems="false" EnableCollapseRootItemsToIcons="true" />
                            <Items>
                                <dx:BootstrapGridViewToolbarItem CssClass="demo-btn-custom-state active-underline" GroupName="filter" Text="All" Checked="true" Name="" />
                                <dx:BootstrapGridViewToolbarItem CssClass="demo-btn-custom-state active-underline" GroupName="filter" Text="Active issues" Name="[Status] = 1" />
                                <dx:BootstrapGridViewToolbarItem CssClass="demo-btn-custom-state active-underline" GroupName="filter" Text="Bugs" Name="[Kind] = 1" />
                                <dx:BootstrapGridViewToolbarItem CssClass="demo-btn-custom-state active-underline" GroupName="filter" Text="Suggestions" Name="[Kind] = 2" />
                                <dx:BootstrapGridViewToolbarItem CssClass="demo-btn-custom-state active-underline" GroupName="filter" Text="High priority" Name="[Priority] = 1" />
                            </Items>
                        </dx:BootstrapGridViewToolbar>
                    </Toolbars>
                </dx:BootstrapGridView>

                <asp:ObjectDataSource ID="GridViewDataSource" runat="server"
                    DataObjectTypeName="TypicalSouthernFoods.Webforms.Issue"
                    TypeName="TypicalSouthernFoods.Webforms.DataProvider"
                    SelectMethod="GetIssues" InsertMethod="AddNewIssue" UpdateMethod="UpdateIssue"></asp:ObjectDataSource>

                <asp:ObjectDataSource ID="ContactsDataSource" runat="server"
                    DataObjectTypeName="TypicalSouthernFoods.Webforms.Contact"
                    TypeName="TypicalSouthernFoods.Webforms.DataProvider"
                    SelectMethod="GetContacts"></asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>