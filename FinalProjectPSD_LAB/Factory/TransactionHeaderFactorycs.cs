using FinalProjectPSD_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Util;

namespace FinalProjectPSD_LAB.Factory
{
    public class TransactionHeaderFactorycs
    {
        public static TransactionHeader CreateTransactionHeader(int transactionID, int userID, DateTime transactiondate, string status)
        {
            return new TransactionHeader
            {
                TransactionID = transactionID,
                UserID = userID,
                TransactionDate = transactiondate,
                Status = status
            };
        }
    }
}