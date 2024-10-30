using FinalProjectPSD_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Repository
{
    public class UserTransactionRepository
    {
        public static List<TransactionHeader> GetTransactionHeader()
        {
            Database_MakeMeUpzzEntities3 db = new Database_MakeMeUpzzEntities3();
            return db.TransactionHeaders.ToList();
        }
    }
}