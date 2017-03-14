<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Organizer.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="OEMS.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Label ID="Label2" runat="server" Text="Change Password" Font-Names="Goudy Stout" Font-Size="16pt"></asp:Label><br />
        <asp:Label ID="lbl_response" runat="server" Visible="False" Font-Size="14pt"></asp:Label>
        <hr />
        <asp:Panel ID="panel_newPassword" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Enter Current Password: " Font-Names="Times New Roman"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_oldPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbl_oldPassword_star" runat="server" Text="*" Font-Names="Times New Roman" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="New Password: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_newPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                     <td>
                        <asp:Label ID="lbl_newPassword_star" runat="server" Text="*" Font-Names="Times New Roman" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label4" runat="server" Text="Confirm Password: "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txt_confirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                     <td>
                        <asp:Label ID="lbl_confirmPassword_star" runat="server" Text="*" Font-Names="Times New Roman" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="btn_changePassword" runat="server" Text="Change Password" OnClick="btn_changePassword_Click" />
                    </td>
                    <td align="center">
                        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
