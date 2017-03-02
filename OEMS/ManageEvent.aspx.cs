using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS
{
    public partial class ManageEvent : System.Web.UI.Page
    {
        // REQUIRED VARIABLE TO CONNECT TO DATABASE
        SqlConnection con;
        string c_string;
        Boolean isParticipantValid;
        SqlCommand cmd;
        string sql;
        SqlDataReader reader;

        Boolean isValidEventId = false;

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
            //panel_data.Enabled = false;
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_event_id.Text.Trim()))
            {
                lblResponseMessage.Text = "Please enter Event ID. . .";
                lblResponseMessage.ForeColor = System.Drawing.Color.Red;
                lblResponseMessage.Visible = true;
            }
            else
            {
                lblResponseMessage.Visible = false;
                con.Open();
                sql = "SELECT event_id FROM [event] WHERE event_id = @event_id AND user_name = @username";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("event_id", Convert.ToInt32(txt_event_id.Text.Trim())));
                cmd.Parameters.Add(new SqlParameter("username", Session["username"]));
                reader = cmd.ExecuteReader();

                // check if the entered event id is valid for logged in user
                while (reader.Read())
                {
                    if (reader.GetSqlDecimal(0) == Convert.ToDecimal(txt_event_id.Text.Trim()))
                    {
                        isValidEventId = true;
                        break;
                    }
                    else
                    {
                        isValidEventId = false;
                        lblResponseMessage.Text = "Please enter a valid Event ID. . .";
                        lblResponseMessage.ForeColor = System.Drawing.Color.Red;
                        lblResponseMessage.Visible = true;
                    }
                }

                // close the reader and connection when not in use
                reader.Close();
                con.Close();

                // if the entered event id is valid, display details
                if (isValidEventId)
                {
                    txt_event_id.ReadOnly = true;       // make event id readonly to avoid unwanted value change
                    btn_search.Visible = false;
                    panel_data.Enabled = true;

                    // perform data fetch and populate fields
                    con.Open();
                    sql = "SELECT event_name, event_description, start_date, end_date, event_location, event_city, event_province, event_activity, participant FROM [event] WHERE event_id = @event_id";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add(new SqlParameter("event_id", txt_event_id.Text.Trim()));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        txt_EventName.Text = reader.GetString(0);
                        txt_EventDescription.Text = reader.GetString(1);

                        txt_EventLocation.Text = reader.GetString(4);
                        txt_City.Text = reader.GetString(5);
                        
                        txtActivity.Text = reader.GetString(7);
                        txt_participant.Text = reader.GetString(8).ToString();
                    }
                    reader.Close();
                    con.Close();
                }
                else
                {
                    lblResponseMessage.Text = "Please enter a valid Event ID. . .";
                    lblResponseMessage.ForeColor = System.Drawing.Color.Red;
                    lblResponseMessage.Visible = true;
                    panel_data.Enabled = false;
                }
            }
        }

        protected void btnCretaeEvent_Click(object sender, EventArgs e)
        {
            // check if all necessary fields are entered
            if (String.IsNullOrEmpty(txt_EventName.Text.Trim()))
            {
                lblResponseMessage.Text = "Please enter event name. . .";
                lblResponseMessage.ForeColor = System.Drawing.Color.Red;
                lblResponseMessage.Visible = true;
                lbl_ename_star.Visible = true;
            }
            else
            {
                lblResponseMessage.Visible = false;
                lbl_ename_star.Visible = false;

                if (String.IsNullOrEmpty(txt_EventDescription.Text.Trim()))
                {
                    lblResponseMessage.Text = "Please enter event description. . .";
                    lblResponseMessage.ForeColor = System.Drawing.Color.Red;
                    lblResponseMessage.Visible = true;
                    lbl_edesc_star.Visible = true;
                }
                else
                {
                    // if all necessary fields are entered,
                    lblResponseMessage.Visible = false;
                    lbl_ename_star.Visible = false;
                    lbl_edesc_star.Visible = true;
                }
            }

            panel_data.Enabled = true;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            // set controls property
            panel_data.Enabled = false;
            txt_event_id.ReadOnly = false;
            btn_search.Visible = true;
        }
    }
}