﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Admin.Master" AutoEventWireup="true" CodeBehind="AdminEventsReport.aspx.cs" Inherits="OEMS.AdminPanel.AdminEventsReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Events Report" Font-Bold="True" Font-Names="Goudy Stout" Font-Size="18pt"></asp:Label>
        <hr />
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Search for a keyword:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_keyword" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
                    &nbsp;<asp:Button ID="btn_clearSearch" runat="server" Text="Clear Search" OnClick="btn_clearSearch_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    (ex: search "yes" for public events or vice-versa)
                </td>
            </tr>
        </table>
        <hr />
        <asp:GridView ID="gv_eventlist" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="Tan" BorderStyle="Groove" BorderWidth="5px" CellPadding="3" CellSpacing="2" DataKeyNames="event_id" DataSourceID="gv_ds_cloudDB" PageSize="7" AllowSorting="True" SelectedIndex="0" Width="446px" OnSelectedIndexChanged="gv_eventlist_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="event_id" HeaderText="ID" ReadOnly="True" SortExpression="event_id" />
                <asp:BoundField DataField="event_name" HeaderText="Name" SortExpression="event_name" />
                <asp:BoundField DataField="event_description" HeaderText="Description" SortExpression="event_description" />
                <asp:BoundField DataField="event_location" HeaderText="Location" SortExpression="event_location" />
                <asp:BoundField DataField="user_name" HeaderText="Created By" SortExpression="user_name" />
            </Columns>
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
        <asp:SqlDataSource ID="gv_ds_cloudDB" runat="server" ConnectionString="<%$ ConnectionStrings:myTrackerConnectionString %>" SelectCommand="SELECT [event_id], [event_name], [event_description], [event_location], [user_name] FROM [event]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="ds_keyword" runat="server" ConnectionString="<%$ ConnectionStrings:myTrackerConnectionString %>" SelectCommand="SELECT [event_id], [event_name], [event_description], [event_location], [user_name] FROM [event] WHERE (([event_name] LIKE '%' + @event_name + '%') OR ([event_description] LIKE '%' + @event_description + '%') OR ([event_activity] LIKE '%' + @event_activity + '%') OR ([event_city] LIKE '%' + @event_city + '%') OR ([event_location] LIKE '%' + @event_location + '%') OR ([event_province] LIKE '%' + @event_province + '%') OR ([user_name] LIKE '%' + @user_name + '%') OR ([public] = @public))">
            <SelectParameters>
                <asp:ControlParameter ControlID="txt_keyword" Name="event_name" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="event_description" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="event_activity" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="event_city" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="event_location" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="event_province" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="user_name" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="public" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="(Select event to view detailed information)"></asp:Label>
    </div>
    <hr />
    <div align="center">
        <table>
            <tr>
                <td rowspan="12">

                    <asp:DetailsView ID="dv_event_details" runat="server" Height="50px" Width="380px" AutoGenerateRows="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="5px" CellPadding="5" DataKeyNames="event_id" DataSourceID="dv_ds_eventDetails_admin" ForeColor="Black" GridLines="Horizontal" BorderStyle="Groove" HeaderText="Event Details" HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <Fields>
                            <asp:BoundField DataField="event_id" HeaderText="ID" ReadOnly="True" SortExpression="event_id" />
                            <asp:BoundField DataField="event_name" HeaderText="Name" SortExpression="event_name" />
                            <asp:BoundField DataField="event_description" HeaderText="Description" SortExpression="event_description" />
                            <asp:BoundField DataField="start_date" HeaderText="Start Date" SortExpression="start_date" />
                            <asp:BoundField DataField="end_date" HeaderText="End Date" SortExpression="end_date" />
                            <asp:BoundField DataField="event_location" HeaderText="Location" SortExpression="event_location" />
                            <asp:BoundField DataField="event_city" HeaderText="City" SortExpression="event_city" />
                            <asp:BoundField DataField="event_province" HeaderText="Province" SortExpression="event_province" />
                            <asp:BoundField DataField="event_activity" HeaderText="Activity" SortExpression="event_activity" />
                            <asp:BoundField DataField="user_name" HeaderText="Created By" SortExpression="user_name" />
                            <asp:BoundField DataField="participant" HeaderText="Participating User" SortExpression="participant" />
                            <asp:BoundField DataField="public" HeaderText="Is it public?" SortExpression="public" />
                        </Fields>
                        <FooterStyle BackColor="Tan" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <PagerStyle ForeColor="DarkSlateBlue" HorizontalAlign="Center" BackColor="PaleGoldenrod" />
                    </asp:DetailsView>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_showMap" runat="server" Text="View on map" OnClick="btn_showMap_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:SqlDataSource ID="dv_ds_eventDetails_admin" runat="server" ConnectionString="<%$ ConnectionStrings:myTrackerConnectionString %>" SelectCommand="SELECT * FROM [event] WHERE ([event_id] = @event_id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="gv_eventlist" Name="event_id" PropertyName="SelectedValue" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Button ID="btn_printPage" runat="server" Text="Print Details" OnClientClick="javascript:window.print();" Height="35px" />
    </div>
</asp:Content>
