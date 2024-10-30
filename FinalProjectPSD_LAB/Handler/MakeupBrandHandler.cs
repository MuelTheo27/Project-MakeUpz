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
    public class MakeupBrandHandler
    {


        public static Json<MakeupBrand> InsertMakeupBrand(string name, int rating)
        {
            MakeupBrand makeup = MakeupBrandFactory.CreateMakeupBrand(GenerateIDMakeupBrand(), name, rating);

            if (MakeUpBrandRepository.InsertMakeupBrand(makeup) == 0)
            {
                return new Json<MakeupBrand>
                {
                    Text = "Something error",
                    Success = false,
                    Response = null
                };
            }

            return new Json<MakeupBrand>
            {
                Text = "Success",
                Success = true,
                Response = makeup
            };
        }

        public static Json<List<MakeupBrand>> GetAllMakeupBrands()
        {
            List<MakeupBrand> makeups = MakeUpBrandRepository.GetAllMakeupBrands();
            if (makeups.Count > 0)
            {
                return new Json<List<MakeupBrand>>
                {
                    Text = "Success",
                    Success = true,
                    Response = makeups
                };
            }
            return new Json<List<MakeupBrand>>
            {
                Text = "No makeup",
                Success = false,
                Response = null
            };
        }

        public static Json<MakeupBrand> GetMakeupBrandID(int ID)
        {
            MakeupBrand makeup = MakeUpBrandRepository.GetMakeupBrandID(ID);
            if (makeup != null)
            {
                return new Json<MakeupBrand>
                {
                    Text = "Success",
                    Success = true,
                    Response = makeup
                };
            }
            return new Json<MakeupBrand>
            {
                Text = "Makeup not found",
                Success = false,
                Response = null
            };
        }

        public static int GenerateIDMakeupBrand()
        {
            MakeupBrand makeup = MakeUpBrandRepository.GetLastMakeupBrand();

            if (makeup == null)
            {
                return 1;
            }
            return makeup.MakeupBrandID + 1;
        }
        public static Json<MakeupBrand> RemoveMakeupBrandById(int brandID)
        {
            MakeupBrand makeupBrand = MakeUpBrandRepository.GetMakeupBrandID(brandID);
            List<Makeup> makeupp = MakeupRepository.GetMakeupBrandID(brandID);
            if (makeupp.Count > 0)
            {
                foreach (Makeup makeup in makeupp)
                {
                    if (MakeupRepository.DeleteMakeup(makeup.MakeupID) == null)
                    {
                        return new Json<MakeupBrand>
                        {
                            Text = "Failed to remove makeup ID:" + makeup.MakeupID,
                            Success = false,
                            Response = null
                        };
                    }
                }
            }
            if (MakeUpBrandRepository.DeleteMakeupBrandId(brandID) == 0)
            {
                return new Json<MakeupBrand>
                {
                    Text = "Something went wrong",
                    Success = false,
                    Response = null
                };
            }
            return new Json<MakeupBrand>
            {
                Text = "Success",
                Success = true,
                Response = makeupBrand
            };
        }
        public static Json<MakeupBrand> UpdateMakeupBrand(int id, string brandName, int rating)
        {
            MakeupBrand makeupBrand = MakeupBrandFactory.CreateMakeupBrand(id, brandName, rating);
            MakeupBrand updatedMakeupBrand = MakeUpBrandRepository.UpdateMakeupBrand(makeupBrand);
            if (updatedMakeupBrand == null)
            {
                return new Json<MakeupBrand>
                {
                    Text = "Something went wrong",
                    Success = false,
                    Response = null
                };
            }

            return new Json<MakeupBrand>
            {
                Text = "Success",
                Success = true,
                Response = makeupBrand
            };
        }
    }
}