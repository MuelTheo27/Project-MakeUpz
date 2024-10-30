using FinalProjectPSD_LAB.Factory;
using FinalProjectPSD_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Repository
{
    public class MakeUpBrandRepository
    {
        public static Database_MakeMeUpzzEntities3 db = new Database_MakeMeUpzzEntities3();

        public static MakeupBrand GetLastMakeupBrand()
        {
            return db.MakeupBrands.ToList().LastOrDefault();
        }

        public static MakeupBrand GetMakeupBrandID(int ID)
        {
            return db.MakeupBrands.Find(ID);
        }
        public static int InsertMakeupBrand(MakeupBrand makeup)
        {
            db.MakeupBrands.Add(makeup);
            return db.SaveChanges();
        }
        public static List<MakeupBrand> GetAllMakeupBrands()
        {
            return db.MakeupBrands.ToList();
        }
        public static int DeleteMakeupBrandId(int ID)
        {
            MakeupBrand deletedMakeupBrand = db.MakeupBrands.Find(ID);
            if (deletedMakeupBrand != null)
            {
                db.MakeupBrands.Remove(deletedMakeupBrand);
            }
            return db.SaveChanges();
        }

        public static MakeupBrand UpdateMakeupBrand(MakeupBrand makeup)
        {
            MakeupBrand updatedMakeupBrand = db.MakeupBrands.Find(makeup.MakeupBrandID);
            updatedMakeupBrand.MakeupBrandName = makeup.MakeupBrandName;
            updatedMakeupBrand.MakeupBrandRating = makeup.MakeupBrandRating;
            db.SaveChanges();
            return makeup;
        }
    }
}
