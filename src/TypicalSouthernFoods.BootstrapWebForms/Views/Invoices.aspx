<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/Site.master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="TypicalSouthernFoods.Webforms.Views.Invoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <h1>Invoices</h1>
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
                    <SettingsDetail ShowDetailRow="true" ShowDetailButtons="true" />

                    <Columns>
                        <dx:BootstrapGridViewCommandColumn VisibleIndex="0" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:BootstrapGridViewCommandColumn>
                        
                        <dx:BootstrapGridViewTextColumn FieldName="ID" ReadOnly="true">
                            <SettingsEditForm Visible="False" />
                        </dx:BootstrapGridViewTextColumn>
                        
                        <dx:BootstrapGridViewDateColumn FieldName="INVOICE_DATE"></dx:BootstrapGridViewDateColumn>

                        <dx:BootstrapGridViewComboBoxColumn FieldName="ID_CLIENT" Caption="CLIENT">
                            <PropertiesComboBox DataSourceID="EDClients" ValueField="ID">
                                <Fields>
                                    <dx:BootstrapListBoxField FieldName="NAMES">                                        
                                    </dx:BootstrapListBoxField>
                                    <dx:BootstrapListBoxField FieldName="SURNAMES"></dx:BootstrapListBoxField>
                                    <dx:BootstrapListBoxField FieldName="PHONE"></dx:BootstrapListBoxField>
                                </Fields>
                            </PropertiesComboBox>
                        </dx:BootstrapGridViewComboBoxColumn>

                        <dx:BootstrapGridViewComboBoxColumn FieldName="ID_TABLE" Caption="TABLE">
                            <PropertiesComboBox DataSourceID="EDTables" ValueField="ID">
                                <Fields>
                                    <dx:BootstrapListBoxField FieldName="NAME">
                                    </dx:BootstrapListBoxField>
                                </Fields>
                            </PropertiesComboBox>
                        </dx:BootstrapGridViewComboBoxColumn>

                        <dx:BootstrapGridViewComboBoxColumn FieldName="ID_WAITER" Caption="WAITER">
                            <PropertiesComboBox DataSourceID="EDWaiters" ValueField="ID">
                                <Fields>
                                    <dx:BootstrapListBoxField FieldName="NAMES">
                                    </dx:BootstrapListBoxField>
                                    <dx:BootstrapListBoxField FieldName="SURNAMES">
                                    </dx:BootstrapListBoxField>
                                </Fields>
                            </PropertiesComboBox>
                        </dx:BootstrapGridViewComboBoxColumn>

                    </Columns>


                    <Templates>

                        <DetailRow>

                            <h3>Menu Order: <%# Eval("ID") %></h3>
                             <dx:BootstrapGridView runat="server" ID="ASPxGridViewDetail"
                                 DataSourceID="EDDetail" KeyFieldName="ID" 
                                 OnBeforePerformDataSelect="ASPxGridViewDetail_BeforePerformDataSelect"
                                 OnInitNewRow="ASPxGridViewDetail_InitNewRow" 
                                 OnRowInserting="ASPxGridViewDetail_RowInserting"
                                 >

                                 <SettingsBehavior ConfirmDelete="true" />
                                 <SettingsCommandButton RenderMode="Button">
                                 </SettingsCommandButton>

                                 <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />

                                 <Columns>
                                     <dx:BootstrapGridViewCommandColumn VisibleIndex="0" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:BootstrapGridViewCommandColumn>

                                     <dx:BootstrapGridViewTextColumn FieldName="ID" ReadOnly="true" Visible="false">
                                         <SettingsEditForm Visible="false" />
                                     </dx:BootstrapGridViewTextColumn>

                                     <dx:BootstrapGridViewTextColumn FieldName="ID_INVOICE" ReadOnly="true">
                                         <SettingsEditForm Visible="false" />
                                     </dx:BootstrapGridViewTextColumn>

                                     <dx:BootstrapGridViewComboBoxColumn FieldName="RECIPE_NAME" Caption="RECIPE">
                                         <PropertiesComboBox DataSourceID="EDRecipes" ValueField="NAME">
                                             <Fields>
                                                 <dx:BootstrapListBoxField FieldName="NAME">
                                                 </dx:BootstrapListBoxField>
                                                 <dx:BootstrapListBoxField FieldName="PRICE">
                                                 </dx:BootstrapListBoxField>
                                             </Fields>

                                             <ValidationSettings>
                                                 <RequiredField IsRequired="true" />
                                             </ValidationSettings>

                                         </PropertiesComboBox>
                                     </dx:BootstrapGridViewComboBoxColumn>

                                     <dx:BootstrapGridViewTextColumn FieldName="PRICE">
                                         <PropertiesTextEdit DisplayFormatString="N2">    
                                             <ValidationSettings>
                                                 <RequiredField IsRequired="true" />
                                             </ValidationSettings>
                                         </PropertiesTextEdit>
                                     </dx:BootstrapGridViewTextColumn>

                                 </Columns>

                                 <GroupSummary>
                                     <dx:ASPxSummaryItem FieldName="PRICE" SummaryType="Sum" />
                                 </GroupSummary>

                             </dx:BootstrapGridView>


                        </DetailRow>

                    </Templates>



                </dx:BootstrapGridView>


            </div>
        </div>
    </div>

    <ef:EntityDataSource runat="server" ID="EDMain" EntitySetName="INVOICES" DefaultContainerName="EntitiesDataModel" ConnectionString="<%$ ConnectionStrings: EntitiesDataModel %>"
        AutoPage="true" AutoGenerateOrderByClause="true"
        EnableDelete="True" EnableInsert="True" EnableUpdate="True"
        AutoGenerateWhereClause="true" AutoSort="true">
    </ef:EntityDataSource>

    <ef:EntityDataSource runat="server" ID="EDDetail" EntitySetName="INVOICES_DET" DefaultContainerName="EntitiesDataModel" ConnectionString="<%$ ConnectionStrings: EntitiesDataModel %>"
        EnableDelete="true" EnableInsert="true" EnableUpdate="true" AutoPage="true" AutoGenerateOrderByClause="true"
        AutoGenerateWhereClause="true" AutoSort="true"
         OnInserting="EDDetail_Inserting"
        >
        <WhereParameters>
            <asp:Parameter Name="ID_INVOICE" Type="Int32" DefaultValue="0" />
        </WhereParameters>

    </ef:EntityDataSource>

    <ef:EntityDataSource runat="server" ID="EDClients" EntitySetName="CLIENTS" DefaultContainerName="EntitiesDataModel" ConnectionString="<%$ ConnectionStrings: EntitiesDataModel %>"
        AutoPage="true" AutoGenerateOrderByClause="true"
        EnableDelete="false" EnableInsert="false" EnableUpdate="false"
        AutoGenerateWhereClause="true" AutoSort="true">
    </ef:EntityDataSource>

    <ef:EntityDataSource runat="server" ID="EDTables" EntitySetName="TABLES" DefaultContainerName="EntitiesDataModel" ConnectionString="<%$ ConnectionStrings: EntitiesDataModel %>"
        AutoPage="true" AutoGenerateOrderByClause="true"
        EnableDelete="false" EnableInsert="false" EnableUpdate="false"
        AutoGenerateWhereClause="true" AutoSort="true">
    </ef:EntityDataSource>

    <ef:EntityDataSource runat="server" ID="EDWaiters" EntitySetName="WAITERS" DefaultContainerName="EntitiesDataModel" ConnectionString="<%$ ConnectionStrings: EntitiesDataModel %>"
        AutoPage="true" AutoGenerateOrderByClause="true"
        EnableDelete="false" EnableInsert="false" EnableUpdate="false"
        AutoGenerateWhereClause="true" AutoSort="true">
    </ef:EntityDataSource>

    <ef:EntityDataSource runat="server" ID="EDRecipes" EntitySetName="RECIPES" DefaultContainerName="EntitiesDataModel" ConnectionString="<%$ ConnectionStrings: EntitiesDataModel %>"
        AutoPage="true" AutoGenerateOrderByClause="true"
        EnableDelete="false" EnableInsert="false" EnableUpdate="false"
        AutoGenerateWhereClause="true" AutoSort="true">
    </ef:EntityDataSource>

</asp:Content>
