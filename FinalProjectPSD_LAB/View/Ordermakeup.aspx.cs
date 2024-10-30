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
    public partial class Ordermakeup : System.Web.UI.Page
    {
        public List<Cart> Carts
        {
            get
            {
                return (Session["carts"] != null) ? (List<Cart>)Session["carts"] : InitializeSessionCart();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["user"] != null && ((User)Session["user"]).UserRole == "customer"))
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            if (Session["carts"] == null)
            {
                InitializeSessionCart();
            }
            if (!IsPostBack)
            {
                Json<List<Makeup>> response = MakeupController.GetAllMakeup();
                if (response.Success)
                {
                    OrderMakeupGrid.DataSource = response.Response;
                    OrderMakeupGrid.DataBind();
                }
            }
        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
        {
            List<Cart> carts = Carts;
            List<int> cartsID = new List<int>();
            foreach (var cart in carts)
            {
                cartsID.Add(cart.CartID);
            }
            Json<List<Cart>> response = CartController.RemoveCartsID(cartsID);
            if (!response.Success)
            {
                Response.Write("<script>alert('" + response.Text + "')</script>");
            }
            else
            {
                ((List<Cart>)Session["carts"]).Clear();
            }
            Response.Redirect("~/View/Ordermakeup.aspx");
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            if (((List<Cart>)Session["carts"]).Count < 0)
            {
                Response.Write("<script>alert('Cart is empty')</script>");
            }

            List<Cart> carts = (List<Cart>)Session["carts"];
            Json<TransactionHeader> response = TransactionHeaderController.CheckoutCart(carts);
            if (response.Success)
            {
                CartController.RemoveCartsID(carts.Select(c => c.CartID).ToList());
                Response.Write("<script>alert('Success Checkout!')</script>");

                ((List<Cart>)Session["carts"]).Clear();

                Response.Redirect("~/View/Ordermakeup.aspx");
            }
            else
            {
                Response.Write("<script>alert('" + response.Text + "')</script>");
            }
        }
        protected void OrderBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                GridViewRow row = (GridViewRow)button.NamingContainer;
                int makeupID = Convert.ToInt32(((HiddenField)row.FindControl("MakeupIDHf")).Value);
                int quantity = Convert.ToInt32(((TextBox)row.FindControl("QuantityTxt")).Text);
                int userId = ((User)Session["user"]).UserID;
                Json<Cart> response = CartController.InsertCart(userId, makeupID, quantity);
                if (response.Success)
                {
                    ((List<Cart>)Session["carts"]).Add(response.Response);
                }
                else
                {
                    Response.Write("<script>alert('" + response.Text + "')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        private List<Cart> InitializeSessionCart()
        {
            Json<List<Cart>> response = CartController.GetCardUserID(((User)Session["user"]).UserID);
            if (response.Success)
            {
                Session["carts"] = response.Response;
                return response.Response;
            }
            Session["carts"] = new List<Cart>();
            return (List<Cart>)Session["carts"];
        }

        protected void OrderMakeupGridSelected(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                GridViewRow row = (GridViewRow)button.NamingContainer;
                int makeupID = Convert.ToInt32(((HiddenField)row.FindControl("MakeupIDHf")).Value);
                int quantity = Convert.ToInt32(((TextBox)row.FindControl("QuantityTbx")).Text);
                int userId = ((User)Session["user"]).UserID;
                Json<Cart> response = CartController.InsertCart(userId, makeupID, quantity);
                if (response.Success)
                {
                    ((List<Cart>)Session["carts"]).Add(response.Response);
                }
                else
                {
                    Response.Write("<script>alert('" + response.Text + "')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}
