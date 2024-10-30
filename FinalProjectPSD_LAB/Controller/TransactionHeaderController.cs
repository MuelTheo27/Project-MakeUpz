using FinalProjectPSD_LAB.Handler;
using FinalProjectPSD_LAB.Models;
using FinalProjectPSD_LAB.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Controller
{
    public class TransactionHeaderController
    {

        public static Json<List<TransactionHeader>> GetTransactionHeaderUserID(int ID)
        {
            return TransactionHeaderHandler.GetTransactionHeadeUserID(ID);

        }
        private static List<Cart> CartListValid(List<Cart> cartList, List<string> error)
        {
            if (cartList == null)
            {
                error.Add("Empty");
            }
            else if (cartList.Count == 0)
            {
                error.Add("Empty");
            }
            return cartList;
        }

        public static Json<TransactionHeader> GetTransactionHeaderID(int ID)
        {
            return TransactionHeaderHandler.GetTransactionHeaderID(ID);
        }
        public static Json<TransactionHeader> CheckoutCart(List<Cart> cartList)
        {
            List<string> error = new List<string>();
            List<Cart> cart = CartListValid(cartList, error);
            if (error.Count > 0)
            {
                return MakeErrorResponse<TransactionHeader>(error);
            }
            return TransactionHeaderHandler.CheckoutCart(cart);
        }

        public static Json<TransactionHeader> UpdateTransactionHeaderStats(TransactionHeader Transac)
        {
            return TransactionHeaderHandler.UpdateTransactionHeaderStatus(Transac);
        }


        public static Json<List<TransactionHeader>> GetAllTransactionHeader()
        {
            return TransactionHeaderHandler.GetTransactionHeader();
        }

        private static Json<T> MakeErrorResponse<T>(List<string> errorr)
        {
            string message = "";
            foreach (var error in errorr)
            {
                message += error + "|";
            }
            return new Json<T>
            {
                Text = message,
                Success = false,
                Response = default
            };
        }

        private static int UserIDValid(int userId, List<string> error)
        {
            if (userId <= 0)
            {
                error.Add("User Id string must be > 0");
            }
            return userId;
        }


        private static int TransactionIDValid(int transactionID, List<string> error)
        {
            try
            {
                if (transactionID <= 0)
                {
                    error.Add("Transaction ID string must be > 0");
                }
                return transactionID;
            }
            catch (Exception e)
            {
                error.Add(e.Message);
            }
            return 0;
        }

        private static DateTime TransactionDateValid(DateTime transactionDate, List<string> error)
        {
            if (transactionDate == null)
            {
                error.Add("Transaction Date must be filled");
            }
            return transactionDate;
        }

  
    }
}