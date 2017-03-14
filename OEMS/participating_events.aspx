<%@ Page Title="Participating Events" Language="C#" MasterPageFile="~/Organizer.Master" AutoEventWireup="true" CodeBehind="participating_events.aspx.cs" Inherits="OEMS.participating_events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        &nbsp;&nbsp;&nbsp;
        <table style="width: 740px" border="0" align="center">
            <tr>
                <td colspan="2" class="auto-style3" align="center">
                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Events I am Added as Paticipant" Font-Bold="True" Font-Size="20pt" Font-Names="Forte"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <hr style="border: thick double #000000" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:GridView ID="gv_participating_event" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Width="730px" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" DataKeyNames="event_id" DataSourceID="ds_participating_events" OnSelectedIndexChanged="gv_participating_event_SelectedIndexChanged" SelectedIndex="0">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="event_id" HeaderText="ID" ReadOnly="True" SortExpression="event_id" />
                            <asp:BoundField DataField="event_name" HeaderText="Name" SortExpression="event_name" />
                            <asp:BoundField DataField="event_description" HeaderText="Description" SortExpression="event_description" >
                            </asp:BoundField>
                            <asp:BoundField DataField="event_location" HeaderText="Location" SortExpression="event_location" />
                            <asp:BoundField DataField="event_activity" HeaderText="Activity" SortExpression="event_activity" />
                            <asp:BoundField DataField="assigned_by" HeaderText="Assigned By" SortExpression="assigned_by" />
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
                    <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="(Select event to view detailed information)"></asp:Label>

                    <asp:SqlDataSource ID="ds_participating_events" runat="server" ConnectionString="<%$ ConnectionStrings:myTracker_DBConnectionString %>" SelectCommand="SELECT event.event_id, event.event_name, event.event_description, event.event_location, event.event_activity, event_participants.assigned_by FROM event INNER JOIN event_participants ON event.event_id = event_participants.event_id WHERE (event_participants.user_name = @user_name) AND (event.end_date &gt; SYSDATETIME())">
                        <SelectParameters>
                            <asp:SessionParameter Name="user_name" SessionField="username" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DetailsView ID="dv_participating_event" runat="server" Height="50px" Width="350px" AutoGenerateRows="False" BackColor="#DEBA84" BorderColor="Tan" BorderStyle="Groove" BorderWidth="5px" CellPadding="3" CellSpacing="2" DataKeyNames="event_id" DataSourceID="SqlDataSource1" GridLines="Horizontal" HeaderText="Event Details">
                        <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
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
                        </Fields>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    </asp:DetailsView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:myTracker_DBConnectionString %>" SelectCommand="SELECT [event_id], [event_name], [event_description], [start_date], [end_date], [event_location], [event_city], [event_province], [event_activity] FROM [event] WHERE ([event_id] = @event_id)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="gv_participating_event" Name="event_id" PropertyName="SelectedValue" Type="Decimal" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
