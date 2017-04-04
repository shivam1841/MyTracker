<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Admin.Master" AutoEventWireup="true" CodeBehind="AdminSendEmail.aspx.cs" Inherits="OEMS.AdminPanel.AdminSendEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Send Email" Font-Bold="True" Font-Names="Goudy Stout" Font-Size="18pt"></asp:Label>
        <asp:Panel runat="server" ID="panel_status" Visible="false">
            <asp:Label ID="lbl_response" runat="server" Font-Size="14pt"></asp:Label>
        </asp:Panel>

        <asp:Panel runat="server" ID="panel_email">
            <hr />
            <table name="email" border="0">
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="To: "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_emailID" runat="server" DataSourceID="ds_emailID" DataTextField="email" DataValueField="email" Height="20px" Width="300px" ToolTip="User Email Address">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Subject: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_subject" Width="300px" Height="20px" ToolTip="Subject" placeholder="Greetings from MyTracker"/>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        <asp:Label ID="Label4" runat="server" Text="Body: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_body" Width="300px" Rows="5" TextMode="MultiLine" Height="168px" ToolTip="Body" placeholder="Body" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button runat="server" ID="btn_send" Text="Send" OnClick="btn_send_Click" Width="83px" Height="34px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btn_cancel" Text="Cancel" Height="34px" OnClick="btn_cancel_Click" Width="83px" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <asp:SqlDataSource ID="ds_emailID" runat="server" ConnectionString="<%$ ConnectionStrings:myTrackerConnectionString %>" SelectCommand="SELECT [email] FROM [user] WHERE ([email] &lt;&gt; @email)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue=" " Name="email" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
