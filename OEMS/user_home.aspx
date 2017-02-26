<%@ Page Title="" Language="C#" MasterPageFile="~/Organizer.Master" AutoEventWireup="true" CodeBehind="user_home.aspx.cs" Inherits="OEMS.user_home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="right" style="background-color:#E4BA1E">
        <p><b><h3>Welcome, <asp:Label ID="lbl_username" runat="server" Text="User"></asp:Label></h3></b></p>
    </div>
    <div>
        content area
    </div>
</asp:Content>
