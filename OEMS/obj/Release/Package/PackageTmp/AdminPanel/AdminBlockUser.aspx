<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Admin.Master" AutoEventWireup="true" CodeBehind="AdminBlockUser.aspx.cs" Inherits="OEMS.AdminPanel.AdminBlockUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Default"></asp:Label>
    <br />
    <asp:Panel runat="server" ID="panel_blockUser">
        <div align="center">
            <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="Block user" Font-Bold="True" Font-Names="Goudy Stout" Font-Size="18pt"></asp:Label>
            <br />
            <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="btn_block" runat="server" Text="Block" />
            <br />
        </div>
    </asp:Panel>
    <asp:Panel runat="server">
        <div align="center">
            <asp:Label ID="lbl_response" runat="server" Text="User blocked successfully. . ." ForeColor="Blue"></asp:Label>
        </div>
    </asp:Panel>
</asp:Content>
