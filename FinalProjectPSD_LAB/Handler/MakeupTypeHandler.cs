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
    public class MakeupTypeHandler
    { 
        public static Json<List<MakeUpType>> GetAllMakeupType()
        {
            List<MakeUpType> makeUp = MakeUpTypeRepository.GetAllMakeupTypes();
            if (makeUp.Count > 0)
            {
                return new Json<List<MakeUpType>>
                {
                    Text = "Confirmed",
                    Success = true,
                    Response = makeUp
                };
            }
            return new Json<List<MakeUpType>>
            {
                Text = "No Type found",
                Success = false,
                Response = null
            };
        }
        public static Json<MakeUpType> RemoveMakeupType(int makeupTypeID)
        {
            MakeUpType makeupTypes = MakeUpTypeRepository.GetMakeupTypeID(makeupTypeID);
            List<Makeup> makeups = MakeupRepository.GetMakeupTypeID(makeupTypeID);
            if (makeups.Count > 0)
            {
                foreach (Makeup makeup in makeups)
                {
                    if (MakeupRepository.DeleteMakeup(makeup.MakeupID) == null)
                    {
                        return new Json<MakeUpType>
                        {
                            Text = "Error in removing makeup id:" + makeup.MakeupID,
                            Success = false,
                            Response = null
                        };
                    }
                }
            }
            if (MakeUpTypeRepository.DeleteMakeupTypeId(makeupTypeID) == 0)
            {
                return new Json<MakeUpType>
                {
                    Text = "Error",
                    Success = false,
                    Response = null
                };
            }
            return new Json<MakeUpType>
            {
                Text = "Success",
                Success = true,
                Response = makeupTypes
            };
        }
        public static Json<MakeUpType> GetMakeupTypeID(int ID)
        {
            MakeUpType makeup = MakeUpTypeRepository.GetMakeupTypeID(ID);
            if (makeup != null)
            {
                return new Json<MakeUpType>
                {
                    Text = "Confirm",
                    Success = true,
                    Response = makeup
                };
            }
            return new Json<MakeUpType>
            {
                Text = "No type found",
                Success = false,
                Response = null
            };
        }
        public static Json<MakeUpType> InsertMakeupType(string name)
        {
            MakeUpType makeUp = MakeUpTypeFactory.CreateMakeupType(MakeIDMakeupType(), name);

            if (MakeUpTypeRepository.InsertMakeupType(makeUp) == 0)
            {
                return new Json<MakeUpType>
                {
                    Text = "Error",
                    Success = false,
                    Response = null
                };
            }

            return new Json<MakeUpType>
            {
                Text = "Confirmed",
                Success = true,
                Response = makeUp
            };
        }
        public static int MakeIDMakeupType()
        {
            MakeUpType makeup = MakeUpTypeRepository.GetLastMakeupType();

            if (makeup == null)
            {
                return 1;
            }
            return makeup.MakeupTypeID + 1;
        }
        public static Json<MakeUpType> UpdateMakeupType(int ID, string name)
        {
            MakeUpType makeupType = MakeUpTypeFactory.CreateMakeupType(ID, name);
            MakeUpType updatedMakeupType = MakeUpTypeRepository.UpdateMakeupType(makeupType);
            if (updatedMakeupType == null)
            {
                return new Json<MakeUpType>
                {
                    Text = "Error",
                    Success = false,
                    Response = null
                };
            }
            return new Json<MakeUpType>
            {
                Text = "Confirmed",
                Success = true,
                Response = makeupType
            };
        }
    }
}