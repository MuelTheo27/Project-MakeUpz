using FinalProjectPSD_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Util;

namespace FinalProjectPSD_LAB.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail CreateTransactionDetail(int transactiondetailID, int transactionID, int makeupID,int quantity)
        {
            return new TransactionDetail
            {
                TransactionDetailID = transactiondetailID,
                TransactionID = transactionID,
                MakeupID = makeupID,
                Quantity = quantity
            };
        }
    }
}