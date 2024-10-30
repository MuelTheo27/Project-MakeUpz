using FinalProjectPSD_LAB.Handler;
using FinalProjectPSD_LAB.Models;
using FinalProjectPSD_LAB.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Controller
{
    public class TransactionDetailController
    {
        public static Json<List<TransactionDetail>> GetTransactionDetailID(int ID)
        {
            return TransactiondetailHandlercs.GetTransactionDetailID(ID);
        }
    }
}