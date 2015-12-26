<%@ Page Title="" Language="C#" MasterPageFile="~/BaseSite.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="NetTalk.Web.Admin.UsersList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MianContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" Width="99%" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSource1" AllowPaging="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Username" HeaderText="Username" 
                SortExpression="Username" />
            <asp:BoundField DataField="VcardFirstName" HeaderText="First Name" 
                SortExpression="VcardFirstName" />
            <asp:BoundField DataField="VcardLastName" HeaderText="Last Name" 
                SortExpression="VcardLastName" />
            <asp:BoundField DataField="UserStatus" HeaderText="Status" 
                SortExpression="UserStatus" />
            <asp:BoundField DataField="UserStatusText" HeaderText="Status Text" 
                SortExpression="UserStatusText" />
            <asp:CheckBoxField DataField="UserIsOnline" HeaderText="Is Online" 
                SortExpression="UserIsOnline" />
            <asp:TemplateField HeaderText="Password">
                <ItemTemplate>
                    <%# PassView(Eval("Username") as string) %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" 
        MaximumRowsParameterName="PageSize" 
        OldValuesParameterFormatString="original_{0}" SelectCountMethod="ListVwCount" 
        SelectMethod="ListVw" SortParameterName="Sort" 
        StartRowIndexParameterName="PageIndex" TypeName="NetTalk.BLL.Users">
        
    </asp:ObjectDataSource>
</asp:Content>
