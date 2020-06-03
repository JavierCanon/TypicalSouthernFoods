<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/Site.master" AutoEventWireup="true" CodeBehind="DashboardDaily.aspx.cs" Inherits="TypicalSouthernFoods.Webforms.Views.DashboardDaily" %>

<%@ Register Src="~/Views/UserControls/Widget.ascx" TagPrefix="demo" TagName="Widget" %>
<%@ Register Src="~/Views/UserControls/WidgetsContainer.ascx" TagPrefix="demo" TagName="WidgetsContainer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/Content/dashboard.js" defer></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Statistics</p>
        </div>
        <div class="row mb-4">
            <div class="col-12">
                <dx:BootstrapCardView ID="CardViewControl" ClientInstanceName="CardViewControl" runat="server"
                    OnCustomCallback="CardViewControl_CustomCallback" DataSourceID="DashboardCardsDataSource">
                    <CssClasses Control="shadow rounded demo-card-view demo-widget-area"
                        Content="bg-primary text-white border-0"
                        Card="bg-primary demo-card-view-item" PanelBodyBottom="bg-primary text-white" />
                    <CssClassesPager PageNumber="text-white" />
                    <SettingsPager ItemsPerPage="1" EnableAdaptivity="true">
                        <Summary Position="Right" />
                        <NextPageButton IconCssClass="demo-icon demo-icon-right" Text="" />
                        <PrevPageButton IconCssClass="demo-icon demo-icon-left" Text="" />
                    </SettingsPager>
                    <SettingsLayout CardColSpanXs="12" CardColSpanSm="12" CardColSpanMd="6" CardColSpanLg="4" CardColSpanXl="3" />
                    <Templates>
                        <Card>
                            <div class="d-flex">
                                <div class="p-2 mr-1">
                                    <span class="<%# Eval("IconName") %>"></span>
                                </div>
                                <div>
                                    <div class="text-nowrap" style="font-size: 2rem;">
                                        <span><%# Eval("Title") %>:</span>
                                        <span class="font-weight-bold ml-2"><%# Eval("ValueString") %></span>
                                    </div>
                                    <div class="font-weight-light">
                                        <p><%# Eval("Summary") %></p>
                                        <div style="font-size: 0.8rem;"><%# Eval("Category") %></div>
                                    </div>
                                </div>
                            </div>
                        </Card>
                    </Templates>
                </dx:BootstrapCardView>
            </div>
        </div>
        <demo:WidgetsContainer runat="server" CssClass="demo-row-calendar mb-4" TabControlCssClass="rotated-180 border-top">
            <Widgets>
                <demo:Widget runat="server" CssClass="col-md-auto" Title="Calendar">
                    <WidgetContent>
                        <dx:BootstrapSchedulerDateNavigator ID="BootstrapSchedulerDateNavigator1" runat="server"
                            MasterControlID="BootstrapScheduler1">
                            <CssClasses Calendar="demo-calendar rounded-0 border-0" Control="flex-fill"
                                DayWeekEnd="demo-calendar-weekend" DaySelected="demo-calendar-selected" Today="demo-calendar-today"
                                DayHeader="demo-calendar-day-header" Header="border-bottom" />
                            <Properties AppointmentDatesHighlightMode="None" ShowTodayButton="false" EnableLargePeriodNavigation="false" ShowWeekNumbers="false">
                            </Properties>
                        </dx:BootstrapSchedulerDateNavigator>
                    </WidgetContent>
                </demo:Widget>
                <demo:Widget runat="server" Title="Agenda View">
                    <WidgetContent>
                        <dx:BootstrapScheduler ID="BootstrapScheduler1" OnInit="BootstrapScheduler1_Init" runat="server" ActiveViewType="Agenda" Width="100%"
                            AppointmentDataSourceID="AppointmentDataSource" ResourceDataSourceID="ResourcesDataSource">
                            <OptionsAdaptivity Enabled="true" />
                            <CssClasses Control="h-100 rounded-0 border-0" />
                            <CssClassesViewNavigator IconCalendar="demo-icon demo-icon-today" />
                            <CssClassesViewSelector Button="demo-btn-custom-state active-underline" />
                            <OptionsAppearance ToolbarRenderMode="Header"></OptionsAppearance>
                            <Storage EnableReminders="False">
                                <Appointments AutoRetrieveId="true">
                                    <Mappings AppointmentId="Id" Type="EventType" Start="StartDate" End="EndDate" AllDay="AllDay"
                                        Subject="Subject" Location="Location" Description="Description" Label="LabelId" Status="Status"
                                        RecurrenceInfo="RecurrenceInfo" ResourceId="ResourceId" />
                                </Appointments>
                                <Resources>
                                    <Mappings ResourceId="Id" Caption="Name" />
                                </Resources>
                            </Storage>
                            <Views>
                                <AgendaView DayCount="3" AllowFixedDayHeaders="false" ScrollAreaHeight="240"></AgendaView>
                                <DayView ScrollAreaHeight="180">
                                    <VisibleTime Start="7:00" End="22:00" />
                                </DayView>
                                <WorkWeekView ScrollAreaHeight="180"></WorkWeekView>
                                <MonthView Enabled="false" />
                                <TimelineView ScrollAreaHeight="148" />
                                <WeekView Enabled="false" />
                                <FullWeekView ScrollAreaHeight="180" />
                            </Views>
                        </dx:BootstrapScheduler>
                    </WidgetContent>
                </demo:Widget>
            </Widgets>
        </demo:WidgetsContainer>
        <demo:WidgetsContainer runat="server" CssClass="demo-row-filtering mb-4" TabControlCssClass="rotated-180 border-top">
            <Widgets>
                <demo:Widget runat="server" CssClass="col-lg-6" Title="Chart">
                    <WidgetContent>
                        <div class="card-header">Daily sales performance</div>
                        <dx:BootstrapChart runat="server" DataSourceUrl="~/ChartData.json" Width="100%" Height="385px">
                            <CssClasses Control="card-body pb-0" />
                            <SettingsCommonAxis>
                                <Label OverlappingBehavior="Rotate" RotationAngle="45"></Label>
                            </SettingsCommonAxis>
                            <SettingsCommonSeries>
                                <Label Visible="true"></Label>
                            </SettingsCommonSeries>
                            <ValueAxisCollection>
                                <dx:BootstrapChartValueAxis MaxValueMargin="0.05"></dx:BootstrapChartValueAxis>
                            </ValueAxisCollection>
                            <SeriesCollection>
                                <dx:BootstrapChartBarSeries Name="Income" ValueField="income" ArgumentField="date" Color="#c1c1c1"></dx:BootstrapChartBarSeries>
                                <dx:BootstrapChartBarSeries Name="Outcome" ValueField="outcome" ArgumentField="date" Color="#9a1de1"></dx:BootstrapChartBarSeries>
                            </SeriesCollection>
                            <SettingsLegend Orientation="Horizontal" ItemTextPosition="Right" HorizontalAlignment="Left" VerticalAlignment="Bottom" HoverMode="IncludePoints" />
                        </dx:BootstrapChart>
                    </WidgetContent>
                </demo:Widget>
                <demo:Widget runat="server" CssClass="col-lg-6" Title="Filtering">
                    <WidgetContent>
                        <dx:BootstrapGridView runat="server" ID="IssuesGridView" DataSourceID="IssuesDataSource">
                            <Settings ShowHeaderFilterButton="true" GridLines="Horizontal" />
                            <SettingsAdaptivity AdaptivityMode="HideDataCells" />
                            <SettingsText Title="Filtering" />
                            <SettingsDataSecurity AllowDelete="true" AllowEdit="true" AllowInsert="true" />
                            <SettingsPager EnableAdaptivity="true">
                                <Summary Position="Right" />
                                <NextPageButton IconCssClass="demo-icon demo-icon-right" Text="" />
                                <PrevPageButton IconCssClass="demo-icon demo-icon-left" Text="" />
                            </SettingsPager>
                            <CssClasses Control="demo-gridview" HeaderRow="bg-light text-dark" Row="text-nowrap" Table="border-top-0" />
                            <Columns>
                                <dx:BootstrapGridViewCommandColumn ShowSelectCheckbox="True" ShowClearFilterButton="true" SelectAllCheckboxMode="Page" />
                                <dx:BootstrapGridViewDataColumn AllowTextTruncationInAdaptiveMode="true" FieldName="Subject" />
                                <dx:BootstrapGridViewDataColumn FieldName="Customer.FullName" />
                                <dx:BootstrapGridViewDataColumn FieldName="Customer.Email" />
                                <dx:BootstrapGridViewDataColumn FieldName="Created" />
                            </Columns>
                            <Toolbars>
                                <dx:BootstrapGridViewToolbar ShowInsidePanel="true">
                                    <SettingsAdaptivity EnableCollapseRootItemsToIcons="true" Enabled="true" />
                                    <Items>
                                        <dx:BootstrapGridViewToolbarItem Command="New">
                                        </dx:BootstrapGridViewToolbarItem>
                                        <dx:BootstrapGridViewToolbarItem Command="Edit">
                                        </dx:BootstrapGridViewToolbarItem>
                                        <dx:BootstrapGridViewToolbarItem Command="Delete">
                                        </dx:BootstrapGridViewToolbarItem>
                                        <dx:BootstrapGridViewToolbarItem Text="Export" IconCssClass="demo-icon demo-icon-export">
                                            <Items>
                                                <dx:BootstrapGridViewToolbarMenuItem Command="ExportToCsv"></dx:BootstrapGridViewToolbarMenuItem>
                                            </Items>
                                        </dx:BootstrapGridViewToolbarItem>
                                        <dx:BootstrapGridViewToolbarItem Command="ShowCustomizationDialog">
                                        </dx:BootstrapGridViewToolbarItem>
                                    </Items>
                                </dx:BootstrapGridViewToolbar>
                            </Toolbars>
                        </dx:BootstrapGridView>
                    </WidgetContent>
                </demo:Widget>
            </Widgets>
        </demo:WidgetsContainer>
    </div>

    <asp:ObjectDataSource ID="DashboardCardsDataSource" runat="server"
        DataObjectTypeName="TypicalSouthernFoods.Webforms.DashboardCard"
        TypeName="TypicalSouthernFoods.Webforms.DataProvider"
        SelectMethod="GetDashboardCards"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="IssuesDataSource" runat="server"
        DataObjectTypeName="TypicalSouthernFoods.Webforms.Issue"
        TypeName="TypicalSouthernFoods.Webforms.DataProvider"
        SelectMethod="GetIssues"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="AppointmentDataSource" runat="server"
        DataObjectTypeName="TypicalSouthernFoods.Webforms.SchedulerAppointment"
        TypeName="TypicalSouthernFoods.Webforms.AppointmentDataSourceHelper"
        SelectMethod="SelectMethodHandler" DeleteMethod="DeleteMethodHandler" InsertMethod="InsertMethodHandler" UpdateMethod="UpdateMethodHandler"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ResourcesDataSource" runat="server"
        DataObjectTypeName="TypicalSouthernFoods.Webforms.SchedulerResource"
        TypeName="TypicalSouthernFoods.Webforms.ResourceDataSourceHelper"
        SelectMethod="GetItems"></asp:ObjectDataSource>


</asp:Content>
