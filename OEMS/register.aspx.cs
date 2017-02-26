using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS
{
    public partial class register : System.Web.UI.Page
    {
        // declare variables required to connect to the database
        // connectionString, Command, Reader, SQLQuery

        SqlConnection con;
        SqlCommand cmd;
        string sql = null;
        SqlDataReader reader;
        Control mainMenu;

        protected void Page_Load(object sender, EventArgs e)
        {
            // disable the menu before login
            mainMenu = Page.Master.FindControl("Menu1");
            mainMenu.Visible = false;

            con = new SqlConnection("Data Source=DESKTOP-6DAVLBI\\MYCONNECTION;Initial Catalog=myTracker_DB;Integrated Security=True");
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {

        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {

        }
        
    }
}