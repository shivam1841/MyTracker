using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OEMS.AdminPanel
{
    public partial class AdminUsersReport : System.Web.UI.Page
    {
        // REQUIRED VARIABLE TO CONNECT TO DATABASE
        SqlConnection con;
        string c_string;
        Boolean isParticipantValid;
        SqlCommand cmd;
        string sql;
        SqlDataReader reader;
        string username;

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
            if (gv_userReport.Rows.Count == 0)
            {
                Label1.Text = "No events to display";
                dv_userDetails.Visible = false;
            }
            else
            {
                Label1.Text = "User report";
                dv_userDetails.Visible = true;

                // ASSIGN SELECTED VALUE FROM GRIDVIEW
                username = gv_userReport.SelectedValue.ToString();
            }
        }

        protected void gv_userReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ASSIGN SELECTED VALUE FROM GRIDVIEW
            username = gv_userReport.SelectedValue.ToString();

            //SET USER CONTROL
            lbl_response.Visible = false;
        }

        protected void btn_block_Click(object sender, EventArgs e)
        {
            // TOGGLE BLOCK/ UNBLOCK STATUS
            if (dv_userDetails.Rows[12].Cells[1].Text.ToString() == "no")
            {
                con.Open();
                sql = "UPDATE [user] SET [isBlocked] = @status WHERE [user_name] = @username";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("status", "yes"));
                cmd.Parameters.Add(new SqlParameter("username", username));
                cmd.ExecuteNonQuery();

                lbl_response.Text = "User blocked successfully. . .";
                lbl_response.ForeColor = System.Drawing.Color.Red;
                lbl_response.Visible = true;
                con.Close();

                // UPDATE DATA
                gv_userReport.DataBind();
                dv_userDetails.DataBind();
            }
            else
            {
                con.Open();
                sql = "UPDATE [user] SET [isBlocked] = @status WHERE [user_name] = @username";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("status", "no"));
                cmd.Parameters.Add(new SqlParameter("username", username));
                cmd.ExecuteNonQuery();
                lbl_response.Text = "User unblocked successfully. . .";
                lbl_response.ForeColor = System.Drawing.Color.Blue;
                lbl_response.Visible = true;
                con.Close();

                // UPDATE DATA
                gv_userReport.DataBind();
                dv_userDetails.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            gv_userReport.DataSourceID = "ds_keyword";
            gv_userReport.DataBind();
        }

        protected void btn_clearSearch_Click(object sender, EventArgs e)
        {
            gv_userReport.DataSourceID = "gv_ds_userReport_admin";
            gv_userReport.DataBind();
            txt_keyword.Text = "";
        }
    }
}