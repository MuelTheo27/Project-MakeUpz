using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectPSD_LAB.MasterPage
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/Register.aspx");
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/Login.aspx");
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            // Clear the user session
            Session["user"] = null;

            // Remove the user cookie if it exists
            if (Request.Cookies["users"] != null)
            {
                HttpCookie cookie = new HttpCookie("users")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(cookie);
            }

            // Redirect to the Guest page
            Response.Redirect("~/View/Login.aspx");
        }

        protected void OrderBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/Ordermakeup.aspx");
        }

        protected void HistoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/TransactionHistory.aspx");
        }

        protected void ProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/Profile.aspx");
        }

        protected void ViewUserBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/Homepage.aspx");
        }

        protected void InsertDllBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ManagerAdminMakeup.aspx");
        }

        protected void AdminprofileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ProfileAdmin.aspx");
        }
    }
}