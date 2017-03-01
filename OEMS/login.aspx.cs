using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS
{
    public partial class login : System.Web.UI.Page
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

            if (Session["username"] != null)        // if login exists
            {
                Response.Redirect("~/user_home.aspx");
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
                    lbl_error.Text = "Please enter username. . .";
                    lbl_error.Visible = true;
                    lbl_username_star.Visible = true;
                }
                else
                {
                    if (String.IsNullOrEmpty(txt_password.Text.Trim()))        // check if password is empty
                    {
                        lbl_error.Text = "Please enter password. . .";
                        lbl_error.Visible = true;
                        lbl_username_star.Visible = false;
                        lbl_password_star.Visible = true;
                    }
                    else
                    {
                        // if both credentials are entered, proceed to login

                        lbl_username_star.Visible = false;
                        lbl_password_star.Visible = false;
                        lbl_error.Visible = false;

                        try
                        {
                            con.Open();
                            sql = "select user_name, password from [user]";       // define sql query
                            cmd = new SqlCommand(sql, con);                     // prepare sql command
                            reader = cmd.ExecuteReader();                       // assign SQLCommand to the reader

                            //
                            while (reader.Read())
                            {
                                if (reader.GetString(0) == txt_username.Text.ToLower().Trim() && reader.GetString(1) == txt_password.Text.Trim())
                                {
                                    lbl_error.Text = "Login successful";
                                    lbl_error.Visible = true;
                                    mainMenu.Visible = true;
                                    Session["username"] = txt_username.Text;
                                
                                    Response.Redirect("~/user_home.aspx");
                                    break;
                                }
                                else
                                {
                                    lbl_error.Text = "Login not successful";
                                    lbl_error.Visible = true;
                                }
                            }

                            // close reader and connection while not in use
                            reader.Close();
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            lbl_error.Text = "Failed to connect. Please try again after some time.";
                            lbl_error.Visible = true;
                        }
                    }
                }
           

            
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            mainMenu.Visible = false;
            txt_username.Text = "";
            txt_password.Text = "";
            lbl_username_star.Visible = false;
            lbl_password_star.Visible = false;
            lbl_error.Text = "";
            lbl_error.Visible = false;
            Session["username"] = null;
        }
    }
}