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
    public partial class InsertMakeup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                if (user.UserRole != "admin")
                {
                    Response.Redirect("~/View/ManagerAdminMakeup.aspx");
                }
                if (!Page.IsPostBack)
                {
                    Json<List<MakeUpType>> response = MakeupTypeController.GetAllMakeupTypes();
                    if (response.Success)
                    {
                        TypeIDDdl.DataSource = response.Response;
                        TypeIDDdl.DataValueField = "MakeupTypeID";
                        TypeIDDdl.DataTextField = "MakeupTypeName";
                        TypeIDDdl.DataBind();
                    }
                    Json<List<MakeupBrand>> responsee = MakeupBrandController.GetAllMakeupBrands();
                    if (responsee.Success)
                    {
                        BrandIDDdl.DataSource = responsee.Response;
                        BrandIDDdl.DataValueField = "MakeupBrandID";
                        BrandIDDdl.DataTextField = "MakeupBrandName";
                        BrandIDDdl.DataBind();
                    }
                }
            }
            else
            {
                Response.Redirect("~/View/ManagerAdminMakeup.aspx");
            }
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = NameTxt.Text;
                string price = PriceTxt.Text;
                string weight = WeightTxt.Text;
                string typeid = TypeIDDdl.SelectedValue;
                string brandid = BrandIDDdl.SelectedValue;

                Json<Makeup> response = MakeupController.InsertMakeup(name, price, weight, typeid, brandid);
                if (response.Success)
                {
                    Response.Redirect("~/View/ManagerAdminMakeup.aspx");
                }

                ErrorLbl.Text = response.Text;
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
