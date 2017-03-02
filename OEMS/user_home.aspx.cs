using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS
{
    public partial class user_home : System.Web.UI.Page
    {
        // REQUIRED VARIABLE TO CONNECT TO DATABASE
        SqlConnection con;
        string c_string;
        SqlCommand cmd;
        string sql;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //******************************COPY FOLLOWING CODE IN EVERY PAGE LOAD EVENT************//
            if (Session["username"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                // variable to fetch data from database
                SqlDataAdapter da;
                DataSet ds;

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
                lbl_welcome_user.Text = "Welcome, " + username;//"Welcome, " + Session["username"];
                //******************************COPY ABOVE CODE IN EVERY PAGE LOAD EVENT************//


                // webpage code

                // upcoming events
                con.Open();
                sql = "SELECT [event_id] as 'ID', [event_name] as 'Name', [start_date] as 'Start Date', [end_date] as 'End Date', [event_location] as 'Location', [event_activity] as 'Activity', [participant] as 'Participant' FROM [event] WHERE ([user_name] = @user_name) AND ([start_date] >= SYSDATETIME())";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("user_name", Session["username"]));
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "dataSet");

                if (ds.Tables.Count > 0)
                {
                    gv_upcoming_event.DataSource = ds;
                    gv_upcoming_event.DataBind();
                }
                con.Close();

                // set the title for upcoming event
                if (gv_upcoming_event.Rows.Count == 0)
                {
                    lbl_upcoming.Text = "No Upcoming Events Found";
                }
                else
                {
                    lbl_upcoming.Text = "Upcoming Events";
                }

                // ongoing event
                con.Open();
                sql = "SELECT [event_id] as 'ID', [event_name] as 'Name', [start_date] as 'Start Date', [end_date] as 'End Date', [event_location] as 'Location', [event_activity] as 'Activity', [participant] as 'Participant' FROM [event] WHERE ([user_name] = @user_name) AND ([start_date] <= SYSDATETIME()) AND ([end_date] >= SYSDATETIME())";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("user_name", Session["username"]));
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "dataSet");

                if (ds.Tables.Count > 0)
                {
                    gv_ongoing_event.DataSource = ds;
                    gv_ongoing_event.DataBind();
                }
                con.Close();

                // set the title for ongoing event
                if (gv_ongoing_event.Rows.Count == 0)
                {
                    lbl_ongoing.Text = "No Ongoing Events Found";
                }
                else
                {
                    lbl_ongoing.Text = "Ongoing Events";
                }

                // past events
                con.Open();
                sql = "SELECT [event_id] as 'ID', [event_name] as 'Name', [start_date] as 'Start Date', [end_date] as 'End Date', [event_location] as 'Location', [event_activity] as 'Activity', [participant] as 'Participant' FROM [event] WHERE ([user_name] = @user_name) AND ([end_date] < SYSDATETIME())";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("user_name", Session["username"]));
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "dataSet");

                if (ds.Tables.Count > 0)
                {
                    gv_past_event.DataSource = ds;
                    gv_past_event.DataBind();
                }
                con.Close();

                // set the title for past events
                if (gv_past_event.Rows.Count == 0)
                {
                    lbl_past.Text = "No Past Events Found";
                }
                else
                {
                    lbl_past.Text = "Past Events";
                }
            }
        }
    }
}