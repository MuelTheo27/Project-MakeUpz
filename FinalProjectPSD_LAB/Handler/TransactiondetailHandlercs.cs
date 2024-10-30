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
    public class TransactiondetailHandlercs
    {
        private static int GenerateID()
        {
            TransactionDetail lastTransactionDetail = TransactionDetailRepository.GetLastTransactionDetail();
            if (lastTransactionDetail == null)
            {
                return 1;
            }
            return lastTransactionDetail.TransactionDetailID + 1;
        }

        public static Json<List<TransactionDetail>> GetTransactionDetailID(int ID)
        {
            List<TransactionDetail> transactionDetail = TransactionDetailRepository.GetTransactionDetails(ID);
            if (transactionDetail != null)
            {
                return new Json<List<TransactionDetail>>
                {
                    Text = "Success",
                    Success = true,
                    Response = transactionDetail
                };
            }
            return new Json<List<TransactionDetail>>
            {
                Text = "no transaction detail",
                Success = false,
                Response = null
            };
        }
        public static Json<TransactionDetail> InsertTransactionDetail(int transactionID, int makeupID, int Quantity)
        {
            TransactionDetail transactionDetail = TransactionDetailFactory.CreateTransactionDetail(GenerateID(), transactionID, makeupID, Quantity);
            if (TransactionDetailRepository.TransactionDetail(transactionDetail) == 0)
            {
                return new Json<TransactionDetail>
                {
                    Text = "Failed",
                    Success = false,
                    Response = null
                };
            }

            return new Json<TransactionDetail>
            {
                Text = "Success",
                Success = true,
                Response = transactionDetail
            };
        }
        public static Json<TransactionDetail> DeleteTransactionDetails(int transactionId)
        {
            if (TransactionDetailRepository.DeleteTransactionDetail(transactionId) == 0)
            {
                return new Json<TransactionDetail>
                {
                    Text = "Failed to delete transaction details",
                    Success = false,
                    Response= null
                };
            }

            return new Json<TransactionDetail>
            {
                Text = "Success",
                Success = true,
                Response = null
            };
        }
    }
}