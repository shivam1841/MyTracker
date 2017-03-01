<%@ Page Title="" Language="C#" MasterPageFile="~/Organizer.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="OEMS.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
            width: 10px;
        }

        .auto-style2 {
            height: 23px;
            width: 180px;
        }

        .auto-style3 {
            width: 180px;
        }

        .auto-style4 {
            height: 23px;
            width: 169px;
        }

        .auto-style5 {
            width: 169px;
        }

        .auto-style6 {
            width: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Panel runat="server" ID="form">

            <table style="width: 50%;" align="center" border="0" bgcolor="#E4BA1E">
                <tr>
                    <td colspan="3" align="center">
                        <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Forte" Font-Size="16pt" Text="Register New User"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lbl_error_message" runat="server" Text="Error" ForeColor="Red" Visible="False" Font-Size="14pt"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" align="center" colspan="3"><strong>
                        <asp:Label ID="Label17" runat="server" Font-Bold="False" Font-Names="Forte" Font-Size="13pt" Text="Login Details"></asp:Label>
                    </strong></td>
                </tr>
                <tr>
                    <td class="auto-style3" align="right">
                        <asp:Label ID="Label3" runat="server" Text="User Name:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txt_username" runat="server" Width="225px"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        <asp:Label ID="lbl_username_star" runat="server" Text="*" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="right">
                        <asp:Label ID="Label4" runat="server" Text="Password:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txt_password" runat="server" Width="225px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        <asp:Label ID="lbl_password_star" runat="server" Text="*" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="right">
                        <asp:Label ID="Label1" runat="server" Text="Confirm Password:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txt_confirm_password" runat="server" Width="225px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        <asp:Label ID="lbl_confirm_password_star" runat="server" Text="*" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="center" colspan="3">&nbsp;<strong><asp:Label ID="Label18" runat="server" Font-Bold="False" Font-Names="Forte" Font-Size="13pt" Text="Personal Details"></asp:Label>
                    </strong>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="right">
                        <asp:Label ID="Label5" runat="server" Text="First Name:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txt_firstname" runat="server" Width="225px"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        <asp:Label ID="lbl_firstname_star" runat="server" Text="*" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="right">
                        <asp:Label ID="Label6" runat="server" Text="Last Name:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txt_lastname" runat="server" Width="225px"></asp:TextBox>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label9" runat="server" Text="Gender:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:RadioButton ID="rb_male" runat="server" Text="Male" Checked="True" GroupName="gender" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rb_female" runat="server" Text="Female" GroupName="gender" />
                    </td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style3" align="right" valign="top">
                        <asp:Label ID="Label7" runat="server" Text="Address 1:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txt_address1" runat="server" Width="225px" Height="70px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td valign="top" class="auto-style6">
                        <asp:Label ID="lbl_address1_star" runat="server" Text="*" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="right" valign="top">
                        <asp:Label ID="Label8" runat="server" Text="Address 2:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txt_address2" runat="server" Width="225px" Height="70px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3" align="right" valign="top">
                        <asp:Label ID="Label10" runat="server" Text="Province:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="ddl_province" runat="server" Height="25px" Width="70px">
                            <asp:ListItem>AB</asp:ListItem>
                            <asp:ListItem>BC</asp:ListItem>
                            <asp:ListItem>MB</asp:ListItem>
                            <asp:ListItem>NB</asp:ListItem>
                            <asp:ListItem>NT</asp:ListItem>
                            <asp:ListItem>NS</asp:ListItem>
                            <asp:ListItem>ON</asp:ListItem>
                            <asp:ListItem>QC</asp:ListItem>
                            <asp:ListItem>SK</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3" align="right" valign="top">
                        <asp:Label ID="Label11" runat="server" Text="Country:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="ddl_country" runat="server" Height="25px" Width="85px">
                            <asp:ListItem>Canada</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" align="right" valign="top">
                        <strong>
                            <asp:Label ID="Label19" runat="server" Font-Bold="False" Font-Names="Forte" Font-Size="13pt" Text="Security Details"></asp:Label>
                        </strong></td>
                    <td class="auto-style4">
                        <asp:Label ID="Label13" runat="server" Font-Size="Small" ForeColor="Red" Text="(will be used during password recovery)"></asp:Label>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" align="right" valign="top">
                        <asp:Label ID="Label14" runat="server" Text="Security Question:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="ddl_question" runat="server" Height="25px" Width="225px">
                            <asp:ListItem>What year did you graduate in?</asp:ListItem>
                            <asp:ListItem>What is the first name of your best friend in high school?</asp:ListItem>
                            <asp:ListItem>What was the make and model of your first car?</asp:ListItem>
                            <asp:ListItem>In what town or city was your first full time job?</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" align="right" valign="top">
                        <asp:Label ID="Label15" runat="server" Text="Security Answer:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txt_answer" runat="server" Width="225px"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="lbl_answer_star" runat="server" Text="*" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" align="right" valign="top">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" align="right" valign="top">
                        <asp:Button ID="btn_register" runat="server" Text="Register" OnClick="btn_register_Click" />
                    </td>
                    <td class="auto-style4" align="center">
                        <asp:Button ID="btn_reset" runat="server" Text="Reset" Width="71px" BackColor="LightGray" OnClick="btn_reset_Click" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" align="right" valign="top">
                        <asp:Label ID="Label16" runat="server" Text="Already Registered?"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/login.aspx">(click here to login)</asp:HyperLink>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>

    <div align="center">
        <asp:Panel runat="server" ID="success_message" Font-Names="Forte" Font-Size="16pt" BorderStyle="Inset" BorderWidth="5px" HorizontalAlign="Center">
            <asp:Label ID="Label20" runat="server" Text="Registration successful. . ."></asp:Label>
            <br />
            <asp:Label ID="Label21" runat="server" Text="Signing in, please wait. . ."></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>
