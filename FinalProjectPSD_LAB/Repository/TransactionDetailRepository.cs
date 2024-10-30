using FinalProjectPSD_LAB.Factory;
using FinalProjectPSD_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Repository
{
    public class TransactionDetailRepository
    {
        private static Database_MakeMeUpzzEntities3 db = new Database_MakeMeUpzzEntities3();

        public static TransactionDetail UpdateTransactionDetail(TransactionDetail transactionDetail)
        {
            TransactionDetail updatedTransactionDetail = db.TransactionDetails.Find(transactionDetail.TransactionID);
            updatedTransactionDetail.TransactionID = transactionDetail.TransactionID;
            updatedTransactionDetail.MakeupID = transactionDetail.MakeupID;
            updatedTransactionDetail.Quantity = transactionDetail.Quantity;
            db.SaveChanges();
            return transactionDetail;
        }
        public static List<TransactionDetail> GetTransactionDetails(int transactionID)
        {
            return db.TransactionDetails.Where(x => x.TransactionID == transactionID).ToList();
        }

        public static List<TransactionDetail> GetTransactionDetail(int transactionID)
        {
            return db.TransactionDetails.Where(x => x.TransactionID == transactionID).ToList();
        }

        public static int TransactionDetail(TransactionDetail transactionDetail)
        {
            db.TransactionDetails.Add(transactionDetail);
            return db.SaveChanges();
        }

        public static int DeleteTransactionDetail(int transactionID)
        {
            List<TransactionDetail> transactionDetails = db.TransactionDetails.Where(x => x.TransactionID == transactionID).ToList();
            foreach (TransactionDetail transactionDetail in transactionDetails)
            {
                db.TransactionDetails.Remove(transactionDetail);
            }
            return db.SaveChanges();
        }

        public static TransactionDetail GetLastTransactionDetail()
        {
            return db.TransactionDetails.ToList().LastOrDefault();
        }
    }
}