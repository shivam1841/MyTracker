using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS.AdminPanel
{
    public partial class AdminSendEmail : System.Web.UI.Page
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
            if (Session["admin"] == null)
            {
                Response.Redirect("~/AdminPanel/AdminLogin.aspx");
            }
            else
            {
                // // SET VARIABLES FOR DATABASE CONNECTIVITY
                global_variable gb = new global_variable();
                c_string = gb.getConnectionString();
                con = new SqlConnection(c_string);

                // set the username at top left corner
                Label lbl_welcome_user = this.Master.FindControl("lbl_welcome_user") as Label;
                lbl_welcome_user.Text = "Welcome Admin";
                //******************************COPY ABOVE CODE IN EVERY PAGE LOAD EVENT************//
            }

            // webpage code
        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            if (txt_subject.Text.Trim() == "" || txt_subject.Text.Trim() == null)
            {
                txt_subject.Text = "Greetings from MyTracker";
            }

            try
            {
                // TRY SENDING AN EMAIL
                SendMail();
                lbl_response.ForeColor = System.Drawing.Color.Blue;
                lbl_response.Text = "Email has been successfully sent to <strong><u>" + ddl_emailID.SelectedValue + "</u></strong>";
                panel_status.Visible = true;

                // RESET ALL FIELDS
                ddl_emailID.SelectedIndex = 0;
                txt_subject.Text = "";
                txt_body.Text = "";
            }
            catch (Exception)
            {
                // ERROR SENDING AN EMAIL
                lbl_response.ForeColor = System.Drawing.Color.Red;
                lbl_response.Text = "Something went wrong while sending email to <strong><u>" + ddl_emailID.SelectedValue + "</u></strong><br />";
                lbl_response.Text += "Please try again later or contact IT administration.";
                panel_status.Visible = true;
            }
        }

        protected void SendMail()
        {
            // Gmail Address from where you send the mail
            var fromAddress = "mytracker.help@gmail.com";
            // any address where the email will be sending
            var toAddress = ddl_emailID.SelectedValue;
            //Password of your gmail address
            const string fromPassword = "admin@mytracker";
            // Passing the values and make a email formate to display
            string subject = txt_subject.Text;
            string body = txt_body.Text;

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

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            // SET USER CONTROLS
            lbl_response.Text = "";
            panel_status.Visible = false;
            ddl_emailID.SelectedIndex = 0;
            txt_body.Text = "";
            txt_subject.Text = "";
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_username.Text.Trim()))
            {
                // if textbox is empty, select first value from dropdown list
                ddl_emailID.SelectedIndex = 0;
            }
            else
            {
                // find the username in database and replace the email id
                con.Open();
                sql = "select [user_name], [email] from [user]";       // define sql query
                cmd = new SqlCommand(sql, con);                       // prepare sql command
                reader = cmd.ExecuteReader();                         // assign SQLCommand to the reader

                //
                while (reader.Read())
                {
                    if (reader.GetString(0) == txt_username.Text.ToLower().Trim())
                    {
                        ddl_emailID.Text = reader.GetString(1);
                        break;
                    }
                    else
                    {
                        // IF USERNAME NOT FOUND
                        ddl_emailID.SelectedIndex = 0;
                    }
                }

                // close reader and connection while not in use
                reader.Close();
                con.Close();
            }
        }
    }
}