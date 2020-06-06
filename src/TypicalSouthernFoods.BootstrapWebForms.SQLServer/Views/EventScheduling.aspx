<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Masters/Site.master" CodeBehind="EventScheduling.aspx.cs" Inherits="TypicalSouthernFoods.Webforms.Views.EventScheduling" %>


<%@ Register Src="~/Views/UserControls/Widget.ascx" TagPrefix="demo" TagName="Widget" %>
<%@ Register Src="~/Views/UserControls/WidgetsContainer.ascx" TagPrefix="demo" TagName="WidgetsContainer" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript" src="Content/event-scheduling.js" defer></script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <div class="container-fluid demo-scheduler-area pb-3">
        <div class="row">
            <p class="col-12 demo-content-title">Event scheduling</p>
        </div>
        <demo:WidgetsContainer runat="server" CssClass="demo-row-calendar" TabControlCssClass="border-bottom">
            <Widgets>
                <demo:Widget runat="server" Title="Calendar" CssClass="col-md-auto" ContentCssClass="overflow-auto">
                    <WidgetContent>
                        <div class="card-header">Selected dates:</div>
                        <dx:BootstrapSchedulerDateNavigator runat="server" ID="DateNavigator" MasterControlID="Scheduler" ClientInstanceName="dateNavigator"
                            Width="100%">
                            <CssClasses Calendar="demo-calendar rounded-0" Control="mb-3" Footer="d-none"
                                DayWeekEnd="demo-calendar-weekend" DaySelected="demo-calendar-selected" Today="demo-calendar-today"
                                DayHeader="demo-calendar-day-header" />
                            <Properties ShowTodayButton="true" EnableChangeVisibleDateGestures="True" AppointmentDatesHighlightMode="Labels"
                                EnableYearNavigation="false">
                            </Properties>
                        </dx:BootstrapSchedulerDateNavigator>
                        <div class="card-header bg-transparent border-top">Resources:</div>
                        <dx:BootstrapListBox runat="server" ID="ResourcesListBox" ClientInstanceName="resourcesListBox" 
                            SelectionMode="CheckColumn" Rows="8"
                            ValueType="System.Int64" TextField="Name" ValueField="Id">
                            <CssClasses Control="border-0 flex-shrink-0 demo-resources-list" />
                        </dx:BootstrapListBox>
                    </WidgetContent>
                </demo:Widget>
                <demo:Widget runat="server" Title="Scheduler">
                    <WidgetContent>
                        <dx:BootstrapScheduler runat="server" ID="Scheduler" ClientInstanceName="scheduler"
                            AppointmentDataSourceID="AppointmentDataSource" ResourceDataSourceID="ResourcesDataSource"
                            Start='<%# DateTime.Now %>'
                            OnFilterResource="Scheduler_FilterResource">
                            <CssClasses Control="h-100 rounded-0 border-0" />
                            <CssClassesViewSelector Button="demo-btn-custom-state active-underline" />
                            <OptionsAdaptivity Enabled="true" />
                            <OptionsAppearance ToolbarRenderMode="Header"></OptionsAppearance>
                            <OptionsBehavior RecurrentAppointmentEditAction="Ask" ShowViewVisibleInterval="true" ShowViewNavigator="true" />
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
                                <AgendaView DayCount="30"></AgendaView>
                                <DayView ShowMoreButtons="false">
                                    <VisibleTime Start="7:00" End="22:00" />
                                </DayView>
                                <WeekView Enabled="false" />
                                <WorkWeekView ShowMoreButtons="false"></WorkWeekView>
                                <FullWeekView Enabled="true" ShowMoreButtons="false"></FullWeekView>
                                <MonthView CompressWeekend="False" />
                                <TimelineView Enabled="False" />
                            </Views>
                        </dx:BootstrapScheduler>
                    </WidgetContent>
                </demo:Widget>
            </Widgets>
        </demo:WidgetsContainer>
    </div>
    <asp:ObjectDataSource ID="AppointmentDataSource" runat="server"
        DataObjectTypeName="TypicalSouthernFoods.Webforms.SchedulerAppointment"
        TypeName="TypicalSouthernFoods.Webforms.AppointmentDataSourceHelper"
        SelectMethod="SelectMethodHandler" DeleteMethod="DeleteMethodHandler" InsertMethod="InsertMethodHandler" UpdateMethod="UpdateMethodHandler"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ResourcesDataSource" runat="server"
        DataObjectTypeName="TypicalSouthernFoods.Webforms.SchedulerResource"
        TypeName="TypicalSouthernFoods.Webforms.ResourceDataSourceHelper"
        SelectMethod="GetItems"></asp:ObjectDataSource>
</asp:Content>