<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/Site.master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="TypicalSouthernFoods.Webforms.Views.Clients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <h1>Clients Table</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-12">

                <dx:BootstrapGridView ID="ASPxGridView1" runat="server" DataSourceID="EDMain" KeyFieldName="ID" Width="100%">
                    <Settings ShowFilterRow="True"></Settings>

                    <SettingsBehavior ConfirmDelete="true" />
                    <SettingsSearchPanel Visible="True" ShowApplyButton="True" ShowClearButton="True"></SettingsSearchPanel>
                    <SettingsCommandButton RenderMode="Button">
                    </SettingsCommandButton>

                    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />

                    <Columns>
                        <dx:BootstrapGridViewCommandColumn VisibleIndex="0" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:BootstrapGridViewCommandColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="ID" ReadOnly="true">
                            <SettingsEditForm Visible="False" />
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="NAMES"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SURNAMES"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="ADDRESS"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="PHONE"></dx:BootstrapGridViewTextColumn>
                    </Columns>
                </dx:BootstrapGridView>


            </div>
        </div>
     </div>


    <ef:EntityDataSource runat="server" ID="EDMain" EntitySetName="CLIENTS" DefaultContainerName="EntitiesDataModel" ConnectionString="<%$ ConnectionStrings: EntitiesDataModel %>"
        EnableDelete="true" EnableInsert="true" EnableUpdate="true" AutoPage="true" AutoGenerateOrderByClause="true"
        AutoGenerateWhereClause="true" AutoSort="true"  > 
    </ef:EntityDataSource>

</asp:Content>
