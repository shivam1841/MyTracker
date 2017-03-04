using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS
{
    public partial class EditProfile : System.Web.UI.Page
    {
        // REQUIRED VARIABLE TO CONNECT TO DATABASE
        SqlConnection con;
        string c_string;
        Boolean isParticipantValid;
        SqlCommand cmd;
        string sql;
        SqlDataReader reader;

        string gender;

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
            
            form.Visible = true;
            success_message.Visible = false;
            panel_deleteProfile.Visible = false;

            /******************
             * POPULATE PROFILE EDIT FORM WITH THE EXISITNG VALUES *
            *******************/

            con.Open();
            sql = "SELECT first_name, last_name, gender, address1, address2, state, country, security_question, security_answer FROM [user] WHERE user_name = @user_name";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("user_name", Session["username"]));
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                txt_firstname.Text = reader.GetString(0);
                txt_lastname.Text = reader.GetString(1);
                gender = reader.GetString(2);
                if (gender == "Male")
                {
                    rb_male.Checked = true;
                }
                else
                {
                    rb_female.Checked = true;
                }
                txt_address1.Text = reader.GetString(3);
                txt_address2.Text = reader.GetString(4);
                ddl_province.Text = reader.GetString(5);
                ddl_country.Text = reader.GetString(6);
                ddl_question.Text = reader.GetString(7);
                txt_answer.Text = reader.GetString(8);
            }
            reader.Close();
            con.Close();

            // SET USER CONTROLS
            success_message.Visible = false;
            panel_deleteProfile.Visible = false;
            form.Enabled = true;
            form.Visible = true;
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            // CHECK IF ANY REQUIRED FIELDS ARE MISSING
            if (txt_firstname.Text.Trim() == "")       // check if first name is empty
            {
                lbl_firstname_star.Visible = true;
                lbl_error_message.Text = "Please enter first name...";
                lbl_error_message.Visible = true;
                form.Visible = true;
            }
            else        // if firstname is entered
            {
                lbl_firstname_star.Visible = false;

                if (txt_address1.Text.Trim() == "")       // check if address1 is empty
                {
                    lbl_address1_star.Visible = true;
                    lbl_error_message.Text = "Please enter Address 1...";
                    lbl_error_message.Visible = true;
                    form.Visible = true;
                }
                else        // if address1 is entered
                {
                    lbl_address1_star.Visible = false;

                    if (txt_answer.Text.Trim() == "")       // check if security answer is entered
                    {
                        lbl_answer_star.Visible = true;
                        lbl_error_message.Text = "Please enter Security Answer...";
                        lbl_error_message.Visible = true;
                        form.Visible = true;
                    }
                    else        // if all necessary fields are entered, proceed to registration
                    {
                        // make all error labels invisible
                        lbl_firstname_star.Visible = false;
                        lbl_address1_star.Visible = false;
                        lbl_answer_star.Visible = false;
                        lbl_error_message.Visible = false;


                        /*******************
                         * IF ALL REQUIRED FIELDS ARE ENTERED
                         * ****************************/

                        if (rb_male.Checked == true)
                        {
                            gender = "Male";
                        }
                        else
                        {
                            gender = "Female";
                        }

                        // UPDATE RECORD

                        con.Open();
                        sql = "UPDATE [user] SET first_name = @first_name, last_name = @last_name, gender = @gender, address1 = @address1, address2 = @address2, state = @province, country = @country, security_question = @security_question, security_answer = @security_answer WHERE user_name = @username";
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.Add(new SqlParameter("first_name", txt_firstname.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("last_name", txt_lastname.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("gender", gender));
                        cmd.Parameters.Add(new SqlParameter("address1", txt_address1.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("address2", txt_address2.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("province", ddl_province.SelectedValue));
                        cmd.Parameters.Add(new SqlParameter("country", ddl_country.SelectedValue));
                        cmd.Parameters.Add(new SqlParameter("security_question", ddl_question.SelectedValue));
                        cmd.Parameters.Add(new SqlParameter("security_answer", txt_answer.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("username", Session["username"]));
                        cmd.ExecuteNonQuery();
                        con.Close();

                        lbl_error_message.Text = "Profile Updated. . .";
                        lbl_error_message.Visible = true;

                        //SET USER CONTROLS
                        form.Enabled = true;
                        form.Visible = true;
                        panel_deleteProfile.Visible = false;
                        success_message.Visible = false;
                    }
                }
            }
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            panel_deleteProfile.Visible = true;
            form.Visible = false;
        }

        protected void btn_verify_password_for_delete_profile_Click(object sender, EventArgs e)
        {
            if (txt_password_for_delete_profile.Text.Trim() != "")
            {
                lbl_response_delete_profile.Text = "";
                lbl_response_delete_profile.Visible = false;

                con.Open();
                sql = "SELECT password FROM [user] WHERE user_name = @username";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("username", Session["username"]));
                string password_DB = cmd.ExecuteScalar().ToString();

                if (password_DB == txt_password_for_delete_profile.Text.Trim())
                {
                    lbl_response_delete_profile.Text = "";
                    lbl_response_delete_profile.Visible = false;

                    panel_deleteProfile.Visible = false;
                    success_message.Visible = true;

                    Session["username"] = null;

                    // redirect to home page after 3 seconds
                    Response.AddHeader("REFRESH", "3;URL=login.aspx");

                }
                else
                {
                    panel_deleteProfile.Visible = true;
                    lbl_response_delete_profile.Text = "Incorrect password. . .";
                    lbl_response_delete_profile.Visible = true;
                }
                con.Close();
            }
            else
            {
                panel_deleteProfile.Visible = true;
                lbl_response_delete_profile.Text = "Please enter password. . .";
                lbl_response_delete_profile.Visible = true;
            }
        }
    }
}