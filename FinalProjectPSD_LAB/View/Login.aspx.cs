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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("~/View/Homepage.aspx");
            }
            if (Request.Cookies["users"] != null)
            {
                int ID = Convert.ToInt32(Request.Cookies["users"].Value);
                Json<User> response = UserController.GetUserID(ID);
                Session["user"] = response.Response;
                Response.Redirect("~/View/Homepage.aspx");
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTxt.Text;
            string password = PasswordTxt.Text;

            Json<User> response = UserController.Login(username, password);

            if (response.Success)
            {
                Session["user"] = response.Response;
                if (RememberBtn.Checked)
                {
                    CreateUserCredCookie(response.Response.UserID);
                }

                Response.Redirect("~/View/Homepage.aspx");
            }


            ErrorLbl.Text = response.Text;
            ErrorLbl.Visible = true;
        }
        protected void CreateUserCredCookie(int userId)
        {
            HttpCookie cookie = new HttpCookie("users")
            {
                Value = userId.ToString(),
                Expires = DateTime.Now.AddDays(1)
            };
            Response.Cookies.Add(cookie);
        }
    }
}