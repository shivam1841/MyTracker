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
        public void setWelcomeUserMessage(string message)
        {
                lbl_welcome_user.Visible = true;
                lbl_welcome_user.Text = message;
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if(Menu1.SelectedValue == "Home")
            {
                Response.Redirect("~/user_home.aspx");
            }
            if (Menu1.SelectedValue == "Create Event")
            {
                Response.Redirect("~/CreateEvent.aspx");
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