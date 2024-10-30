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
    public partial class InsertMakeupType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/View/ManagerAdminMakeup.aspx");
            }
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = NameTxt.Text;
                Json<MakeUpType> Json = MakeupTypeController.InsertMakeupType(name);
                if (Json.Success)
                {
                    Response.Redirect("~/View/ManagerAdminMakeup.aspx");
                }

                ErrorLbl.Text = Json.Text;
                ErrorLbl.Visible = true;
            }
            catch (Exception error)
            {
                ErrorLbl.Text = error.Message;
                ErrorLbl.Visible = true;

            }
        }
    }
}