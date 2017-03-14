<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Organizer.Master" AutoEventWireup="true" CodeBehind="user_home.aspx.cs" Inherits="OEMS.user_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 607px;
        }
        .auto-style3 {
            width: 607px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table style="width: 740px" border="0">
            <tr>
                <td colspan="2" class="auto-style3" align="center">
                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="My All Events" Font-Bold="True" Font-Size="20pt" Font-Names="Forte"></asp:Label>
                </td>
            </tr>
            <tr><td><hr style="border: thick double #000000" /></td></tr>
            <tr style="background-color:darkseagreen">
                <td colspan="2" class="auto-style3" align="center">
                    <asp:Label ID="lbl_upcoming" runat="server" ForeColor="Black" Text="Upcoming Events" Font-Bold="True" Font-Names="Forte" Font-Size="18pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:GridView ID="gv_upcoming_event" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Width="730px" AllowPaging="True" PageSize="5">
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </td>
            </tr>
            <tr><td><hr style="border: thick double #000000" /></td></tr>
            <tr style="background-color:forestgreen">
                <td colspan="2" class="auto-style2" align="center">
                    <asp:Label ID="lbl_ongoing" runat="server" ForeColor="Black" Text="Ongoing Events" Font-Bold="True" Font-Names="Forte" Font-Size="18pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:GridView ID="gv_ongoing_event" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AllowPaging="True" PageSize="5" Width="730px">
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </td>
            </tr>
            <tr><td><hr style="border: thick double #000000" /></td></tr>
            <tr style="background-color:red">
                <td colspan="2" class="auto-style2" align="center">
                    <asp:Label ID="lbl_past" runat="server" ForeColor="Black" Text="Past Events" Font-Bold="True" Font-Names="Forte" Font-Size="18pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:GridView ID="gv_past_event" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AllowPaging="True" PageSize="5" Width="730px">
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </td>
            </tr>
            <tr><td><hr style="border: thick double #000000" /></td></tr>
        </table>
    </div>
</asp:Content>
