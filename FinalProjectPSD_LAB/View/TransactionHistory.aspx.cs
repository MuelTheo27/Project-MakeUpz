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
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int ids = ((FinalProjectPSD_LAB.Models.User)Session["user"]).UserID;

                Json<List<TransactionDetail>> datas = TransactionDetailController.GetTransactionDetailID(ids);  

                if (datas.Success)
                {
                    TransactionDetailTables.DataSource = datas.Response;
                    TransactionDetailTables.DataBind();
                }    
            }
        }

    }
}