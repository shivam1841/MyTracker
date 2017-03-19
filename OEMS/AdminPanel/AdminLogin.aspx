<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Admin.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="OEMS.AdminPanel.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            width: 327px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table class="auto-style2" style="background:#E4BA1E">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="Admin Login" Font-Names="forte" Font-Size="20pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl_response" runat="server" ForeColor="Red" Visible="False" Font-Bold="True" Font-Size="14pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" align="right">
                    <asp:Label ID="Label2" runat="server" Text="Username:" Font-Names="forte"></asp:Label>
                </td>
                <td class="auto-style1" align="left">
                    <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
                    <asp:Label ID="lbl_username_star" runat="server" Text="*" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Text="Password:" Font-Names="forte"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="lbl_password_star" runat="server" Text="*" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btn_login" runat="server" Text="Login" BorderStyle="Ridge" Width="100px" OnClick="btn_login_Click" />
                </td>
                <td align="center">
                    <asp:Button ID="btn_reset" runat="server" Text="Reset" BorderStyle="Ridge" Width="100px" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="link_forgotPassword" runat="server" Font-Size="12pt" NavigateUrl="~/ForgotPassword.aspx">Forgot Password?</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
