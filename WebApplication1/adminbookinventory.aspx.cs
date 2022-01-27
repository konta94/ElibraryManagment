using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillAuthorPublisherValues();
            GridView_BookInventory.DataBind();
        }

        protected void Button_GO_Click(object sender, EventArgs e)
        {

        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {
                Response.Write("<script>alert('Book already exists, try some other Book ID');</script>");
            }
            else
            {
                AddNewBook();
            }
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {

        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {

        }

        //user defined functions

        void FillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name FROM author_master_tbl", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList_Author.DataSource = dt;
                DropDownList_Author.DataValueField = "author_name";
                DropDownList_Author.DataBind();

                cmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tbl", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList_Publisher.DataSource = dt;
                DropDownList_Publisher.DataValueField = "publisher_name";
                DropDownList_Publisher.DataBind();
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + textBox_bookid.Text.Trim() + "' " +
                    "OR book_name='"+ textBox_bookname.Text.Trim() +"';", con);

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

        void AddNewBook()
        {
            try
            {
                string genres = string.Empty;
                foreach (int i in ListBox_Genre.GetSelectedIndices())
                {
                    genres += ListBox_Genre.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1); //removes the extra comma ,

                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FileUpload_BookInventory.PostedFile.FileName);
                FileUpload_BookInventory.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl (book_id,book_name,genre,author_name,publisher_name,publish_date," +
                    "language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) VALUES" +
                    "(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date," +
                    "@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);

                cmd.Parameters.AddWithValue("@book_id", textBox_bookid.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", textBox_bookname.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList_Author.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList_Publisher.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", textBox_publishdate.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList_Language.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", textBox_edition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", textBox_cost.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", textBox_pages.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", textBox_description.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", textBox_acutalstock.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", textBox_acutalstock.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);


                cmd.ExecuteNonQuery();
                con.Close();
                GridView_BookInventory.DataBind();
                Response.Write("<script>alert('Book Added Successfully');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}