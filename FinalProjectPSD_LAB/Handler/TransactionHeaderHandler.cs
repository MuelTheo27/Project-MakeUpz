using FinalProjectPSD_LAB.Factory;
using FinalProjectPSD_LAB.Models;
using FinalProjectPSD_LAB.Module;
using FinalProjectPSD_LAB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Handler
{
    public class TransactionHeaderHandler
    {
        public static Json<TransactionHeader> GetTransactionHeaderID(int ID)
        {
            TransactionHeader transaction = TransactionHeaderRepository.GetTransactionHeaderID(ID);
            if (transaction != null)
            {
                return new Json<TransactionHeader>
                {
                    Text = "Success",
                    Success = true,
                    Response = transaction
                };
            }
            return new Json<TransactionHeader>
            {
                Text = "No transaction found",
                Success = false,
                Response = null
            };
        }

        public static Json<List<TransactionHeader>> GetTransactionHeader()
        {
            List<TransactionHeader> transactions = TransactionHeaderRepository.GetAllTransactionHeaders();
            if (transactions.Count > 0)
            {
                return new Json<List<TransactionHeader>>
                {
                    Text = "Success",
                    Success = true,
                    Response = transactions
                };
            }
            return new Json<List<TransactionHeader>>
            {
                Text = "No transactions",
                Success = false,
                Response = null
            };
        }

        public static Json<TransactionHeader> UpdateTransactionHeaderStatus(TransactionHeader transaction)
        {
            TransactionHeader transac = TransactionHeaderRepository.UpdateTransactionHeaderStatus(transaction);
            if (transaction != null)
            {
                return new Json<TransactionHeader>
                {
                    Text = "Success",
                    Success = true,
                    Response = transac
                };
            }
            return new Json<TransactionHeader>
            {
                Text = "Transaction not found",
                Success = false,
                Response = null
            };
        }

        public static Json<List<TransactionHeader>> GetTransactionHeadeUserID(int ID)
        {
            List<TransactionHeader> transaction = TransactionHeaderRepository.GetTransactionHeaderUserId(ID);

            if (transaction != null)
            {
                return new Json<List<TransactionHeader>>
                {
                    Text = "Success",
                    Success = true,
                    Response = transaction
                };
            }
            return new Json<List<TransactionHeader>>
            {
                Text = "No Transactions",
                Success = false,
                Response = null
            };

        }

        public static Json<TransactionHeader> CheckoutCart(List<Cart> carts)
        {
            TransactionHeader transactionHeader = TransactionHeaderFactorycs.CreateTransactionHeader(GenerateTransactionID(), carts[0].UserID, DateTime.Now, "unhandled");
            if (TransactionHeaderRepository.InsertTransactionHeader(transactionHeader) == 0)
            {
                return new Json<TransactionHeader>
                {
                    Text = "Failed to checkout",
                    Success = false,
                    Response = null
                };
            }

            foreach (Cart cart in carts)
            {
                Json<TransactionDetail> response = TransactiondetailHandlercs.InsertTransactionDetail(transactionHeader.TransactionID, cart.MakeupID, cart.Quantity);
                if (!response.Success)
                {
                    RemoveTransactionDetails(transactionHeader);
                    return new Json<TransactionHeader>
                    {
                        Text = "Failed to checkout",
                        Success = false,
                        Response = null
                    };
                }
            }

            return new Json<TransactionHeader>
            {
                Text = "Success",
                Success = true,
                Response = transactionHeader
            };
        }

        private static Json<TransactionHeader> RemoveTransactionDetails(TransactionHeader transactionHeader)
        {
            TransactiondetailHandlercs.DeleteTransactionDetails(transactionHeader.TransactionID);
            if (TransactionHeaderRepository.DeleteTransactionHeader(transactionHeader.TransactionID) == 0)
            {
                return new Json<TransactionHeader>
                {
                    Text = "Failed to remove transaction details",
                    Success = false,
                    Response = null
                };
            }
            return new Json<TransactionHeader>
            {
                Text = "Remove transaction details success",
                Success = true,
                Response = null
            };
        }

        private static int GenerateTransactionID()
        {
            TransactionHeader transactionHeader = TransactionHeaderRepository.GetLastTransactionHeader();
            if (transactionHeader == null)
            {
                return 1;
            }
            return transactionHeader.TransactionID + 1;
        }
        public static object TransactionDetailFactory { get; private set; }

    }
}