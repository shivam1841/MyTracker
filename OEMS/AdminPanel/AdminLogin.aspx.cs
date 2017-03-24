using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS.AdminPanel
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        // declare variables required to connect to the database
        // connectionString, Command, Reader, SQLQuery

        SqlConnection con;
        string c_string;
        SqlCommand cmd;
        string sql = null;
        SqlDataReader reader;
        Control mainMenu;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)        // if login exists
            {
                Response.Redirect("~/AdminPanel/AdminEventsReport.aspx");
            }
            else        // if not active login exists
            {
                // disable the menu before login
                mainMenu = Page.Master.FindControl("Menu1");
                mainMenu.Visible = false;

                Label lbl_welcome_user = this.Master.FindControl("lbl_welcome_user") as Label;
                lbl_welcome_user.Text = "Please sign in to continue";

                global_variable gb = new global_variable();
                c_string = gb.getConnectionString();
                con = new SqlConnection(c_string);
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_username.Text.Trim() == "")        // check if username is empty
            {
                lbl_response.Text = "Please enter username. . .";
                lbl_response.Visible = true;
                lbl_username_star.Visible = true;
            }
            else
            {
                if (String.IsNullOrEmpty(txt_password.Text.Trim()))        // check if password is empty
                {
                    lbl_response.Text = "Please enter password. . .";
                    lbl_response.Visible = true;
                    lbl_username_star.Visible = false;
                    lbl_password_star.Visible = true;
                }
                else
                {
                    // if both credentials are entered, proceed to login

                    lbl_username_star.Visible = false;
                    lbl_password_star.Visible = false;
                    lbl_response.Visible = false;

                    try
                    {
                        con.Open();
                        sql = "select username, password from [admin]";       // define sql query
                        cmd = new SqlCommand(sql, con);                     // prepare sql command
                        reader = cmd.ExecuteReader();                       // assign SQLCommand to the reader

                        //
                        while (reader.Read())
                        {
                            if (reader.GetString(0) == txt_username.Text.ToLower().Trim() && reader.GetString(1) == txt_password.Text.Trim())
                            {
                                lbl_response.Text = "Login successful";
                                lbl_response.Visible = true;
                                mainMenu.Visible = true;
                                Session["admin"] = txt_username.Text.ToLower().Trim();

                                Response.Redirect("~/AdminPanel/AdminUsersReport.aspx");
                                break;
                            }
                            else
                            {
                                lbl_response.Text = "Login not successful";
                                lbl_response.Visible = true;
                            }
                        }

                        // close reader and connection while not in use
                        reader.Close();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        lbl_response.Text = "Failed to connect. Please try again after some time.";
                        lbl_response.Visible = true;
                    }
                }
            }
        }
    }
}