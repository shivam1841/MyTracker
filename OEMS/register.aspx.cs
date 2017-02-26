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

        string password = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            // disable the menu before login
            mainMenu = Page.Master.FindControl("Menu1");
            mainMenu.Visible = false;
            
            con = new SqlConnection("Data Source=DESKTOP-6DAVLBI\\MYCONNECTION;Initial Catalog=myTracker_DB;Integrated Security=True");
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

                                    // registration
                                    lbl_error_message.Text = "success...";
                                    lbl_error_message.Visible = true;
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
        }
        
    }
}