using FinalProjectPSD_LAB.Factory;
using FinalProjectPSD_LAB.Module;
using FinalProjectPSD_LAB.Models;
using FinalProjectPSD_LAB.Repository;
using System;
using System.Collections.Generic;

namespace FinalProjectPSD_LAB.Handlers
{
    public class MakeupHandler
    {

        public static Json<List<Makeup>> GetAllMakeup()
        {
            List<Makeup> makeups = MakeupRepository.GetAllMakeup();
            if (makeups.Count > 0)
            {
                return new Json<List<Makeup>>
                {
                    Text = "Success",
                    Success = true,
                    Response = makeups
                };
            }
            return new Json<List<Makeup>>
            {
                Text = "No makeups found",
                Success = false,
                Response = null
            };
        }

        public static int GenerateMakeupID()
        {
            Makeup makeup = MakeupRepository.GetLastMakeup();

            if (makeup == null)
            {
                return 1;
            }
            return makeup.MakeupID + 1;
        }

 
        public static Json<Makeup> InsertMakeup(string makeupname, int makeupprice, int makeupweight, int makeuptypeID, int makeupbrandID)
        {
            Makeup makeup = MakeupFactory.CreateMakeUp(GenerateMakeupID(), makeupname, makeupprice, makeupweight, makeuptypeID, makeupbrandID);

            if (MakeupRepository.InsertMakeup(makeup) == 0)
            {
                return new Json<Makeup>
                {
                    Text = "Error",
                    Success = false,
                    Response = null
                };
            }

            return new Json<Makeup>
            {
                Text = "Success",
                Success = true,
                Response = makeup
            };
        }

        public static Json<Makeup> UpdateMakeup(int makeupID, string makeupName, int makeupPrice, int makeupWeight, int makeupTypeID, int makeupBrandID)
        {
            Makeup makeup = MakeupFactory.CreateMakeUp(makeupID, makeupName, makeupPrice, makeupWeight, makeupTypeID, makeupBrandID);
            Makeup updatedMakeup = MakeupRepository.UpdateMakeup(makeup);

            if (updatedMakeup == null)
            {
                return new Json<Makeup>
                {
                    Text =  "Something went wrong",
                    Success = false,
                    Response = null
                };
            }

            return new Json<Makeup>
            {
                Text = "Success",
                Success = true,
                Response = makeup
            };
        }

        public static Json<Makeup> DeleteMakeup(int makeupID)
        {
            try
            {
                Makeup deletedMakeup = MakeupRepository.DeleteMakeup(makeupID);
                if (deletedMakeup != null)
                {
                    return new Json<Makeup>
                    {
                        Text = "Makeup deleted successfully",
                        Success = true,                     
                        Response = deletedMakeup
                    };
                }
                else
                {
                    return new Json<Makeup>
                    {
                        Success = false,
                        Text = "Failed to delete makeup",
                        Response = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new Json<Makeup>
                {
                    Success = false,
                    Text = $"An error occurred: {ex.Message}",
                    Response = null
                };
            }
        }
        public static Json<Makeup> GetMakeupID(int ID)
        {
            Makeup makeup = MakeupRepository.GetMakeupID(ID);
            if (makeup != null)
            {
                return new Json<Makeup>
                {
                    Text = "Success",
                    Success = true,
                    Response = makeup
                };
            }
            return new Json<Makeup>
            {
                Text = "Makeup not found",
                Success = false,
                Response = null
            };
        }
    }
}
