using FinalProjectPSD_LAB.Models;
using FinalProjectPSD_LAB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Handler
{
    public class TransactionHandler
    {
        public static List<TransactionHeader> GetTransactionHeader()
        {
            return UserTransactionRepository.GetTransactionHeader();
        }
    }
}