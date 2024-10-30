using FinalProjectPSD_LAB.Controller;
using FinalProjectPSD_LAB.Models;
using FinalProjectPSD_LAB.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectPSD_LAB.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("~/View/Homepage.aspx");
            }
            if (Request.Cookies["users"] != null)
            {
                Response.Redirect("~/View/Login.aspx");
            }
        }
        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTxt.Text;
            string email = EmailTxt.Text;
            DateTime dob = DateTime.Parse(DOB.Text);
            string gender = GenderRbl.SelectedValue;
            string password = PasswordTxt.Text;

            Json<User> response = UserController.Register(username, email, dob, gender, password);
            if (response.Success)
            {
                Session["user"] = response.Response;
                Response.Redirect("~/View/HomePage.aspx");
            }

            ErrorLbl.Text = response.Text;
            ErrorLbl.Visible = true;
        }
    }
}