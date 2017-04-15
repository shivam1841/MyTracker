<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Admin.Master" AutoEventWireup="true" CodeBehind="AdminUsersReport.aspx.cs" Inherits="OEMS.AdminPanel.AdminUsersReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Users Report" Font-Bold="True" Font-Names="Goudy Stout" Font-Size="18pt"></asp:Label>
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
                    (ex: search "yes" to find blocked users or vice-versa)
                </td>
            </tr>
        </table>
        <hr />
        <asp:GridView ID="gv_userReport" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="Groove" BorderWidth="5px" CellPadding="3" CellSpacing="2" DataKeyNames="user_name" DataSourceID="gv_ds_userReport_admin" PageSize="7" SelectedIndex="0" OnSelectedIndexChanged="gv_userReport_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="user_name" HeaderText="User Name" ReadOnly="True" SortExpression="user_name" />
                <asp:BoundField DataField="first_name" HeaderText="First Name" SortExpression="first_name" />
                <asp:BoundField DataField="last_name" HeaderText="Last Name" SortExpression="last_name" />
                <asp:BoundField DataField="address1" HeaderText="Address" SortExpression="address1" />
                <asp:BoundField DataField="state" HeaderText="Province" SortExpression="state" />
                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
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
        <asp:SqlDataSource ID="gv_ds_userReport_admin" runat="server" ConnectionString="<%$ ConnectionStrings:myTrackerConnectionString %>" SelectCommand="SELECT [user_name], [first_name], [last_name], [address1], [state], [email] FROM [user]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="ds_keyword" runat="server" ConnectionString="<%$ ConnectionStrings:myTrackerConnectionString %>" SelectCommand="SELECT [user_name], [first_name], [last_name], [address1], [state], [email] FROM [user] WHERE (([first_name] LIKE '%' + @first_name + '%') OR ([last_name] LIKE '%' + @last_name + '%') OR ([user_name] LIKE '%' + @user_name + '%') OR ([address1] LIKE '%' + @address1 + '%') OR ([address2] LIKE '%' + @address2 + '%') OR ([country] LIKE '%' + @country + '%') OR ([email] LIKE '%' + @email + '%') OR ([gender] LIKE '%' + @gender + '%') OR ([isBlocked] = @isBlocked))">
            <SelectParameters>
                <asp:ControlParameter ControlID="txt_keyword" Name="first_name" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="last_name" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="user_name" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="address1" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="address2" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="country" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="email" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="gender" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txt_keyword" Name="isBlocked" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <hr />
    <div align="center">
        <br />
        <asp:DetailsView ID="dv_userDetails" runat="server" Height="50px" Width="380px" AutoGenerateRows="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderStyle="Groove" BorderWidth="5px" CellPadding="5" DataKeyNames="user_name" DataSourceID="dv_ds_userDetails_admin" GridLines="Horizontal" HeaderText="User Details" ForeColor="Black" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <Fields>
                <asp:BoundField DataField="user_name" HeaderText="Username" ReadOnly="True" SortExpression="user_name" />
                <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" />
                <asp:BoundField DataField="first_name" HeaderText="First Name" SortExpression="first_name" />
                <asp:BoundField DataField="last_name" HeaderText="Last Name" SortExpression="last_name" />
                <asp:BoundField DataField="gender" HeaderText="Gender" SortExpression="gender" />
                <asp:BoundField DataField="address1" HeaderText="Address1" SortExpression="address1" />
                <asp:BoundField DataField="address2" HeaderText="Address2" SortExpression="address2" />
                <asp:BoundField DataField="state" HeaderText="Province" SortExpression="state" />
                <asp:BoundField DataField="country" HeaderText="Country" SortExpression="country" />
                <asp:BoundField DataField="security_question" HeaderText="Security Question" SortExpression="security_question" />
                <asp:BoundField DataField="security_answer" HeaderText="Security Answer" SortExpression="security_answer" />
                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                <asp:BoundField DataField="isBlocked" HeaderText="Is Blocked?" SortExpression="isBlocked" />
            </Fields>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle ForeColor="DarkSlateBlue" HorizontalAlign="Center" BackColor="PaleGoldenrod" />
        </asp:DetailsView>
        <asp:Label ID="lbl_response" runat="server" Font-Size="14pt" ForeColor="Blue" Text="User blocked successfully. . ." Visible="False"></asp:Label>
        <br />
        <asp:Button ID="btn_block" runat="server" Height="35px" OnClick="btn_block_Click" Text="Block/ Unblock User" />
        <br />
        <asp:SqlDataSource ID="dv_ds_userDetails_admin" runat="server" ConnectionString="<%$ ConnectionStrings:myTrackerConnectionString %>" SelectCommand="SELECT * FROM [user] WHERE ([user_name] = @user_name)">
            <SelectParameters>
                <asp:ControlParameter ControlID="gv_userReport" Name="user_name" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <hr />
        <asp:Button ID="btn_printPage" runat="server" Text="Print Details" OnClientClick="javascript:window.print();" Height="35px" />
    </div>
</asp:Content>
