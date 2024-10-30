using FinalProjectPSD_LAB.Handlers;
using FinalProjectPSD_LAB.Models;
using FinalProjectPSD_LAB.Module;
using FinalProjectPSD_LAB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Controller
{
    public class MakeupController
    {
        public static Json<Makeup> GetMakeupID(int ID)
        {
            return MakeupHandler.GetMakeupID(ID);
        }
        private static Json<string> InsertMakeupRequestValidate(string name, string price, string weight, string typeid, string brandid)
        {
            List<string> errorr = new List<string>();
            NameValid(name, errorr);
            PriceValid(price, errorr);
            WeightValid(weight, errorr);
            TypeIDValid(typeid, errorr);
            BrandIDValid(brandid, errorr);
            if (errorr.Count > 0)
            {
                string message = "";
                foreach (var error in errorr)
                {
                    message += error + "|";
                }

                return new Json<string>
                {
                    Text = "Validate Error",
                    Success = false,
                    Response = message
                };
            }

            return new Json<string>
            {
                Text = "Success",
                Success = true,
                Response = null
            };
        }

        public static Json<List<Makeup>> GetAllMakeup()
        {
            return MakeupHandler.GetAllMakeup();
        }
        public static Json<Makeup> Update(string ID, string name, string price, string weight, string typeid, string brandid)
        {
            Json<string> response = UpdateRequestValidate(ID, name, price, weight, typeid, brandid);

            if (!response.Success)
            {
                return new Json<Makeup>
                {
                    Text = response.Response,
                    Success = false,
                    Response = null
                };
            }

            return MakeupHandler.UpdateMakeup(Convert.ToInt32(ID), name, Convert.ToInt32(price), Convert.ToInt32(weight), Convert.ToInt32(typeid), Convert.ToInt32(brandid));

        }
        public static Json<Makeup> DeleteMakeup(int ID)
        {
            List<string> errorr = new List<string>();
            IDValid(ID.ToString(), errorr);
            if (errorr.Count > 0)
            {
                string message = "";
                foreach (var error in errorr)
                {
                    message += error + "|";
                }

                return new Json<Makeup>
                {
                    Text = "Validate Error",
                    Success = false,
                    Response = null
                };
            }
            return MakeupHandler.DeleteMakeup(ID);
        }

        public static Json<Makeup> InsertMakeup(string name, string price, string weight, string typeid, string brandid)
        {
            Json<string> response = InsertMakeupRequestValidate(name, price, weight, typeid, brandid);

            if (!response.Success)
            {
                return new Json<Makeup>
                {
                    Text = response.Response,
                    Success = false,
                    Response = null
                };
            }

            return MakeupHandler.InsertMakeup(name, Convert.ToInt32(price), Convert.ToInt32(weight), Convert.ToInt32(typeid), Convert.ToInt32(brandid));

        }

        private static void BrandIDValid(string brandID, List<string> error)
        {
            try
            {
                if (brandID == null || brandID == "")
                {
                    error.Add("Brand ID is null");
                    return;
                }
                int brandIDInt = Convert.ToInt32(brandID);
                if (MakeupRepository.GetMakeupBrandID(brandIDInt) == null)
                {
                    error.Add("Brand ID cannot be found");
                }
            }
            catch (Exception)
            {
                error.Add("Brand Id must be a number");

            }
        }
        private static Json<string> UpdateRequestValidate(string id, string name, string price, string weight, string typeid, string brandid)
        {
            List<string> errorr = new List<string>();
            IDValid(id, errorr);
            NameValid(name, errorr);
            PriceValid(price, errorr);
            WeightValid(weight, errorr);
            TypeIDValid(typeid, errorr);
            BrandIDValid(brandid, errorr);
            if (errorr.Count > 0)
            {
                string message = "";
                foreach (var error in errorr)
                {
                    message += error + "|";
                }

                return new Json<string>
                {
                    Text = "Validate Error",
                    Success = false,
                    Response = message
                };
            }

            return new Json<string>
            {
                Text = "Success",
                Success = true,
                Response = null
            };
        }
        private static void IDValid(string ID, List<string> error)
        {
            try
            {
                int? idInt = Convert.ToInt32(ID);
                if (!idInt.HasValue)
                {
                    error.Add("ID is null");
                }
            }
            catch (Exception)
            {
                error.Add("Id must an integer");
            }
        }
        private static void NameValid(string name, List<string> error)
        {
            if (string.IsNullOrEmpty(name))
            {
                error.Add("Name is null");
            }
            else
            {
                if (name.Length < 1 || name.Length > 99)
                {
                    error.Add("Name length must be 1-99 character");
                }
            }
        }
        private static void TypeIDValid(string typeID, List<string> errors)
        {
            try
            {
                if (typeID == null || typeID == "")
                {
                    errors.Add("Type ID is null");
                    return;
                }
                int typeidInt = Convert.ToInt32(typeID);
                if (MakeUpTypeRepository.GetMakeupTypeID(typeidInt) == null)
                {
                    errors.Add("Type ID null");
                }
            }
            catch (Exception)
            {
                errors.Add("Type Id must an integer");

            }
        }
        private static void PriceValid(string price, List<string> error)
        {
            if (string.IsNullOrEmpty(price))
            {
                error.Add("Price can't be empty'");
                return;
            }

            if (int.TryParse(price, out int priceInt))
            {
                if (priceInt <= 0)
                {
                    error.Add("Price must >= 1");
                }
            }
            else
            {
                error.Add("Price must an integer");
            }
        }
        private static void WeightValid(string weight, List<string> error)
        {
            if (string.IsNullOrEmpty(weight))
            {
                error.Add("Weight cannot be empty or null");
                return;
            }

            if (int.TryParse(weight, out int weightInt))
            {
                if (weightInt > 1500)
                {
                    error.Add("Weight cannot be greater than 1500");
                }
            }
            else
            {
                error.Add("Weight must be a number");
            }
        }
    }
}