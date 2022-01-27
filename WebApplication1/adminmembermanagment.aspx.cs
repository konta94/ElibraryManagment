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
    public partial class adminmembermanagment : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView_MemberList.DataBind();
        }

        protected void Button_GO_Click(object sender, EventArgs e)
        {
            GetMemberById();
        }
        protected void Button_Active_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusById("active");
        }

        protected void Button_Pending_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusById("pending");
        }

        protected void Button_Deactive_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusById("deactive");
        }

        protected void button_DeleteUser_Click(object sender, EventArgs e)
        {
            DeleteMemberById();
        }

        //user defined functions

        bool CheckIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + textBox_memberid.Text.Trim() + "'", con);

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

        void ClearForm()
        {
            textBox_fullname.Text = string.Empty;
            textBox_accountstatus.Text = string.Empty;
            textBox_dob.Text = string.Empty;
            textBox_contact.Text = string.Empty;
            textBox_email.Text = string.Empty;
            textBox_state.Text = string.Empty;
            textBox_city.Text = string.Empty;
            textBox_postalcode.Text = string.Empty;
            textBox_fulladdress.Text = string.Empty;
        }

        void DeleteMemberById()
        {
            if (CheckIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl WHERE member_id='" + textBox_memberid.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView_MemberList.DataBind();
                    Response.Write("<script>alert('Member Deleted Successfully.');</script>");
                    ClearForm();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID.');</script>");
            }
        }

        void UpdateMemberStatusById(string status)
        {
            if (CheckIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id='" + textBox_memberid.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView_MemberList.DataBind();
                    Response.Write("<script>alert('Member Status Updated.');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID.');</script>");
            }
            
        }

        void GetMemberById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + textBox_memberid.Text.Trim() + "'", con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox_fullname.Text = dr.GetValue(0).ToString(); //get value from first row (0 column) with data reader
                        textBox_accountstatus.Text = dr.GetValue(10).ToString();
                        textBox_dob.Text = dr.GetValue(1).ToString();
                        textBox_contact.Text = dr.GetValue(2).ToString();
                        textBox_email.Text = dr.GetValue(3).ToString();
                        textBox_state.Text = dr.GetValue(4).ToString();
                        textBox_city.Text = dr.GetValue(5).ToString();
                        textBox_postalcode.Text = dr.GetValue(6).ToString();
                        textBox_fulladdress.Text = dr.GetValue(7).ToString();

                    }
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}