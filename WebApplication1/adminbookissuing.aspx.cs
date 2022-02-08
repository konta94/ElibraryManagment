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
    public partial class adminbookissuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Issue_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists() && CheckIfMemberExists())
            {
                if (CheckIfIssueEntryExists())
                {
                    Response.Write("<script>alert('This Member already has this book.');</script>");
                }
                else
                {
                    IssueBook();
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID.');</script>");
            }
        }

        protected void Button_Return_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists() && CheckIfMemberExists())
            {
                if (CheckIfIssueEntryExists())
                {
                    ReturnBook();
                }
                else
                {
                    Response.Write("<script>alert('This entry does not exist.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID.');</script>");
            }
        }

        protected void Button_GO_Click(object sender, EventArgs e)
        {
            GetNames();
        }
        //user defined functions

        void ReturnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tbl WHERE book_id='"+ TextBox_BookID.Text.Trim()
                    +"' AND member_id='"+ TextBox_MemberID.Text.Trim() +"'", con);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock + 1 WHERE " +
                        "book_id='"+ TextBox_BookID.Text.Trim() +"'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    Response.Write("<script>alert('There');</script>");
                }
                Response.Write("<script>alert('Book Returned Successfully.');</script>");
                GridView_IssuedBooks.DataBind();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void IssueBook (){
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id, member_name, book_id, book_name, " +
                    "issue_date, due_date) VALUES(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", con);

                cmd.Parameters.AddWithValue("@member_id", TextBox_MemberID.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox_MemberName.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox_BookID.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox_BookName.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox_IssueDate.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox_DueDate.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock-1 WHERE book_id='"+ TextBox_BookID.Text.Trim() +"'", con);
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('Book Issued Successfully.');</script>");

                GridView_IssuedBooks.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool CheckIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id ='" + TextBox_BookID.Text.Trim() + "' AND current_stock>0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
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
                Response.Write("<script>alert(" + ex + ");</script>");
                return false;
            }
        }

        bool CheckIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id ='" + TextBox_MemberID.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
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
                Response.Write("<script>alert(" + ex + ");</script>");
                return false;
            }
        }

        bool CheckIfIssueEntryExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE member_id ='" + TextBox_MemberID.Text.Trim() + "' AND book_id='" + TextBox_BookID.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
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
                Response.Write("<script>alert(" + ex + ");</script>");
                return false;
            }
        }

        void GetNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT book_name FROM book_master_tbl WHERE book_id ='"+ TextBox_BookID.Text.Trim() +"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    TextBox_BookName.Text = dt.Rows[0]["book_name"].ToString(); // dt.Rows[0][0] is also fine since we're getting only one column
                }
                else
                {
                    Response.Write("<script>alert('Wrong Book ID!');</script>");
                }


                cmd = new SqlCommand("SELECT full_name FROM member_master_tbl WHERE member_id ='" + TextBox_MemberID.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    TextBox_MemberName.Text = dt.Rows[0]["full_name"].ToString(); // dt.Rows[0][0] is also fine since we're getting only one column
                }
                else
                {
                    Response.Write("<script>alert('Wrong Member ID!');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert("+ ex +");</script>");
            }
        }

        protected void GridView_IssuedBooks_RowDataBound(object sender, GridViewRowEventArgs e)
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