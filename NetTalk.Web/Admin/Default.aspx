<%@ Page Title="" Language="C#" MasterPageFile="~/BaseSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NetTalk.Web.Admin.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MianContent" runat="server">
<table class="dataTable">
    <tr>
        <td style="width:200px;">Server Status</td>
        <td>
            <asp:Image ID="imgserverStatus" runat="server" 
                ImageUrl="~/Scripts/Style/images/active.gif" />
        </td>
    </tr>
    <tr>
        <td style="width:200px;">Server current users:</td>
        <td>
            <asp:Label ID="lblusercount" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width:200px;">Server online users:</td>
        <td>
            <asp:Label ID="lblonlinecount" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width:200px;">Server connection list:</td>
        <td>
            <asp:Label ID="lblconnectioncount" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width:200px;">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
