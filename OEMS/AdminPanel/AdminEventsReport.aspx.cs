using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS.AdminPanel
{
    public partial class AdminEventsReport : System.Web.UI.Page
    {
        // REQUIRED VARIABLE TO CONNECT TO DATABASE
        SqlConnection con;
        string c_string;
        Boolean isParticipantValid;
        SqlCommand cmd;
        string sql;
        SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            //******************************COPY FOLLOWING CODE IN EVERY PAGE LOAD EVENT************//
            if (Session["admin"] == null)
            {
                Response.Redirect("~/AdminPanel/AdminLogin.aspx");
            }
            else
            {
                // // SET VARIABLES FOR DATABASE CONNECTIVITY
                global_variable gb = new global_variable();
                c_string = gb.getConnectionString();
                con = new SqlConnection(c_string);

                // set the username at top left corner
                Label lbl_welcome_user = this.Master.FindControl("lbl_welcome_user") as Label;
                lbl_welcome_user.Text = "Welcome Admin";
                //******************************COPY ABOVE CODE IN EVERY PAGE LOAD EVENT************//
            }

            // webpage code
        }

        protected void gv_eventlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_showMap_Click(object sender, EventArgs e)
        {
            // FETCH THE LOCATION FROM DETAILS VIEW
            string location = dv_event_details.Rows[5].Cells[1].Text.ToString();
            string city = dv_event_details.Rows[6].Cells[1].Text.ToString();
            string province = dv_event_details.Rows[7].Cells[1].Text.ToString();
            string address = location + "," + city + "," + province;
            // REDIRECT TO THE MAP WITH THE ADDRESS PARAMETER
            Response.Redirect("~/map.html?address=" + address);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            gv_eventlist.DataSourceID = "ds_keyword";
            gv_eventlist.DataBind();
        }

        protected void btn_clearSearch_Click(object sender, EventArgs e)
        {
            gv_eventlist.DataSourceID = "gv_ds_cloudDB";
            gv_eventlist.DataBind();
            txt_keyword.Text = "";
        }
    }
}