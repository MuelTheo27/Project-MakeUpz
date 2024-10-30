using FinalProjectPSD_LAB.Factory;
using FinalProjectPSD_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Repository
{
    public class MakeUpTypeRepository
    {
        private static Database_MakeMeUpzzEntities3 db = new Database_MakeMeUpzzEntities3();

        public static MakeUpType GetLastMakeupType()
        {
            return db.MakeUpTypes.ToList().LastOrDefault();
        }
        public static List<MakeUpType> GetAllMakeupTypes()
        {
            return db.MakeUpTypes.ToList();
        }
        public static MakeUpType GetMakeupTypeID(int ID)
        {
            return db.MakeUpTypes.Find(ID);
        }

        public static int InsertMakeupType(MakeUpType makeup)
        {
            db.MakeUpTypes.Add(makeup);
            return db.SaveChanges();
        }
        public static int DeleteMakeupTypeId(int ID)
        {
            MakeUpType deletedMakeupType = db.MakeUpTypes.Find(ID);
            if (deletedMakeupType != null)
            {
                db.MakeUpTypes.Remove(deletedMakeupType);
            }
            return db.SaveChanges();
        }
        public static MakeUpType UpdateMakeupType(MakeUpType makeup)
        {
            MakeUpType updatedMakeupType = db.MakeUpTypes.Find(makeup.MakeupTypeID);
            updatedMakeupType.MakeupTypeName = makeup.MakeupTypeName;
            db.SaveChanges();
            return makeup;
        }
    }
}