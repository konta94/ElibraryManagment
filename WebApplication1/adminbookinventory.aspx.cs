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

        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAuthorPublisherValues();
            }
            GridView_BookInventory.DataBind();
        }

        protected void Button_GO_Click(object sender, EventArgs e)
        {
            GetBookById();
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
            UpdateBookById();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            DeleteBookById();
        }

        //user defined functions

        void DeleteBookById()
        {
            if (CheckIfBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tbl WHERE book_id='" + textBox_bookid.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView_BookInventory.DataBind();
                    Response.Write("<script>alert('Book Deleted Successfully.');</script>");
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

        void UpdateBookById()
        {
            if (CheckIfBookExists())
            {
                try
                {
                    int actual_stock = Convert.ToInt32(textBox_acutalstock.Text.Trim());
                    int current_stock = Convert.ToInt32(textBox_currentstock.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books.');</script>");
                            return;
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            textBox_currentstock.Text = "" + current_stock;
                        }
                    }

                    string genres = string.Empty;
                    foreach (int i in ListBox_Genre.GetSelectedIndices())
                    {
                        genres = genres + ListBox_Genre.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/book_inventory/books";
                    string filename = Path.GetFileName(FileUpload_BookInventory.PostedFile.FileName);
                    if (filename == string.Empty || filename == null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileUpload_BookInventory.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name=@book_name, " +
                        "genre=@genre, author_name=@author_name, publisher_name=@publisher_name, " +
                        "publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, " +
                        "no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, " +
                        "current_stock=@current_stock, book_img_link=@book_img_link " +
                        "WHERE book_id='"+ textBox_bookid.Text.Trim() +"'", con);

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
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView_BookInventory.DataBind();
                    Response.Write("<script>alert('Book Updated Successfully.');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID.');</script>");
            }
        }

        void GetBookById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='"+ textBox_bookid.Text.Trim() +"'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    textBox_bookname.Text = dt.Rows[0]["book_name"].ToString(); //book_name = column (could be column number)
                    textBox_edition.Text = dt.Rows[0]["edition"].ToString();
                    textBox_cost.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    textBox_pages.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    textBox_description.Text = dt.Rows[0]["book_description"].ToString();
                    DropDownList_Language.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList_Publisher.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList_Author.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    textBox_publishdate.Text = dt.Rows[0]["publish_date"].ToString();

                    textBox_acutalstock.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    textBox_currentstock.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    textBox_issuedbooks.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                    ListBox_Genre.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox_Genre.Items.Count; j++)
                        {
                            if (ListBox_Genre.Items[j].ToString() == genre[i])
                            {
                                ListBox_Genre.Items[j].Selected = true;
                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid book id!');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
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