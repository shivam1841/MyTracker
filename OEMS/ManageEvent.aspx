<%@ Page Title="Manage Event" Language="C#" MasterPageFile="~/Organizer.Master" AutoEventWireup="true" CodeBehind="ManageEvent.aspx.cs" Inherits="OEMS.ManageEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table bgcolor="#fff99" style="border-left: groove; border-left-width: medium; border-right: groove; border-right-width: medium">
            <tr>
                <td colspan="2" align="center">
                    <h2>
                        <asp:Label ID="lblTitle" runat="server" Text="Search Event" Font-Names="Goudy Stout"></asp:Label></h2>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblResponseMessage" runat="server" Font-Size="14pt" ForeColor="Blue" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Enter Event ID: "></asp:Label>
                    <asp:TextBox ID="txt_event_id" runat="server"></asp:TextBox>
                    <asp:Button ID="btn_search" runat="server" Text="Search" OnClick="btn_search_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="panel_data" runat="server">
                        <table runat="server" id="tblAddEdit" border="0" bgcolor="#fff99">
                            <tr>
                                <td>
                                    <asp:Label ID="lblEventName" runat="server" Text="Event Name">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_EventName" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_ename_star" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblEventDescription" runat="server" Text="Description">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_EventDescription" runat="server" TextMode="MultiLine" Height="85px" Width="210px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_edesc_star" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEventStartDateTime" runat="server" Text="Start DateTime">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_Month_start" runat="server">
                                        <asp:ListItem Value="1">Jan</asp:ListItem>
                                        <asp:ListItem Value="2">Feb</asp:ListItem>
                                        <asp:ListItem Value="3">March</asp:ListItem>
                                        <asp:ListItem Value="4">April</asp:ListItem>
                                        <asp:ListItem Value="5">May</asp:ListItem>
                                        <asp:ListItem Value="6">June</asp:ListItem>
                                        <asp:ListItem Value="7">July</asp:ListItem>
                                        <asp:ListItem Value="8">Aug</asp:ListItem>
                                        <asp:ListItem Value="9">Sep</asp:ListItem>
                                        <asp:ListItem Value="10">Oct</asp:ListItem>
                                        <asp:ListItem Value="11">Nov</asp:ListItem>
                                        <asp:ListItem Value="12">Dec</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddl_Date_start" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>13</asp:ListItem>
                                        <asp:ListItem>14</asp:ListItem>
                                        <asp:ListItem>15</asp:ListItem>
                                        <asp:ListItem>16</asp:ListItem>
                                        <asp:ListItem>17</asp:ListItem>
                                        <asp:ListItem>18</asp:ListItem>
                                        <asp:ListItem>19</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>21</asp:ListItem>
                                        <asp:ListItem>22</asp:ListItem>
                                        <asp:ListItem>23</asp:ListItem>
                                        <asp:ListItem>24</asp:ListItem>
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>26</asp:ListItem>
                                        <asp:ListItem>27</asp:ListItem>
                                        <asp:ListItem>28</asp:ListItem>
                                        <asp:ListItem>29</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                        <asp:ListItem>31</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddl_Year_start" runat="server">
                                        <asp:ListItem>2017</asp:ListItem>
                                        <asp:ListItem>2018</asp:ListItem>
                                        <asp:ListItem>2019</asp:ListItem>
                                        <asp:ListItem>2020</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label3" runat="server" Text="End DateTime">
                                    </asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:DropDownList ID="ddl_Month_end" runat="server">
                                        <asp:ListItem Value="1">Jan</asp:ListItem>
                                        <asp:ListItem Value="2">Feb</asp:ListItem>
                                        <asp:ListItem Value="3">March</asp:ListItem>
                                        <asp:ListItem Value="4">April</asp:ListItem>
                                        <asp:ListItem Value="5">May</asp:ListItem>
                                        <asp:ListItem Value="6">June</asp:ListItem>
                                        <asp:ListItem Value="7">July</asp:ListItem>
                                        <asp:ListItem Value="8">Aug</asp:ListItem>
                                        <asp:ListItem Value="9">Sep</asp:ListItem>
                                        <asp:ListItem Value="10">Oct</asp:ListItem>
                                        <asp:ListItem Value="11">Nov</asp:ListItem>
                                        <asp:ListItem Value="12">Dec</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddl_Date_end" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>13</asp:ListItem>
                                        <asp:ListItem>14</asp:ListItem>
                                        <asp:ListItem>15</asp:ListItem>
                                        <asp:ListItem>16</asp:ListItem>
                                        <asp:ListItem>17</asp:ListItem>
                                        <asp:ListItem>18</asp:ListItem>
                                        <asp:ListItem>19</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>21</asp:ListItem>
                                        <asp:ListItem>22</asp:ListItem>
                                        <asp:ListItem>23</asp:ListItem>
                                        <asp:ListItem>24</asp:ListItem>
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>26</asp:ListItem>
                                        <asp:ListItem>27</asp:ListItem>
                                        <asp:ListItem>28</asp:ListItem>
                                        <asp:ListItem>29</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                        <asp:ListItem>31</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddl_Year_end" runat="server">
                                        <asp:ListItem>2017</asp:ListItem>
                                        <asp:ListItem>2018</asp:ListItem>
                                        <asp:ListItem>2019</asp:ListItem>
                                        <asp:ListItem>2020</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEventLocation" runat="server" Text="Location">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_EventLocation" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCityName" runat="server" Text="City">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_City" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblStateName" runat="server" Text="Province"></asp:Label>
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
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblActivity" runat="server" Text="Activity">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtActivity" runat="server"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Participant">
                                    </asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txt_participant" runat="server"></asp:TextBox>&nbsp;<asp:Label ID="lblEventTypeID1" runat="server" Text="(add participant by username)" Font-Size="11pt" ForeColor="Blue"></asp:Label>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="0" align="center">
                                    <asp:Button ID="btnCretaeEvent" runat="server" Text="Update"
                                        Height="34px" Width="83px" OnClick="btnCretaeEvent_Click" />
                                </td>
                                <td colspan="0" align="center">
                                    <asp:Button ID="btn_cancel" runat="server" Text="Cancel"
                                        Height="34px" Width="83px" OnClick="btn_cancel_Click" />
                                </td>
                                <td align="center">&nbsp;<asp:Button ID="btn_delete" runat="server" Text="Delete Event" BackColor="Red" Font-Bold="True" Font-Size="12pt" ForeColor="#000066" Height="35px" OnClick="btn_delete_Click" Width="130px" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
