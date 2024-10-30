using FinalProjectPSD_LAB.Factory;
using FinalProjectPSD_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Repository
{
    public class TransactionHeaderRepository
    {
        private static Database_MakeMeUpzzEntities3 db = new Database_MakeMeUpzzEntities3();

        public static TransactionHeader UpdateTransactionHeader(TransactionHeader transactionHeader)
        {
            TransactionHeader updatedTransactionHeader = db.TransactionHeaders.Find(transactionHeader.TransactionID);
            updatedTransactionHeader.UserID = transactionHeader.UserID;
            updatedTransactionHeader.TransactionDate = transactionHeader.TransactionDate;
            updatedTransactionHeader.Status = transactionHeader.Status;
            db.SaveChanges();
            return transactionHeader;
        }

        public static int InsertTransactionHeader(TransactionHeader transactionHeader)
        {
            db.TransactionHeaders.Add(transactionHeader);
            return db.SaveChanges();
        }

        public static TransactionHeader UpdateTransactionHeaderStatus(TransactionHeader transaction)
        {
            TransactionHeader updatedTransactionHeader = db.TransactionHeaders.Find(transaction.TransactionID);
            if (updatedTransactionHeader.Status == "UNHANDLED")
            {
                updatedTransactionHeader.Status = "HANDLED";
            }
            else
            {
                updatedTransactionHeader.Status = "UNHANDLED";
            }
            db.SaveChanges();
            return transaction;

        }

        public static TransactionHeader GetTransactionHeaderID(int ID)
        {
            return db.TransactionHeaders.Find(ID);
        }

        public static TransactionHeader GetLastTransactionHeader()
        {
            return db.TransactionHeaders.ToList().LastOrDefault();
        }
        public static int DeleteTransactionHeader(int ID)
        {
            TransactionHeader deletedTransactionHeader = db.TransactionHeaders.Find(ID);
            if (deletedTransactionHeader != null)
            {
                db.TransactionHeaders.Remove(deletedTransactionHeader);
                return db.SaveChanges();
            }
            return 0;
        }

        public static List<TransactionHeader> GetTransactionHeaderUserId(int userID)
        {
            return db.TransactionHeaders.Where(x => x.UserID == userID).ToList();
        }

        public static List<TransactionHeader> GetAllTransactionHeaders()
        {
            return db.TransactionHeaders.ToList();
        }
    }
}