using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS
{
    public partial class CreateEvent : System.Web.UI.Page
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


                // webpage code
                con.Open();
                sql = "SELECT max(event_id) FROM [event]";
                cmd = new SqlCommand(sql, con);
                string e_id = cmd.ExecuteScalar().ToString();
                int event_id = Convert.ToInt32(e_id) + 1;
                con.Close();

                txt_eventID.Text = event_id.ToString();
            }
        }

        protected void btnCretaeEvent_Click(object sender, EventArgs e)
        {
            if (! (String.IsNullOrEmpty(txt_EventName.Text.Trim()) || String.IsNullOrEmpty(txt_EventDescription.Text.Trim()) || String.IsNullOrEmpty(txt_EventLocation.Text.Trim()) || String.IsNullOrEmpty(txt_City.Text.Trim())))
            {
                string event_start = ddl_Month_start.SelectedValue + "/" + ddl_Date_start.SelectedValue + "/" + ddl_Year_start.SelectedValue + " 23:59:59.00";
                DateTime e_start = Convert.ToDateTime(event_start);

                string event_end = ddl_Month_end.SelectedValue + "/" + ddl_Date_end.SelectedValue + "/" + ddl_Year_end.SelectedValue + " 23:59:59.00";
                DateTime e_end = Convert.ToDateTime(event_end);

                string user = Session["username"].ToString();

                // if user enters participant
                if (! String.IsNullOrEmpty(txt_participant.Text.Trim()))
                {
                    // if participant is entered, create event with participant

                    // check if participant is valid
                    con.Open();
                    sql = "SELECT user_name FROM [user]";               // define sql query
                    cmd = new SqlCommand(sql, con);                     // prepare sql command
                    reader = cmd.ExecuteReader();                       // assign SQLCommand to the reader

                    //
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == txt_participant.Text.ToLower().Trim())
                        {
                            isParticipantValid = true;
                            break;
                        }
                        else
                        {
                            isParticipantValid = false;
                            lblResponseMessage.Text = "Please verify the user name of participant";
                            lblResponseMessage.ForeColor = System.Drawing.Color.Red;
                            lblResponseMessage.Visible = true;
                        }
                    }

                    // close reader and connection while not in use
                    reader.Close();
                    con.Close();

                    // if participant is valid, create event
                    if (isParticipantValid)
                    {
                        // create event
                        con.Open();
                        sql = "INSERT INTO [event] VALUES (@event_id, @event_name, @event_desc, @event_start, @event_end, @location, @city, @province, @activity, @username, @participant)";
                        cmd = new SqlCommand(sql, con);

                        // set parameters
                        cmd.Parameters.Add(new SqlParameter("event_id", txt_eventID.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("event_name", txt_EventName.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("event_desc", txt_EventDescription.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("event_start", e_start));
                        cmd.Parameters.Add(new SqlParameter("event_end", e_end));
                        cmd.Parameters.Add(new SqlParameter("location", txt_EventLocation.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("city", txt_City.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("province", ddl_province.SelectedValue));
                        cmd.Parameters.Add(new SqlParameter("activity", txtActivity.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("username", user.ToLower().Trim()));
                        cmd.Parameters.Add(new SqlParameter("participant", txt_participant.Text.ToLower().Trim()));

                        cmd.ExecuteNonQuery();
                        lblResponseMessage.Text = "Event created successfully. . .";
                        lblResponseMessage.ForeColor = System.Drawing.Color.Blue;
                        lblResponseMessage.Visible = true;
                        con.Close();

                        // create participant
                        con.Open();
                        sql = "INSERT INTO [event_participants] VALUES (@event_id, @participant, @assigned_by)";
                        cmd = new SqlCommand(sql, con);

                        // set parameters
                        cmd.Parameters.Add(new SqlParameter("event_id", txt_eventID.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("participant", txt_participant.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("assigned_by", Session["username"]));

                        cmd.ExecuteNonQuery();
                        lblResponseMessage.Text = "Event created successfully. . .";
                        lblResponseMessage.ForeColor = System.Drawing.Color.Blue;
                        lblResponseMessage.Visible = true;
                        con.Close();

                        // update event unique ID to avoid crash
                        con.Open();
                        sql = "SELECT max(event_id) FROM [event]";
                        cmd = new SqlCommand(sql, con);
                        string e_id = cmd.ExecuteScalar().ToString();
                        int event_id = Convert.ToInt32(e_id) + 1;
                        con.Close();

                        txt_eventID.Text = event_id.ToString();

                        // clear all textboxes
                        txt_EventName.Text = null;
                        txt_EventDescription.Text = null;
                        ddl_Month_start.SelectedIndex = 0;
                        ddl_Date_start.SelectedIndex = 0;
                        ddl_Year_start.SelectedIndex = 0;
                        ddl_Month_end.SelectedIndex = 0;
                        ddl_Date_end.SelectedIndex = 0;
                        ddl_Year_end.SelectedIndex = 0;
                        txt_City.Text = null;
                        ddl_province.SelectedIndex = 0;
                        txt_EventLocation.Text = null;
                        txtActivity.Text = null;
                        txt_participant.Text = null;

                    }
                    else
                    {
                        lblResponseMessage.Text = "Please verify the user name of participant";
                        lblResponseMessage.ForeColor = System.Drawing.Color.Red;
                        lblResponseMessage.Visible = true;
                    }
                }
                else
                {
                    // if participant is not entered, create event without participant
                    con.Open();
                    sql = "INSERT INTO [event] VALUES (@event_id, @event_name, @event_desc, @event_start, @event_end, @location, @city, @province, @activity, @username, @participant)";
                    cmd = new SqlCommand(sql, con);

                    // set parameters
                    cmd.Parameters.Add(new SqlParameter("event_id", txt_eventID.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("event_name", txt_EventName.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("event_desc", txt_EventDescription.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("event_start", event_start));
                    cmd.Parameters.Add(new SqlParameter("event_end", event_end));
                    cmd.Parameters.Add(new SqlParameter("location", txt_EventLocation.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("city", txt_City.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("province", ddl_province.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("activity", txtActivity.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("username", Session["username"]));
                    cmd.Parameters.Add(new SqlParameter("participant", txt_participant.Text.ToLower().Trim()));

                    cmd.ExecuteNonQuery();
                    lblResponseMessage.Text = "Event created successfully. . .";
                    lblResponseMessage.ForeColor = System.Drawing.Color.Blue;
                    lblResponseMessage.Visible = true;
                    con.Close();

                    // update event unique ID to avoid crash
                    con.Open();
                    sql = "SELECT max(event_id) FROM [event]";
                    cmd = new SqlCommand(sql, con);
                    string e_id = cmd.ExecuteScalar().ToString();
                    int event_id = Convert.ToInt32(e_id) + 1;
                    con.Close();

                    txt_eventID.Text = event_id.ToString();

                    // clear all textboxes
                    txt_EventName.Text = null;
                    txt_EventDescription.Text = null;
                    ddl_Month_start.SelectedIndex = 0;
                    ddl_Date_start.SelectedIndex = 0;
                    ddl_Year_start.SelectedIndex = 0;
                    ddl_Month_end.SelectedIndex = 0;
                    ddl_Date_end.SelectedIndex = 0;
                    ddl_Year_end.SelectedIndex = 0;
                    txt_City.Text = null;
                    ddl_province.SelectedIndex = 0;
                    txt_EventLocation.Text = null;
                    txtActivity.Text = null;
                    txt_participant.Text = null;                }
            }
            else
            {
                lblResponseMessage.Text = "Something went wrong. . .";
                lblResponseMessage.ForeColor = System.Drawing.Color.Red;
                lblResponseMessage.Visible = true;
            }
        }
    }
}