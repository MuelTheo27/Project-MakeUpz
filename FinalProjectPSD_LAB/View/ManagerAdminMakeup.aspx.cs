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
    public partial class ManagerAdminMakeup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null && ((User)Session["user"]).UserRole == "admin")
            {
                RenderMakeupGridView();
                RenderMakeupTypeGridView();
                RenderMakeupBrandGridView();
            }
            else
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        private void RenderMakeupGridView()
        {
            Json<List<Makeup>> response = MakeupController.GetAllMakeup();
            if (response.Success)
            {
                MakeupGrid.DataSource = response.Response;
                MakeupGrid.DataBind();
            }
        }

        private void RenderMakeupTypeGridView()
        {
            Json<List<MakeUpType>> response = MakeupTypeController.GetAllMakeupTypes();
            if (response.Success)
            {
                MakeupTypeGrid.DataSource = response.Response;
                MakeupTypeGrid.DataBind();
            }
        }

        private void RenderMakeupBrandGridView()
        {
            Json<List<MakeupBrand>> response = MakeupBrandController.GetAllMakeupBrands();
            if (response.Success)
            {
                MakeupBrandGrid.DataSource = response.Response;
                MakeupBrandGrid.DataBind();
            }
        }

        protected void InsertMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertMakeup.aspx");
        }

        protected void InsertMakeupTypeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertMakeupType.aspx");
        }

        protected void InsertMakeupBrandBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertMakeupBrand.aspx");
        }
    }
}