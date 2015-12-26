<%@ Page Title="ورود به سایت" Language="C#" MasterPageFile="~/BaseSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NetTalk.Web.Login.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" type="text/css" href="login.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MianContent" runat="server">
    <p>&nbsp;</p><p>&nbsp;</p>
    <asp:Panel runat="server" CssClass="loginpanel" ID="login" 
        DefaultButton="btn_login"><div id="loginInner">
        <asp:Panel ID="ErrorPanel" Visible="false" runat="server" CssClass="error">
            <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
        </asp:Panel>
	<div id="username_row">
        <asp:Label ID="lbl_username" AssociatedControlID="username" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox CssClass="input-textbox w200" ID="username" runat="server"></asp:TextBox>
	    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="username" ErrorMessage="*"></asp:RequiredFieldValidator>
	</div>
	<div id="password_row">
        <asp:Label ID="lbl_password" AssociatedControlID="password" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox CssClass="input-textbox w200" ID="password" runat="server" TextMode="Password"></asp:TextBox>
	    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="password" ErrorMessage="*"></asp:RequiredFieldValidator>
	</div>
    <div id="rmme_row">

        <asp:CheckBox ID="remember" runat="server" 
            Text="Remember me on This computer" />

    </div>
	<div id="button_row">
        <asp:Button ID="btn_login" runat="server" Text="Login" 
            onclick="btn_login_Click" CssClass="input-textbox" />
	</div>
</div></asp:Panel>
<p>&nbsp;</p><p>&nbsp;</p>
</asp:Content>
