<%@ Page Title="Edit Profile" Language="C#" MasterPageFile="~/Organizer.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="OEMS.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            height: 26px;;
        }
        .auto-style7 {
            height: 21px;
        }
        .auto-style8 {
            height: 10px;
        }
        .auto-style9 {
            width: 50%;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Panel runat="server" ID="panel_fetchData">
            <table style="width: 50%;" align="center" border="0" bgcolor="#E4BA1E">
                <tr>
                    <td align="center"></td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_fetchProfile" runat="server" Text="Load my profile" OnClick="btn_fetchProfile_Click" Font-Bold="True" Font-Size="Large" />
                    </td>
                </tr>
        </asp:Panel>

        <asp:Panel runat="server" ID="form">

            <table style="width: 50%;" align="center" border="0" bgcolor="#E4BA1E">
                <tr>
                    <td colspan="3" align="center">
                        <hr />
                        <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Forte" Font-Size="16pt" Text="Update Profile"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lbl_error_message" runat="server" Text="Error" ForeColor="Red" Visible="False" Font-Size="14pt"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">&nbsp;<strong><asp:Label ID="Label18" runat="server" Font-Bold="False" Font-Names="Forte" Font-Size="13pt" Text="Personal Details"></asp:Label>
                    </strong>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label5" runat="server" Text="First Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_firstname" runat="server" Width="225px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbl_firstname_star" runat="server" Text="*" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label6" runat="server" Text="Last Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_lastname" runat="server" Width="225px"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                 <tr>
                    <td align="right">
                        <asp:Label ID="Label12" runat="server" Text="Email:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_email" runat="server" Width="225px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="validator_email" runat="server" ErrorMessage="Not a valid email" ControlToValidate="txt_email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_email" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label9" runat="server" Text="Gender:"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButton ID="rb_male" runat="server" Text="Male" Checked="True" GroupName="gender" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rb_female" runat="server" Text="Female" GroupName="gender" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:Label ID="Label7" runat="server" Text="Address 1:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_address1" runat="server" Width="225px" Height="70px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td valign="top">
                        <asp:Label ID="lbl_address1_star" runat="server" Text="*" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8" align="right" valign="top">
                        <asp:Label ID="Label8" runat="server" Text="Address 2:"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txt_address2" runat="server" Width="225px" Height="70px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td class="auto-style8"></td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:Label ID="Label10" runat="server" Text="Province:"></asp:Label>
                    </td>
                    <td>
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
                    <td></td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:Label ID="Label11" runat="server" Text="Country:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_country" runat="server" Height="25px" Width="85px">
                            <asp:ListItem>Canada</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7" align="right" valign="top">
                        <strong>
                            <asp:Label ID="Label19" runat="server" Font-Bold="False" Font-Names="Forte" Font-Size="13pt" Text="Security Details"></asp:Label>
                        </strong></td>
                    <td class="auto-style7">
                        <asp:Label ID="Label13" runat="server" Font-Size="Small" ForeColor="Red" Text="(will be used during password recovery)"></asp:Label>
                    </td>
                    <td class="auto-style7"></td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:Label ID="Label14" runat="server" Text="Security Question:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_question" runat="server" Height="25px" Width="225px">
                            <asp:ListItem>What year did you graduate in?</asp:ListItem>
                            <asp:ListItem>What is the first name of your best friend in high school?</asp:ListItem>
                            <asp:ListItem>What was the make and model of your first car?</asp:ListItem>
                            <asp:ListItem>In what town or city was your first full time job?</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:Label ID="Label15" runat="server" Text="Security Answer:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_answer" runat="server" Width="225px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbl_answer_star" runat="server" Text="*" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top"></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style2" align="center" valign="top" colspan="3">
                        <asp:Button ID="btn_update" runat="server" Text="Update" Height="35px" OnClick="btn_update_Click" Width="85px" />&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_delete" runat="server" Text="Delete Profile" BackColor="Red" Font-Bold="True" Font-Size="12pt" ForeColor="#000066" Height="35px" OnClick="btn_delete_Click" Width="130px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <asp:Panel runat="server" ID="panel_deleteProfile">
            <table align="center" border="0" bgcolor="#E4BA1E" class="auto-style9">
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Forte" Font-Size="16pt" Text="Verify Password"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lbl_response_delete_profile" runat="server" Text="Error" ForeColor="Red" Visible="False" Font-Size="14pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">Enter Password: 
                    </td>
                    <td>
                        <asp:TextBox ID="txt_password_for_delete_profile" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btn_verify_password_for_delete_profile" runat="server" Text="Verify Password and Delete My Profile" Font-Bold="True" Height="35px" Width="261px" OnClick="btn_verify_password_for_delete_profile_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label4" runat="server" Text="You won't be able get your data back! ! !" ForeColor="Red" Font-Size="16pt"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <asp:Panel runat="server" ID="success_message" Font-Names="Forte" Font-Size="16pt" BorderStyle="Inset" BorderWidth="5px" HorizontalAlign="Center">
            <asp:Label ID="Label20" runat="server" Text="Deleting Profile. . ."></asp:Label>
            <br />
            <asp:Label ID="Label21" runat="server" Text="Will be redirected to Login page. . ."></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>
