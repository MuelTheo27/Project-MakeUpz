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
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];

                if (user.UserRole == "admin")
                {
                    Json<List<User>> response = UserController.GetAllUsers();
                    if (response.Success)
                    {
                        UserDataGrid.DataSource = response.Response;
                        UserDataGrid.DataBind();
                    }
                }
            }
        }
    }
}