using FinalProjectPSD_LAB.Handler;
using FinalProjectPSD_LAB.Models;
using FinalProjectPSD_LAB.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Controller
{
    public class MakeupTypeController
    {
        private static void ValidateName(string name, List<string> error)
        {
            if (string.IsNullOrEmpty(name))
            {
                error.Add("Name can't empty");
            }
            else if (name.Length < 1 || name.Length > 99)
            {
                error.Add("Name length must be between 1 - 99 characters");
            }
        }

        public static Json<List<MakeUpType>> GetAllMakeupTypes()
        {
            return MakeupTypeHandler.GetAllMakeupType();
        }

        public static Json<MakeUpType> InsertMakeupType(string makeupTypeName)
        {
            List<string> error = new List<string>();
            ValidateName(makeupTypeName, error);

            if (error.Count > 0)
            {
                return MakeErrorResponse<MakeUpType>(error);
            }

            return MakeupTypeHandler.InsertMakeupType(makeupTypeName);
        }

        public static Json<MakeUpType> GetMakeupTypeId(int makeupTypeID)
        {
            List<string> error = new List<string>();
            ValidateID(makeupTypeID, error);
            if (error.Count > 0)
            {
                return MakeErrorResponse<MakeUpType>(error);
            }
            return MakeupTypeHandler.GetMakeupTypeID(makeupTypeID);
        }

        public static Json<MakeUpType> UpdateMakeupType(string makeupTypeID, string makeupTypeName)
        {
            List<string> error = new List<string>();
            ValidateID(makeupTypeID, error);
            ValidateName(makeupTypeName, error);

            if (error.Count > 0)
            {
                return MakeErrorResponse<MakeUpType>(error);
            }

            return MakeupTypeHandler.UpdateMakeupType(Convert.ToInt32(makeupTypeID), makeupTypeName);
        }


        private static Json<T> MakeErrorResponse<T>(List<string> error)
        {
            string text = string.Join("|", error);
            return new Json<T>
            {
                Text = text,
                Success = false,
                Response = default
            };
        }

        public static Json<MakeUpType> RemoveMakeupType(string makeupTypeID)
        {
            List<string> errors = new List<string>();
            ValidateID(makeupTypeID, errors);
            if (errors.Count > 0)
            {
                return MakeErrorResponse<MakeUpType>(errors);
            }
            return MakeupTypeHandler.RemoveMakeupType(Convert.ToInt32(makeupTypeID));
        }

        private static void ValidateID(int ID, List<string> error)
        {
            if (ID <= 0)
            {
                error.Add("ID must > 0");
            }
        }

        private static void ValidateID(string ID, List<string> error)
        {
            if (!int.TryParse(ID, out int idInt) || idInt <= 0)
            {
                error.Add("ID must > 0");
            }
        }
    }
}