<%@ Page Title="" Language="C#" MasterPageFile="~/Organizer.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="OEMS.CreateEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table runat="server" id="tblAddEdit" border="0" bgcolor="#fff99" style="border-left:groove; border-left-width:medium; border-right:groove; border-right-width:medium" >
            <tr>
                <td colspan="3" align="center">
                    <h2>
                        <asp:Label ID="lblEventName0" runat="server" Text="Create Event" Font-Names="Goudy Stout"></asp:Label>
                    </h2>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblResponseMessage" runat="server" Font-Size="14pt" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblEventTypeID" runat="server" Text="Event ID:"></asp:Label>
                </td>
                <td class="auto-style1" colspan="2">
                    <asp:TextBox ID="txt_eventID" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:Label ID="lblEventTypeID0" runat="server" Text="Unique ID assigned to each event" Font-Size="11pt" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEventName" runat="server" Text="Event Name">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_EventName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEventName" runat="server" ErrorMessage="Enter Event Name."
                        ControlToValidate="txt_EventName"></asp:RequiredFieldValidator>
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
                    <asp:RequiredFieldValidator ID="rfvEventDescription" runat="server" ErrorMessage="Enter Event Description."
                        ControlToValidate="txt_EventDescription"></asp:RequiredFieldValidator>
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
                    <asp:Label ID="Label1" runat="server" Text="End DateTime">
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
                    <asp:RequiredFieldValidator ID="rfvEventLocation" runat="server" ErrorMessage="Enter Event Location."
                        ControlToValidate="txt_EventLocation"></asp:RequiredFieldValidator>
                </td>
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
                    <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ErrorMessage="Enter City Name."
                        ControlToValidate="txt_City"></asp:RequiredFieldValidator>
                </td>
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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblActivity" runat="server" Text="Activity">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtActivity" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Participant">
                    </asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txt_participant" runat="server"></asp:TextBox>&nbsp;<asp:Label ID="lblEventTypeID1" runat="server" Text="(add participant by username)" Font-Size="11pt" ForeColor="Blue"></asp:Label>
                &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnCretaeEvent" runat="server" Text="Create"
                        Height="34px" Width="83px" OnClick="btnCretaeEvent_Click" />
                </td>
                <td align="center">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>