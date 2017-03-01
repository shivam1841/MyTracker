using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS
{
    public partial class forgot_password : System.Web.UI.Page
    {
        Control mainMenu;

        protected void Page_Load(object sender, EventArgs e)
        {
            // disable the menu before login
            mainMenu = Page.Master.FindControl("Menu1");
            mainMenu.Visible = false;
        }
    }
}