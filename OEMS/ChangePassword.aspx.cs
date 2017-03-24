using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        // REQUIRED VARIABLE TO CONNECT TO DATABASE
        SqlConnection con;
        string c_string;
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

            //  WEBPAGE CODE
        }

        protected void btn_changePassword_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_oldPassword.Text))
            {
                lbl_response.Text = "Please enter old password. . .";
                lbl_response.ForeColor = System.Drawing.Color.Red;
                lbl_response.Visible = true;
                lbl_oldPassword_star.Visible = true;
            }
            else
            {
                lbl_response.Visible = false;
                lbl_oldPassword_star.Visible = false;

                string oldPassword;
                con.Open();
                sql = "SELECT [password] FROM [user] WHERE [user_name] = @username";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("username", Session["username"]));
                oldPassword = cmd.ExecuteScalar().ToString();
                con.Close();

                if (String.Equals(oldPassword, txt_oldPassword.Text.Trim()))
                {
                    /*
                     * IF CURRENT PASSWORD IS VALID, UPDATE NEW PASSWORD
                     */
                    if (String.IsNullOrEmpty(txt_newPassword.Text.Trim()))
                    {
                        lbl_response.Text = "Please enter new password. . .";
                        lbl_response.ForeColor = System.Drawing.Color.Red;
                        lbl_response.Visible = true;
                        lbl_newPassword_star.Visible = true;
                    }
                    else
                    {
                        lbl_response.Visible = false;
                        lbl_newPassword_star.Visible = false;

                        if (String.Equals(txt_newPassword.Text.Trim(), txt_confirmPassword.Text.Trim()))
                        {
                            lbl_response.Visible = false;
                            lbl_confirmPassword_star.Visible = false;
                            lbl_newPassword_star.Visible = false;

                            try
                            {
                                con.Open();
                                sql = "UPDATE [user] SET [password] = @password WHERE [user_name] = @username";
                                cmd = new SqlCommand(sql, con);
                                cmd.Parameters.Add(new SqlParameter("password", txt_newPassword.Text.Trim()));
                                cmd.Parameters.Add(new SqlParameter("username", Session["username"]));
                                cmd.ExecuteNonQuery();
                                con.Close();

                                lbl_response.Text = "Password Updated successfully. . .";
                                lbl_response.ForeColor = System.Drawing.Color.Blue;
                                lbl_response.Visible = true;
                            }
                            catch (Exception)
                            {
                                lbl_response.Text = "Something went wrong, Please try again after sometime. . .";
                                lbl_response.ForeColor = System.Drawing.Color.Red;
                                lbl_response.Visible = true;
                            }
                            
                        }
                        else
                        {
                            lbl_response.Text = "Both new password and confirm password should match. . .";
                            lbl_response.ForeColor = System.Drawing.Color.Red;
                            lbl_response.Visible = true;
                            lbl_confirmPassword_star.Visible = true;
                        }
                    }

                }
                else
                {
                    /*
                     * IF CURRENT PASSWORD IS NOT VALID, UPDATE NEW PASSWORD
                     */

                    lbl_response.Text = "Current password is not correct. . .";
                    lbl_response.ForeColor = System.Drawing.Color.Red;
                    lbl_response.Visible = true;
                    lbl_oldPassword_star.Visible = true;
                }
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/user_home.aspx");
        }
    }
}