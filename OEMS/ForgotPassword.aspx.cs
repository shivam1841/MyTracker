using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        // REQUIRED VARIABLE TO CONNECT TO DATABASE
        SqlConnection con;
        string c_string;
        SqlCommand cmd;
        string sql;
        SqlDataReader reader;
        Control mainMenu;

        protected void Page_Load(object sender, EventArgs e)
        {
            // GET THE CONNECTION STRING
            global_variable gb = new global_variable();
            c_string = gb.getConnectionString();
            con = new SqlConnection(c_string);

            // DISABLE THE MENUBAR
            mainMenu = Page.Master.FindControl("Menu1");
            mainMenu.Visible = false;
        }

        protected void SendMail(String to, int randomPassword)
        {
            // Gmail Address from where you send the mail
            var fromAddress = "mytracker.help@gmail.com";
            // any address where the email will be sending
            var toAddress = to;
            //Password of your gmail address
            const string fromPassword = "admin@mytracker";
            // Passing the values and make a email formate to display
            string subject = "Password reset for " + txt_username.Text.Trim().ToLower();
            string body = "Hello," + txt_username.Text.Trim().ToLower() + "\n\n";
            body += "We have noticed that you have forgotten your password\n";
            body += "We are always here to help you.\n";
            body += "We have reset your password as following.\n\n";
            body += "Username: " + txt_username.Text.ToLower().Trim() + "\n";
            body += "Password: " + randomPassword + "\n\n";
            body += "Thank you,\n";
            body += "Team MyTracker";

            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }

        protected void btn_submit_username_Click(object sender, EventArgs e)
        {
            // CHECK IF USERNAME IS EMPTY
            if (String.IsNullOrEmpty(txt_username.Text.Trim()))
            {
                lbl_response.Text = "Please Enter Username";
                lbl_response.Visible = true;
                lbl_username_star.Visible = true;
            }
            else
            {
                // IF THE USERNAME IS ENTERED, VALIDATE WITH THE DATABASE
                lbl_response.Visible = false;
                lbl_username_star.Visible = false;

                con.Open();
                sql = "SELECT [user_name], [email] FROM [user]";
                cmd = new SqlCommand(sql, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // CHECK IF THE USERNAME EXISTS IN THE DATABASE
                    if (String.Equals(txt_username.Text.Trim().ToLower(), reader.GetString(0)))
                    {
                        // IF USERNAME IS VALID

                        if (String.IsNullOrEmpty(reader.GetString(1)))
                        {
                            // IF USER DOESN'T PROVIDE EMAIL ADDRESS DURING REGISTRATION
                            lbl_response.Text = "No email registered with " + txt_username.Text.Trim().ToLower();
                            lbl_response.Visible = true;
                        }
                        else
                        {
                            // IF USER ACCOUNT HAS EMAIL REGISTERED

                            // GENERATE A NEW PASSWORD FOR USER
                            Random n = new Random();
                            int randomPassword = n.Next();

                            // TRY SENDING AN EMAIL TO THE USER
                            try
                            {
                                SendMail(reader.GetString(1), randomPassword);

                                //UPDATE THE PASSWORD IN THE DATABASE
                                // DATAREADER IS ALREADY OPEN WITH THE PREVIOUS CONNECTION, 
                                // SO THERE IS A NEED TO USE DIFFERENT CONNECTION
                                // OR CLOSING THE DATAREADER

                                SqlConnection con1 = new SqlConnection(c_string);
                                con1.Open();
                                string sql1 = "UPDATE [user] SET [password] = @newPassword WHERE [user_name] = @username";
                                SqlCommand cmd1 = new SqlCommand(sql1, con1);
                                cmd1.Parameters.Add(new SqlParameter("newPassword", randomPassword));
                                cmd1.Parameters.Add(new SqlParameter("username", txt_username.Text.Trim().ToLower()));
                                cmd1.ExecuteNonQuery();
                                con1.Close();

                                // CONTROL SETTINGS
                                lbl_response.Visible = false;
                                panel_username.Visible = false;
                                panel_securityAnswer.Visible = false;

                                // visible navigating URL to go back to the login page
                                lbl_emailConfirmation.Text = "Email has been sent to " + reader.GetString(1);
                                panel_emailConfirmation.Visible = true;
                            }
                            catch (Exception ex)
                            {
                                // IF THERE IS ANY ERROR SENDING EMAIL
                                lbl_response.Text = "Couldn't send email, Please try later";
                                lbl_response.Text = ex.ToString();
                                lbl_response.Visible = true;
                           }
                        }

                        // BREAK THE LOOP WHEN USER IS FOUND
                        break;
                    }
                    else
                    {
                        // CONTROL SETTINGS
                        lbl_response.Text = "No User found. . .";
                        lbl_response.Visible = true;
                        panel_securityAnswer.Visible = false;
                        panel_emailConfirmation.Visible = false;
                    }
                }
                // CLOSE THE CONNECTION WHEN DONE
                reader.Close();
                con.Close();
            }
        }

        protected void btn_verifyBySecurity_Click(object sender, EventArgs e)
        {
            // CHECK IF USERNAME IS EMPTY
            if (String.IsNullOrEmpty(txt_username.Text.Trim()))
            {
                lbl_response.Text = "Please Enter Username";
                lbl_response.Visible = true;
                lbl_username_star.Visible = true;
            }
            else
            {
                // IF THE USERNAME IS ENTERED, VALIDATE WITH THE DATABASE

                lbl_response.Visible = false;
                lbl_username_star.Visible = false;

                con.Open();
                sql = "SELECT [user_name], [security_question], [security_answer] FROM [user]";
                cmd = new SqlCommand(sql, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // CHECK IF THE USERNAME EXISTS IN THE DATABASE
                    if (String.Equals(txt_username.Text.Trim().ToLower(), reader.GetString(0)))
                    {
                        // IF USERNAME IS VALID
                        txt_question.Text = reader.GetString(1);

                        // CONTROL SETTINGS
                        lbl_response.Visible = false;
                        panel_username.Visible = false;
                        panel_emailConfirmation.Visible = false;
                        panel_securityAnswer.Visible = true;

                        // BREAK THE LOOP WHEN USER IS FOUND
                        break;
                    }
                    else
                    {
                        // CONTROL SETTINGS
                        lbl_response.Text = "No User found. . .";
                        lbl_response.Visible = true;
                        panel_securityAnswer.Visible = false;
                        panel_emailConfirmation.Visible = false;
                    }
                }

                // CLOSE THE CONNECTION WHEN DONE
                reader.Close();
                con.Close();
            }
        }

        protected void btn_navigateToSecurityAnswerPanel_Click(object sender, EventArgs e)
        {
            // IF USER DOES NOT GET THE EMAIL, NAVIGATE HIM/HER TO SECUIRTY VERIFICATION PAGE
            con.Open();
            sql = "SELECT [user_name], [security_question] FROM [user]";
            cmd = new SqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // CHECK IF THE USERNAME EXISTS IN THE DATABASE
                if (String.Equals(txt_username.Text.Trim().ToLower(), reader.GetString(0)))
                {
                    // IF USERNAME IS VALID
                    txt_question.Text = reader.GetString(1);

                    // CONTROL SETTINGS
                    lbl_response.Visible = false;
                    panel_username.Visible = false;
                    panel_emailConfirmation.Visible = false;
                    panel_securityAnswer.Visible = true;

                    // BREAK THE LOOP WHEN USER IS FOUND
                    break;
                }
                else
                {
                    // CONTROL SETTINGS
                    lbl_response.Text = "No User found. . .";
                    lbl_response.Visible = true;
                    panel_securityAnswer.Visible = false;
                    panel_emailConfirmation.Visible = false;
                }
            }

            // CLOSE THE CONNECTION WHEN DONE
            reader.Close();
            con.Close();
        }
        
        protected void btn_verifySecurityAnswer_Click1(object sender, EventArgs e)
        {
            // CHECK FOR THE ANSWER IN DATABASE
            con.Open();
            sql = "SELECT [security_answer] FROM [user] WHERE user_name = @username";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("username", txt_username.Text.Trim().ToLower()));
            string db_answer = cmd.ExecuteScalar().ToString();

            // COMPARE USER ENTERED ANSWER WITH STORED ANSWER
            if (String.Equals(db_answer, txt_answer.Text.Trim().ToLower()))
            {
                // IF THE ANSWER IS CORRECT
                lbl_response.Visible = false;
                panel_securityAnswer.Visible = false;
                panel_newPassword.Visible = true;
            }
            else
            {
                // IF THE ANSWER IS NOT CORRECT
                lbl_response.Text = "Incorrect answer";
                lbl_response.Visible = true;
            }
            con.Close();
        }

        protected void btn_changePassword_Click(object sender, EventArgs e)
        {
            // CHECK IF THE PASSWORD IS ENTERED
            if (String.IsNullOrEmpty(txt_newPassword.Text.Trim()))
            {
                lbl_response.Text = "Please enter a new password";
                lbl_response.Visible = true;
            }
            else
            {
                // IF PASSWORD IS ENTERED, CHECK IF CONFIRM PASSWORD MATCHES WITH THE NEW PASSWORD
                lbl_response.Visible = false;

                if (String.Equals(txt_newPassword.Text.Trim(), txt_confirmPassword.Text.Trim()))
                {   
                    // BOTH PASSWORD MATCH
                    lbl_response.Visible = false;
                    
                    // UPDATE THE PASSWORD
                    con.Open();
                    sql = "UPDATE [user] SET password = @password WHERE user_name = @username";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add(new SqlParameter("password", txt_newPassword.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("username", txt_username.Text.Trim().ToLower()));
                    cmd.ExecuteNonQuery();
                    con.Close();

                    lbl_response.Text = "Password has been updated. . .";
                    lbl_response.ForeColor = System.Drawing.Color.Blue;
                    lbl_response.Visible = true;
                }
                else
                {
                    // PASSWORDS DO NOT MATCH
                    lbl_response.Text = "Both password should match";
                    lbl_response.Visible = true;
                }
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }
    }
}