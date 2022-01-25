using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    UserLogin.Visible = true; //userlogin link button
                    UserSignUp.Visible = true;

                    Logout.Visible = false;
                    HelloUser.Visible = false;

                    AdminLogin.Visible = true;
                    AuthorMgmt.Visible = false;
                    PublisherMgmt.Visible = false;
                    BookInv.Visible = false;
                    BookIssuing.Visible = false;
                    MemberMgmt.Visible = false;
                }
                else if (Session["role"] == "user")
                {
                    UserLogin.Visible = false;
                    UserSignUp.Visible = false;

                    Logout.Visible = true;
                    HelloUser.Visible = true;
                    HelloUser.Text = "Hello " + Session["username"].ToString();

                    AdminLogin.Visible = true;
                    AuthorMgmt.Visible = false;
                    PublisherMgmt.Visible = false;
                    BookInv.Visible = false;
                    BookIssuing.Visible = false;
                    MemberMgmt.Visible = false;
                }
                else
                {
                    UserLogin.Visible = false;
                    UserSignUp.Visible = false;

                    Logout.Visible = true;
                    HelloUser.Visible = true;
                    HelloUser.Text = "Hello Admin";

                    AdminLogin.Visible = false;
                    AuthorMgmt.Visible = true;
                    PublisherMgmt.Visible = true;
                    BookInv.Visible = true;
                    BookIssuing.Visible = true;
                    MemberMgmt.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void AdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void AuthorManagment_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagment.aspx");
        }

        protected void PublisherManagment_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagment.aspx");
        }

        protected void BookInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void BookIssuing_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void MemberManagment_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagment.aspx");
        }

        protected void UserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void ViewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("FUCK WAIT 22");
        }

        protected void UserSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["fullname"] = null;
            Session["role"] = null;
            Session["status"] = null;

            UserLogin.Visible = true; //userlogin link button
            UserSignUp.Visible = true;

            Logout.Visible = false;
            HelloUser.Visible = false;

            AdminLogin.Visible = true;
            AuthorMgmt.Visible = false;
            PublisherMgmt.Visible = false;
            BookInv.Visible = false;
            BookIssuing.Visible = false;
            MemberMgmt.Visible = false;

        }
    }
}