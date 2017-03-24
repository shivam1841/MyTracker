using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS.AdminPanel
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (Menu1.SelectedValue == "Monitor Event")
            {
                Response.Redirect("~/AdminPanel/AdminEventsReport.aspx");
            }
            if (Menu1.SelectedValue == "Manage Event")
            {
                Response.Redirect("~/AdminPanel/AdminManageEvents.aspx");
            }
            if (Menu1.SelectedValue == "Monitor User")
            {
                Response.Redirect("~/AdminPanel/AdminUsersReport.aspx");
            }
            if (Menu1.SelectedValue == "Manage User")
            {
                //Response.Redirect("~/AdminPanel/.aspx");
            }
            if (Menu1.SelectedValue == "Change Password")
            {
                //Response.Redirect("~/AdminPanel/.aspx");
            }
            if (Menu1.SelectedValue == "Logout")
            {
                Session["admin"] = null;
                Response.Redirect("~/AdminPanel/AdminLogin.aspx");
            }
        }
    }
}