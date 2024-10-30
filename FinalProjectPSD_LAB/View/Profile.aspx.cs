using FinalProjectPSD_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectPSD_LAB.View
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/View/Homepage.aspx");
            }

            if (!IsPostBack)
            {
                User users = (User)Session["user"];
                UserID.Text = users.UserID.ToString();
                UsernameName.Text = users.Username;
                PasswordName.Text = users.UserPassword;
                EmailName.Text = users.UserEmail;
                GenderName.Text = users.UserGender;
            }
        }
    }
}