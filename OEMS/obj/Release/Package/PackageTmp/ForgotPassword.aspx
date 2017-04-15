<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/Organizer.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="OEMS.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 119px;
            height: 42px;
        }

        .auto-style3 {
            height: 42px;
        }

        .auto-style4 {
            width: 119px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Panel runat="server" ID="panel_title">
            <table>
                <tr>
                    <td align="center">
                        <asp:Label ID="Label1" runat="server" Text="Forgot Password" Font-Names="Goudy Stout"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lbl_response" runat="server" Text="" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="panel_username">
            <table>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="Label2" runat="server" Text="User Name: "></asp:Label>
                        <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
                        &nbsp;<asp:Label ID="lbl_username_star" runat="server" Text="*" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_submit_username" runat="server" Text="Reset with Email Address" OnClick="btn_submit_username_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btn_verifyBySecurity" runat="server" Text="Reset with security answer" OnClick="btn_verifyBySecurity_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="panel_emailConfirmation" Visible="false">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_emailConfirmation" runat="server" Text=""></asp:Label>&nbsp;
                        <asp:HyperLink ID="hl_login" runat="server" NavigateUrl="~/login.aspx">(click here to login)</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Didn't get the email? To reset the password with security question "></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btn_navigateToSecurityAnswerPanel" runat="server" Text="click here" OnClick="btn_navigateToSecurityAnswerPanel_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="panel_securityAnswer" Visible="false">
            <table>
                <tr>
                    <td align="left" class="auto-style4">
                        <asp:Label ID="Label4" runat="server" Text="Security Question: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_question" runat="server" ReadOnly="True" Width="311px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="auto-style2">
                        <asp:Label ID="Label5" runat="server" Text="Security Answer: "></asp:Label>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:TextBox ID="txt_answer" runat="server" Width="154px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="left">
                        <asp:Button ID="btn_verifySecurityAnswer" runat="server" Text="Submit" OnClick="btn_verifySecurityAnswer_Click1" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="panel_newPassword" Visible="false">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="New password: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_newPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Confirm Password: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_confirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btn_changePassword" runat="server" Text="Change Password" OnClick="btn_changePassword_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btn_cancel" runat="server" Text="Proceed to Login" OnClick="btn_cancel_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
