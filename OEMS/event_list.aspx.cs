using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS
{
    public partial class event_list : System.Web.UI.Page
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
            if (Session["username"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                // fetch user's first name
                global_variable gb = new global_variable();
                c_string = gb.getConnectionString();
                con = new SqlConnection(c_string);

                con.Open();
                sql = "SELECT first_name FROM [user] WHERE user_name = @username";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("username", Session["username"]));
                string username = cmd.ExecuteScalar().ToString();
                con.Close();

                // set the username at top left corner
                Label lbl_welcome_user = this.Master.FindControl("lbl_welcome_user") as Label;
                lbl_welcome_user.Text = "Welcome, " + username;     //"Welcome, " + Session["username"];
                //******************************COPY ABOVE CODE IN EVERY PAGE LOAD EVENT************//
            }

            // webpage code
            if(gv_eventlist.Rows.Count == 0)
            {
                Label2.Text = "No events to display";
                dv_event_details.Visible = false;
                Label3.Visible = false;
                HyperLink1.Visible = false;
            }
            else
            {
                Label2.Text = "(Select event to view detailed information)";
                dv_event_details.Visible = true;
                Label3.Visible = true;
                HyperLink1.Visible = true;

                // ASSIGN SELECTED VALUE FROM GRIDVIEW
                string event_id = gv_eventlist.SelectedValue.ToString();
                HyperLink1.NavigateUrl = "ManageEvent.aspx?event_id=" + event_id;         // add parameter to the redirecting link
            }
        }

        protected void gv_eventlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ASSIGN SELECTED VALUE FROM GRIDVIEW
            string event_id = gv_eventlist.SelectedValue.ToString();
            HyperLink1.NavigateUrl = "ManageEvent.aspx?event_id=" + event_id;         // add parameter to the redirecting link
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
            
            // set the title
            if (gv_eventlist.Rows.Count == 0)
            {
                Label2.Text = "No events to display";
                dv_event_details.Visible = false;
                Label3.Visible = false;
                HyperLink1.Visible = false;
            }
            else
            {
                Label2.Text = "(Select event to view detailed information)";
                dv_event_details.Visible = true;
                Label3.Visible = true;
                HyperLink1.Visible = true;

                string event_id;
                // ASSIGN SELECTED VALUE FROM GRIDVIEW
                try
                {
                    event_id = gv_eventlist.SelectedValue.ToString();
                }
                catch (Exception)
                {
                    event_id = "0";
                }

                HyperLink1.NavigateUrl = "ManageEvent.aspx?event_id=" + event_id;
            }
        }

        protected void btn_clearSearch_Click(object sender, EventArgs e)
        {
            gv_eventlist.DataSourceID = "gv_ds_cloudDB";
            gv_eventlist.DataBind();
            txt_keyword.Text = "";
        }
    }
}