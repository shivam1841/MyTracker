using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS
{
    public partial class Organizer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if(Menu1.SelectedValue == "Home")
            {
                
            }
            if (Menu1.SelectedValue == "Create Event")
            {

            }
            if (Menu1.SelectedValue == "Event List")
            {

            }
            if (Menu1.SelectedValue == "Edit Profile")
            {

            }
            if (Menu1.SelectedValue == "Manage Event")
            {

            }
            if (Menu1.SelectedValue == "Change Password")
            {

            }
            if (Menu1.SelectedValue == "Logout")
            {
                Session["username"] = null;
                Response.Redirect("~/login.aspx");
            }
        }
    }
}