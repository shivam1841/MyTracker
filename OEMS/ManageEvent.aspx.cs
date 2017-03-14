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
            try
            {
                if (String.IsNullOrEmpty(Request.QueryString["event_id"].ToString()))
                {
                    txt_event_id.Text = txt_event_id.Text.Trim();
                }
                else
                {
                    txt_event_id.Text = Request.QueryString["event_id"].ToString();
                }
            }
            catch (Exception)
            {
                txt_event_id.Text = txt_event_id.Text.Trim();
            }
            panel_data.Visible = false;
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
                    panel_data.Visible = true;
                    lblTitle.Text = "Update Event";

                    // declare a variable to hold date and province data
                    DateTime start_date;
                    DateTime end_date;
                    string month, day;

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

                        start_date = reader.GetDateTime(2);

                        /* 
                         * extract year from date
                         */
                        ddl_Year_start.Text = start_date.ToString().Substring(0, 4);

                        /* 
                         * extract month from date
                         */
                        month = start_date.ToString().Substring(5, 2);
                        if (month == "01")
                        {
                            ddl_Month_start.SelectedIndex = 0;
                        }
                        else if (month == "02")
                        {
                            ddl_Month_start.SelectedIndex = 1;
                        }
                        else if (month == "03")
                        {
                            ddl_Month_start.SelectedIndex = 2;
                        }
                        else if (month == "04")
                        {
                            ddl_Month_start.SelectedIndex = 3;
                        }
                        else if (month == "05")
                        {
                            ddl_Month_start.SelectedIndex = 4;
                        }
                        else if (month == "06")
                        {
                            ddl_Month_start.SelectedIndex = 5;
                        }
                        else if (month == "07")
                        {
                            ddl_Month_start.SelectedIndex = 6;
                        }
                        else if (month == "08")
                        {
                            ddl_Month_start.SelectedIndex = 7;
                        }
                        else if (month == "09")
                        {
                            ddl_Month_start.SelectedIndex = 8;
                        }
                        else if (month == "10")
                        {
                            ddl_Month_start.SelectedIndex = 9;
                        }
                        else if (month == "11")
                        {
                            ddl_Month_start.SelectedIndex = 10;
                        }
                        else if (month == "12")
                        {
                            ddl_Month_start.SelectedIndex = 11;
                        }

                        /* 
                         * extract day from date
                         */
                        day = start_date.ToString().Substring(8, 2);
                        if (day == "01")
                        {
                            ddl_Date_start.SelectedIndex = 0;
                        }
                        else if (day == "02")
                        {
                            ddl_Date_start.SelectedIndex = 1;
                        }
                        else if (day == "03")
                        {
                            ddl_Date_start.SelectedIndex = 2;
                        }
                        else if (day == "04")
                        {
                            ddl_Date_start.SelectedIndex = 3;
                        }
                        else if (day == "05")
                        {
                            ddl_Date_start.SelectedIndex = 4;
                        }
                        else if (day == "06")
                        {
                            ddl_Date_start.SelectedIndex = 5;
                        }
                        else if (day == "07")
                        {
                            ddl_Date_start.SelectedIndex = 6;
                        }
                        else if (day == "08")
                        {
                            ddl_Date_start.SelectedIndex = 7;
                        }
                        else if (day == "09")
                        {
                            ddl_Date_start.SelectedIndex = 8;
                        }
                        else
                        {
                            ddl_Date_start.Text = start_date.ToString().Substring(8, 2);
                        }

                        end_date = reader.GetDateTime(3);

                        /* 
                         * extract year from date
                         */
                        ddl_Year_end.Text = end_date.ToString().Substring(0, 4);

                        /* 
                         * extract month from date
                         */
                        month = end_date.ToString().Substring(5, 2);

                        if (month == "01")
                        {
                            ddl_Month_end.SelectedIndex = 0;
                        }
                        else if (month == "02")
                        {
                            ddl_Month_end.SelectedIndex = 1;
                        }
                        else if (month == "03")
                        {
                            ddl_Month_end.SelectedIndex = 2;
                        }
                        else if (month == "04")
                        {
                            ddl_Month_end.SelectedIndex = 3;
                        }
                        else if (month == "05")
                        {
                            ddl_Month_end.SelectedIndex = 4;
                        }
                        else if (month == "06")
                        {
                            ddl_Month_end.SelectedIndex = 5;
                        }
                        else if (month == "07")
                        {
                            ddl_Month_end.SelectedIndex = 6;
                        }
                        else if (month == "08")
                        {
                            ddl_Month_end.SelectedIndex = 7;
                        }
                        else if (month == "09")
                        {
                            ddl_Month_end.SelectedIndex = 8;
                        }
                        else if (month == "10")
                        {
                            ddl_Month_end.SelectedIndex = 9;
                        }
                        else if (month == "11")
                        {
                            ddl_Month_end.SelectedIndex = 10;
                        }
                        else if (month == "12")
                        {
                            ddl_Month_end.SelectedIndex = 11;
                        }

                        /* 
                         * extract day from date
                         */
                        day = end_date.ToString().Substring(8, 2);
                        if (day == "01")
                        {
                            ddl_Date_end.SelectedIndex = 0;
                        }
                        else if (day == "02")
                        {
                            ddl_Date_end.SelectedIndex = 1;
                        }
                        else if (day == "03")
                        {
                            ddl_Date_end.SelectedIndex = 2;
                        }
                        else if (day == "04")
                        {
                            ddl_Date_end.SelectedIndex = 3;
                        }
                        else if (day == "05")
                        {
                            ddl_Date_end.SelectedIndex = 4;
                        }
                        else if (day == "06")
                        {
                            ddl_Date_end.SelectedIndex = 5;
                        }
                        else if (day == "07")
                        {
                            ddl_Date_end.SelectedIndex = 6;
                        }
                        else if (day == "08")
                        {
                            ddl_Date_end.SelectedIndex = 7;
                        }
                        else if (day == "09")
                        {
                            ddl_Date_end.SelectedIndex = 8;
                        }
                        else
                        {
                            ddl_Date_end.Text = end_date.ToString().Substring(8, 2);
                        }

                        txt_EventLocation.Text = reader.GetString(4);
                        txt_City.Text = reader.GetString(5);
                        ddl_province.Text = reader.GetString(6);
                        txtActivity.Text = reader.GetString(7);
                        txt_participant.Text = reader.GetString(8).ToString();

                        panel_data.Enabled = true;
                    }

                    reader.Close();
                    con.Close();
                }
                else
                {
                    lblResponseMessage.Text = "Please enter a valid Event ID. . .";
                    lblResponseMessage.ForeColor = System.Drawing.Color.Red;
                    lblResponseMessage.Visible = true;
                    panel_data.Visible = false;
                }
            }
        }


        /* 
         * udpate event details here
         * */

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
                    // if all necessary fields are entered, perform updation

                    lblResponseMessage.Visible = false;
                    lbl_ename_star.Visible = false;
                    lbl_edesc_star.Visible = false;

                    // create DateTime format from the dropdown selection
                    string event_start = ddl_Month_start.SelectedValue + "/" + ddl_Date_start.SelectedValue + "/" + ddl_Year_start.SelectedValue + " 00:00:00.00";
                    DateTime e_start = Convert.ToDateTime(event_start);

                    string event_end = ddl_Month_end.SelectedValue + "/" + ddl_Date_end.SelectedValue + "/" + ddl_Year_end.SelectedValue + " 00:00:00.00";
                    DateTime e_end = Convert.ToDateTime(event_end);

                    /* 
                     * UPDATE VALIDATION
                     * */

                    // if user enters participant
                    if (!String.IsNullOrEmpty(txt_participant.Text.Trim()))
                    {
                        // if participant is entered, update event with participant

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
                            // update event
                            con.Open();
                            sql = "UPDATE [event] SET event_name = @event_name, event_description = @event_description, start_date = @start_date, end_date = @end_date, event_location = @event_location, event_city = @event_city, event_province = @event_province, event_activity = @event_activity, participant = @participant WHERE event_id = @eventID";
                            cmd = new SqlCommand(sql, con);

                            // set parameters
                            cmd.Parameters.Add(new SqlParameter("eventID", txt_event_id.Text.Trim()));
                            cmd.Parameters.Add(new SqlParameter("event_name", txt_EventName.Text.Trim()));
                            cmd.Parameters.Add(new SqlParameter("event_description", txt_EventDescription.Text.Trim()));
                            cmd.Parameters.Add(new SqlParameter("start_date", e_start));
                            cmd.Parameters.Add(new SqlParameter("end_date", e_end));
                            cmd.Parameters.Add(new SqlParameter("event_location", txt_EventLocation.Text.Trim()));
                            cmd.Parameters.Add(new SqlParameter("event_city", txt_City.Text.Trim()));
                            cmd.Parameters.Add(new SqlParameter("event_province", ddl_province.SelectedValue));
                            cmd.Parameters.Add(new SqlParameter("event_activity", txtActivity.Text.Trim()));
                            cmd.Parameters.Add(new SqlParameter("participant", txt_participant.Text.ToLower().Trim()));

                            cmd.ExecuteNonQuery();
                            lblResponseMessage.Text = "Event updated successfully. . .";
                            lblResponseMessage.ForeColor = System.Drawing.Color.Blue;
                            lblResponseMessage.Visible = true;
                            con.Close();

                            // update participant
                            con.Open();
                            sql = "UPDATE [event_participants] SET user_name = @participant WHERE event_id = @event_id; IF @@ROWCOUNT = 0 INSERT INTO [event_participants] VALUES(@event_id, @participant, @assigned_by);";
                            cmd = new SqlCommand(sql, con);

                            // set parameters
                            cmd.Parameters.Add(new SqlParameter("event_id", txt_event_id.Text.Trim()));
                            cmd.Parameters.Add(new SqlParameter("participant", txt_participant.Text.Trim()));
                            cmd.Parameters.Add(new SqlParameter("assigned_by", Session["username"]));

                            cmd.ExecuteNonQuery();
                            lblResponseMessage.Text = "Event updated successfully. . .";
                            lblResponseMessage.ForeColor = System.Drawing.Color.Blue;
                            lblResponseMessage.Visible = true;
                            con.Close();

                            // set user controls
                            panel_data.Enabled = false;
                            btn_search.Visible = true;

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
                        sql = "UPDATE [event] SET event_name = @event_name, event_description = @event_description, start_date = @start_date, end_date = @end_date, event_location = @event_location, event_city = @event_city, event_province = @event_province, event_activity = @event_activity, participant = @participant WHERE event_id = @event_id";
                        cmd = new SqlCommand(sql, con);

                        // set parameters
                        cmd.Parameters.Add(new SqlParameter("event_id", txt_event_id.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("event_name", txt_EventName.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("event_description", txt_EventDescription.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("start_date", e_start));
                        cmd.Parameters.Add(new SqlParameter("end_date", e_end));
                        cmd.Parameters.Add(new SqlParameter("event_location", txt_EventLocation.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("event_city", txt_City.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("event_province", ddl_province.SelectedValue));
                        cmd.Parameters.Add(new SqlParameter("event_activity", txtActivity.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("participant", txt_participant.Text.ToLower().Trim()));

                        cmd.ExecuteNonQuery();
                        lblResponseMessage.Text = "Event updated successfully. . .";
                        lblResponseMessage.ForeColor = System.Drawing.Color.Blue;
                        lblResponseMessage.Visible = true;
                        con.Close();


                        // delete participant's entry if participant is not entered
                        con.Open();
                        sql = "DELETE FROM [event_participants] WHERE event_id = @event_id";
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.Add(new SqlParameter("event_id", txt_event_id.Text.Trim()));
                        cmd.ExecuteNonQuery();
                        con.Close();

                        // set user controls
                        panel_data.Enabled = false;
                        btn_search.Visible = true;

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
                }
            }

            panel_data.Visible = true;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            // set controls property
            panel_data.Visible = false;
            txt_event_id.ReadOnly = false;
            btn_search.Visible = true;
            lblResponseMessage.Visible = false;
            lbl_ename_star.Visible = false;
            lbl_edesc_star.Visible = false;
            lblTitle.Text = "Search Event";

            // clear all fields
            txt_EventName.Text = null;
            txt_EventDescription.Text = null;
            ddl_Date_start.SelectedIndex = 0;
            ddl_Month_start.SelectedIndex = 0;
            ddl_Year_start.SelectedIndex = 0;
            ddl_Date_end.SelectedIndex = 0;
            ddl_Month_end.SelectedIndex = 0;
            ddl_Year_end.SelectedIndex = 0;
            txt_EventLocation.Text = null;
            txt_City.Text = null;
            ddl_province.SelectedIndex = 0;
            txtActivity.Text = null;
            txt_participant.Text = null;
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            // event_participants delete user participated event
            con.Open();
            sql = "DELETE FROM [event_participants] WHERE event_id = @event_id";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("event_id", txt_event_id.Text.Trim()));
            cmd.ExecuteNonQuery();
            con.Close();


            // EVENT
            con.Open();
            sql = "DELETE FROM [event] WHERE event_id = @event_id";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("event_id", txt_event_id.Text.Trim()));
            cmd.ExecuteNonQuery();
            con.Close();

            // SET USER CONTROL
            lblResponseMessage.Text = "Event Deleted. . .";
            lblResponseMessage.Visible = true;
            panel_data.Enabled = false;
            txt_event_id.ReadOnly = false;
            btn_search.Visible = true;
            lblTitle.Text = "Search Event";
        }
    }
}