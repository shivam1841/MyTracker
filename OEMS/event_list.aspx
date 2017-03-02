<%@ Page Title="" Language="C#" MasterPageFile="~/Organizer.Master" AutoEventWireup="true" CodeBehind="event_list.aspx.cs" Inherits="OEMS.event_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="My Events" Font-Bold="True" Font-Names="Goudy Stout" Font-Size="18pt"></asp:Label>
        <hr />
        <asp:GridView ID="gv_eventlist" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="Tan" BorderStyle="Groove" BorderWidth="5px" CellPadding="3" CellSpacing="2" DataKeyNames="event_id" DataSourceID="ds_eventlist" PageSize="5" AllowSorting="True" SelectedIndex="0" Width="446px" OnSelectedIndexChanged="gv_eventlist_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="event_id" HeaderText="ID" ReadOnly="True" SortExpression="event_id" />
                <asp:BoundField DataField="event_name" HeaderText="Name" SortExpression="event_name" />
                <asp:BoundField DataField="event_location" HeaderText="Location" SortExpression="event_location" />
                <asp:BoundField DataField="event_activity" HeaderText="Activity" SortExpression="event_activity" />
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
    </div>
    <hr />
    <div align="center">
        <asp:DetailsView ID="dv_event_details" runat="server" Height="50px" Width="380px" AutoGenerateRows="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="5px" CellPadding="5" DataKeyNames="event_id" DataSourceID="ds_eventDetail" ForeColor="Black" GridLines="Horizontal" BorderStyle="Groove" HeaderText="Event Details" HorizontalAlign="Center">
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
                <asp:BoundField DataField="participant" HeaderText="Participant" SortExpression="participant" />
            </Fields>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle ForeColor="DarkSlateBlue" HorizontalAlign="Center" BackColor="PaleGoldenrod" />
        </asp:DetailsView>
        <asp:Label ID="Label3" runat="server" Text="To update details, copy the ID and "></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ManageEvent.aspx">click here</asp:HyperLink>

        <asp:SqlDataSource ID="ds_eventDetail" runat="server" ConnectionString="<%$ ConnectionStrings:myTracker_DBConnectionString %>" SelectCommand="SELECT [event_id], [event_name], [event_description], [start_date], [end_date], [event_location], [event_city], [event_province], [event_activity], [participant] FROM [event] WHERE ([event_id] = @event_id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="gv_eventlist" Name="event_id" PropertyName="SelectedValue" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <asp:SqlDataSource ID="ds_eventlist" runat="server" ConnectionString="<%$ ConnectionStrings:myTracker_DBConnectionString %>" SelectCommand="SELECT [event_id], [event_name], [event_description], [event_location], [event_activity] FROM [event] WHERE ([user_name] = @user_name)">
        <SelectParameters>
            <asp:SessionParameter Name="user_name" SessionField="username" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
