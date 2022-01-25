using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class usersignup : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //sign up button click event
        protected void click_SignUp(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('Testing');</script>");
            if (checkIfMemberExists())
            {
                Response.Write("<script>alert('Member already exists with this Member ID, try another one!');</script>");
            }
            else
            {
                signUpNewMember();
            }
        }



        //user defined methods

        bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='"+textbox_memberid.Text.Trim()+"'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void signUpNewMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email,state,city,postal_code,full_address,member_id,password,account_status) VALUES(@full_name,@dob,@contact_no,@email,@state,@city,@postal_code,@full_address,@member_id,@password,@account_status)", con);

                cmd.Parameters.AddWithValue("@full_name", textbox_full_name.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", textbox_dob.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", textbox_contact_no.Text.Trim());
                cmd.Parameters.AddWithValue("@email", textbox_email.Text.Trim());
                cmd.Parameters.AddWithValue("@state", dropdown_state.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", textbox_city.Text.Trim());
                cmd.Parameters.AddWithValue("@postal_code", textbox_postal.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", textbox_full_address.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", textbox_memberid.Text.Trim());
                cmd.Parameters.AddWithValue("@password", textbox_password.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign Up Successfull. Go to User Login to login.');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}