using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] == null || Session["username"].ToString() == "")
                {
                    Response.Write("<script>alert('Session expired, Login aggain.');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    GetUserBookData();

                    if (!Page.IsPostBack)
                    {
                        GetUserPersonalDetails();
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Session expired, Login aggain.');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Write("<script>alert('Session expired, Login aggain.');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                UpdateUserDetails();
            }
        }

        //user defined functions

        void UpdateUserDetails()
        {
            string password = "";
            if (TextBox_NewPw == null || TextBox_NewPw.Text.Trim() == string.Empty)
            {
                password = TextBox_OldPw.Text.Trim();
            }
            else
            {
                password = TextBox_NewPw.Text.Trim();
            }

            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET full_name=@full_name, " +
                    "dob=@dob, contact_no=@contact_no, email=@email, " +
                    "state=@state, city=@city, postal_code=@postal_code, full_address=@full_address, " +
                    "password=@password, account_status=@account_status WHERE member_id='" + Session["username"].ToString() + "'", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox_FullName.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox_Date.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox_ContactNumber.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox_Email.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList_Country.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox_City.Text.Trim());
                cmd.Parameters.AddWithValue("@postal_code", TextBox_PostalCode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox_FullAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");

                int result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                {
                    Response.Write("<script>alert('Member Details Updated Successfully.');</script>");
                    GetUserPersonalDetails();
                    GetUserBookData();
                }
                else
                {
                    Response.Write("<script>alert('Invalid entry.');</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
              
        void GetUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + Session["username"].ToString() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox_FullName.Text = dt.Rows[0]["full_name"].ToString();
                TextBox_Date.Text = dt.Rows[0]["dob"].ToString();
                TextBox_ContactNumber.Text = dt.Rows[0]["contact_no"].ToString();
                TextBox_Email.Text = dt.Rows[0]["email"].ToString();
                DropDownList_Country.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                TextBox_City.Text = dt.Rows[0]["city"].ToString();
                TextBox_PostalCode.Text = dt.Rows[0]["postal_code"].ToString();
                TextBox_FullAddress.Text = dt.Rows[0]["full_address"].ToString();
                TextBox_OldPw.Text = dt.Rows[0]["password"].ToString().Trim();

                Label_AccountStatus.Text = dt.Rows[0]["account_status"].ToString().Trim();
                if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    Label_AccountStatus.Attributes.Add("class", "badge rounded-pill bg-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                {
                    Label_AccountStatus.Attributes.Add("class", "badge rounded-pill bg-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                {
                    Label_AccountStatus.Attributes.Add("class", "badge rounded-pill bg-danger");
                }
                else
                {
                    Label_AccountStatus.Attributes.Add("class", "badge rounded-pill bg-info");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void GetUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE member_id='" + Session["username"].ToString() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView_Profile.DataSource = dt;
                GridView_Profile.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView_Profile_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text); // 5 is due date
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}