<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Masters/Basic.Master"  CodeBehind="Login.aspx.cs" Inherits="TypicalSouthernFoods.Webforms.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div class="container">

        <div class="row">
            <div class="col-12">

                <h3>Demo Login</h3>

                <dx:BootstrapFormLayout runat="server" LayoutType="Horizontal">
                    <Items>

                        <dx:BootstrapLayoutItem Caption="Username" ColSpanLg="4" ColSpanMd="12">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="UsernameTextbox" runat="server" NullText="Username">
                                        <ValidationSettings ErrorDisplayMode="ImageWithText">
                                            <RequiredField IsRequired="true" />
                                        </ValidationSettings>

                                    </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem Caption="Password" ColSpanLg="4" ColSpanMd="12">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="PasswordTextbox" runat="server" NullText="Password">

                                        <ValidationSettings ErrorDisplayMode="ImageWithText">
                                            <RequiredField IsRequired="true" />
                                        </ValidationSettings>

                                    </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>



                        <dx:BootstrapLayoutItem ShowCaption="False">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapButton ID="ASPxButtonLogin" runat="server" ClientInstanceName="btnLogin" Text="Iniciar Sesión" CausesValidation="true" 
                                        OnClick="ASPxButtonLogin_Click" SettingsBootstrap-Sizing="Large" SettingsBootstrap-RenderOption="Primary" CssClasses-Control="btn-block">
                                        <ClientSideEvents Click="function(s, e) { 
                                                                ASPxClientEdit.ValidateGroup(null);

                                                                if(ASPxClientEdit.AreEditorsValid()) {                                                                                                                                
                                                                    LoadingPanel.SetText('Enviando datos al servidor...');
                                                                    LoadingPanel.Show();
                                                                }else{
                                                                    e.processOnServer = false;
                                                                }
                    
                    }" />

                                    </dx:BootstrapButton>

                                    <asp:Label ID="Msg" ForeColor="maroon" runat="server" CssClass="alert" /><br />
                                    <asp:CheckBox ID="NotPublicCheckBox" runat="server" />
                                    Check here if this is <span style="text-decoration: underline">not</span> a public computer.
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                    </Items>
                </dx:BootstrapFormLayout>


            </div>
        </div>
    </div>

    <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel" Modal="true" ContainerElementID="BootstrapFormLayout1" />
</asp:Content>


