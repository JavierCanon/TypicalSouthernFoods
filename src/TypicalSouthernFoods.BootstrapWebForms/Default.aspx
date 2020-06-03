<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Masters/Site.master" CodeBehind="Default.aspx.cs" Inherits="TypicalSouthernFoods.Webforms.Default" %>

<%@ Register Assembly="DevExpress.Dashboard.v20.1.Web.WebForms, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>


<asp:Content runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <h1>Main Dashboard</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-12">

                <dx:ASPxDashboard runat="server" ID="ASPxDashboard1" WorkingMode="ViewerOnly"
                    Height="1200" Width="1600" 
                    DashboardType="<%# typeof(TypicalSouthernFoods.Webforms.Domain.Dashboards.DashboardMain) %>"> 
                     
                </dx:ASPxDashboard>

            </div>
        </div>
    </div>

</asp:Content>
