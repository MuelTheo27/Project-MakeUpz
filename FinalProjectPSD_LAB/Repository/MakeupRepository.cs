using FinalProjectPSD_LAB.Factory;
using FinalProjectPSD_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Repository
{
    public class MakeupRepository
    {
        private static Database_MakeMeUpzzEntities3 db = new Database_MakeMeUpzzEntities3();


        public static Makeup UpdateMakeup(Makeup makeup)
        {
            Makeup updatedMakeup = db.Makeups.Find(makeup.MakeupID);
            updatedMakeup.MakeupName = makeup.MakeupName;
            updatedMakeup.MakeupPrice = makeup.MakeupPrice;
            updatedMakeup.MakeupWeight = makeup.MakeupWeight;
            updatedMakeup.MakeupTypeID = makeup.MakeupTypeID;
            updatedMakeup.MakeupBrandID = makeup.MakeupBrandID;
            db.SaveChanges();
            return makeup;
        }

        public static Makeup GetMakeupID(int ID)
        {
            return db.Makeups.Find(ID);
        }

        public static Makeup GetLastMakeup()
        {
            return db.Makeups.ToList().LastOrDefault();
        }
        public static int InsertMakeup(Makeup makeup)
        {
            db.Makeups.Add(makeup);
            return db.SaveChanges();
        }

        public static List<Makeup> GetAllMakeup()
        {
            return db.Makeups.ToList();
        }

        public static Makeup DeleteMakeup(int ID)
        {
            Makeup deletedMakeup = db.Makeups.Find(ID);
            if (deletedMakeup != null)
            {
                db.Makeups.Remove(deletedMakeup);
                db.SaveChanges();
            }
            return deletedMakeup;
        }
        public static List<Makeup> GetMakeupBrandID(int brandID)
        {
            return db.Makeups.Where(x => x.MakeupBrandID == brandID).ToList();
        }
        public static List<Makeup> GetMakeupTypeID(int typeID)
        {
            return db.Makeups.Where(x => x.MakeupTypeID == typeID).ToList();
        }
    }
}