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
        string c_string;
        SqlCommand cmd;
        string sql = null;
        SqlDataReader reader;
        Control mainMenu;

        Boolean isRegistrationValid = false;
        string password = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Control mainMenu;
            // disable the menu before login
            mainMenu = Page.Master.FindControl("Menu1");
            mainMenu.Visible = false;

            success_message.Visible = false;

            global_variable gb = new global_variable();
            c_string = gb.getConnectionString();
            con = new SqlConnection(c_string);
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txt_username.Text.Trim()))      // if username is empty, set an error
            {
                lbl_username_star.Visible = true;
                lbl_error_message.Text = "Please enter user name...";
                lbl_error_message.Visible = true;
            }
            else        // if username is entered
            {
                lbl_username_star.Visible = false;

                if (String.IsNullOrEmpty(txt_password.Text.Trim()))   // check if the password is empty
                {
                    lbl_password_star.Visible = true;
                    lbl_error_message.Text = "Please enter password...";
                    lbl_error_message.Visible = true;
                }
                else    // if password is entered
                {
                    lbl_password_star.Visible = false;

                    if (!String.Equals(txt_password.Text.Trim(), txt_confirm_password.Text.Trim()))       // check if both password matches
                    {
                        lbl_confirm_password_star.Visible = true;
                        lbl_error_message.Text = "Both password and confirm password should be same...";
                        lbl_error_message.Visible = true;
                    }
                    else        // if password is valid
                    {
                        lbl_confirm_password_star.Visible = false;
                        password = txt_password.Text.Trim();
                        txt_password.Attributes.Add("value", password);
                        txt_confirm_password.Attributes.Add("value", password);
                        

                        if (String.IsNullOrEmpty(txt_firstname.Text.Trim()))       // check if first name is empty
                        {
                            lbl_firstname_star.Visible = true;
                            lbl_error_message.Text = "Please enter first name...";
                            lbl_error_message.Visible = true;
                        }
                        else        // if firstname is entered
                        {
                            lbl_firstname_star.Visible = false;

                            if (String.IsNullOrEmpty(txt_address1.Text.Trim()))       // check if address1 is empty
                            {
                                lbl_address1_star.Visible = true;
                                lbl_error_message.Text = "Please enter Address 1...";
                                lbl_error_message.Visible = true;
                            }
                            else        // if address1 is entered
                            {
                                lbl_address1_star.Visible = false;

                                if (String.IsNullOrEmpty(txt_answer.Text.Trim()))       // check if security answer is entered
                                {
                                    lbl_answer_star.Visible = true;
                                    lbl_error_message.Text = "Please enter Security Answer...";
                                    lbl_error_message.Visible = true;
                                }
                                else        // if all necessary fields are entered, proceed to registration
                                {
                                    // make all error labels invisible
                                    lbl_username_star.Visible = false;
                                    lbl_password_star.Visible = false;
                                    lbl_confirm_password_star.Visible = false;
                                    lbl_firstname_star.Visible = false;
                                    lbl_address1_star.Visible = false;
                                    lbl_answer_star.Visible = false;
                                    lbl_error_message.Visible = false;

                                    // proceed to registration
                                    lbl_error_message.Text = "Signing in...";
                                    lbl_error_message.Visible = true;

                                    // store the user input into variables
                                    string user_name = txt_username.Text.ToLower().Trim(),
                                        password = txt_password.Text.Trim(),
                                        first_name = txt_firstname.Text.Trim(),
                                        last_name = txt_lastname.Text.Trim(),
                                        gender = "Male",
                                        address1 = txt_address1.Text.Trim(),
                                        address2 = txt_address2.Text.Trim(),
                                        province = "ON",
                                        country = "Canada",
                                        security_question = null,
                                        security_answer = txt_answer.Text.Trim().ToLower();

                                    if(rb_male.Checked == true)
                                    {
                                        gender = "Male";
                                    }
                                    else
                                    {
                                        gender = "Female";
                                    }

                                    province = ddl_province.SelectedValue;
                                    security_question = ddl_question.SelectedValue;

                                    // open the connection
                                    con.Open();

                                    // check if the username is valid
                                    sql = "SELECT user_name FROM [user]";
                                    cmd = new SqlCommand(sql, con);
                                    reader = cmd.ExecuteReader();
                                    while(reader.Read())
                                    {
                                        if (reader.GetString(0) == user_name)
                                        {
                                            isRegistrationValid = false;
                                            break;
                                        }
                                        else
                                        {
                                            isRegistrationValid = true;
                                        }
                                    }

                                    // close the reader
                                    reader.Close();

                                    // if username is valid, do registration
                                    if (isRegistrationValid)
                                    {
                                        lbl_username_star.Visible = false;
                                        lbl_error_message.Text = null;
                                        lbl_error_message.Visible = false;

                                        sql = "INSERT INTO [user] VALUES(@userName, @Password, @first_name, @last_name, @gender, @address1, @address2, @province, @country, @security_question, @security_answer, @email)";      // insert statement
                                        cmd = new SqlCommand(sql, con);

                                        // set parameters
                                        cmd.Parameters.Add(new SqlParameter("userName", user_name));
                                        cmd.Parameters.Add(new SqlParameter("Password", password));
                                        cmd.Parameters.Add(new SqlParameter("first_name", first_name));
                                        cmd.Parameters.Add(new SqlParameter("last_name", last_name));
                                        cmd.Parameters.Add(new SqlParameter("gender", gender));
                                        cmd.Parameters.Add(new SqlParameter("address1", address1));
                                        cmd.Parameters.Add(new SqlParameter("address2", address2));
                                        cmd.Parameters.Add(new SqlParameter("province", province));
                                        cmd.Parameters.Add(new SqlParameter("country", country));
                                        cmd.Parameters.Add(new SqlParameter("security_question", security_question));
                                        cmd.Parameters.Add(new SqlParameter("security_answer", security_answer));
                                        cmd.Parameters.Add(new SqlParameter("email", txt_email.Text.Trim()));

                                        cmd.ExecuteNonQuery();
                                        
                                        lbl_error_message.Text = "Registration Successful. . .";
                                        lbl_error_message.Visible = true;

                                        // hide registration form and display success message
                                        form.Visible = false;
                                        success_message.Visible = true;

                                        // set session variable to login
                                        Session["username"] = txt_username.Text.ToLower().Trim();

                                        // redirect to home page after 3 seconds
                                        Response.AddHeader("REFRESH", "3;URL=user_home.aspx");
                                    }
                                    else
                                    {
                                        success_message.Visible = false;
                                        lbl_username_star.Visible = true;
                                        lbl_error_message.Text = "User name already exists. . .";
                                        lbl_error_message.Visible = true;
                                    }

                                    // close the connection
                                    con.Close();
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            // clear all text boxes
            txt_username.Text = null;
            txt_password.Text = null;
            txt_confirm_password.Text = null;
            txt_password.Attributes.Add("value", null);
            txt_confirm_password.Attributes.Add("value", null);
            txt_firstname.Text = null;
            txt_lastname.Text = null;
            txt_email.Text = null;
            rb_male.Checked = true;
            txt_address1.Text = null;
            txt_address2.Text = null;
            ddl_province.SelectedIndex = 0;
            ddl_country.SelectedIndex = 0;
            ddl_question.SelectedIndex = 0;
            txt_answer.Text = null;

            // make all error labels invisible
            lbl_username_star.Visible = false;
            lbl_password_star.Visible = false;
            lbl_confirm_password_star.Visible = false;
            lbl_firstname_star.Visible = false;
            lbl_address1_star.Visible = false;
            lbl_answer_star.Visible = false;
            lbl_error_message.Visible = false;

            // panel setting
            form.Visible = true;
            success_message.Visible = false;
        }        
    }
}