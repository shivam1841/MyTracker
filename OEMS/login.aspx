<%@ Page Title="" Language="C#" MasterPageFile="~/Organizer.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="OEMS.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Table ID="Table1" runat="server" BackColor="#E4BA1E" BorderWidth="0px" Font-Names="Forte" Font-Size="12pt" GridLines="None" Height="200px" HorizontalAlign="Center" Width="350px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Top" colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="Login" Font-Names="Forte" Font-Size="XX-Large"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Right">User Name:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="txt_username" runat="server" Width="155px"></asp:TextBox>
                    <asp:Label ID="lbl_username_star" runat="server" Font-Names="Times New Roman" Font-Italic="True" Font-Size="12pt" ForeColor="Red" Text="*" Visible="false"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Right">Password:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="txt_password" runat="server" Width="155px" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="lbl_password_star" runat="server" Font-Names="Times New Roman" Font-Italic="True" Font-Size="12pt" ForeColor="Red" Text="*" Visible="false"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Right">
                    <asp:Button ID="btn_login" runat="server" Text="Login" Width="100px" BorderStyle="Ridge" OnClick="btn_login_Click" /></asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">
                    <asp:Button ID="btn_reset" runat="server" Text="Reset" Width="100px" BorderStyle="Ridge" OnClick="btn_reset_Click" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Center">
                    <asp:HyperLink ID="link_register" runat="server" NavigateUrl="~/register.aspx" Font-Size="12">Register</asp:HyperLink>
                </asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">
                    <asp:HyperLink ID="link_forgotPassword" runat="server" NavigateUrl="~/forgot_password.aspx" Font-Size="12">Forgot Password</asp:HyperLink>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" ColumnSpan="2">
                    <asp:Label ID="lbl_error" runat="server" Font-Names="Times New Roman" Font-Italic="False" Font-Size="12pt" ForeColor="Red" Text="" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </p>
</asp:Content>
