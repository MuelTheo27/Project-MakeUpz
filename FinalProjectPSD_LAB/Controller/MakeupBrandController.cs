using FinalProjectPSD_LAB.Handler;
using FinalProjectPSD_LAB.Models;
using FinalProjectPSD_LAB.Module;
using FinalProjectPSD_LAB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Controller
{
    public class MakeupBrandController
    {
        public static Json<MakeupBrand> GetMakeupBrandID(int ID)
        {
            return MakeupBrandHandler.GetMakeupBrandID(ID);
        }
        public static Json<MakeupBrand> InsertMakeupBrand(string name, string rating)
        {
            Json<string> response = InsertMakeupBrandRequestValidate(name, rating);
            if (!response.Success)
            {
                return new Json<MakeupBrand>
                {
                    Text = response.Response,
                    Success = false,
                    Response = null
                };
            }
            return MakeupBrandHandler.InsertMakeupBrand(name, Convert.ToInt32(rating));
        }
        public static Json<MakeupBrand> RemoveMakeupBrandID(string ID)
        {
            List<string> errors = new List<string>();
            IDValid(ID, errors);
            if (errors.Count > 0)
            {
                string message = "";
                foreach (var error in errors)
                {
                    message += error + "|";
                }

                return new Json<MakeupBrand>
                {
                    Text = "Error",
                    Success = false,
                    Response = null
                };
            }
            return MakeupBrandHandler.RemoveMakeupBrandById(Convert.ToInt32(ID));
        }
        private static Json<string> InsertMakeupBrandRequestValidate(string name, string rating)
        {
            List<string> errors = new List<string>();
            NameValid(name, errors);
            RatingValid(rating, errors);
            if (errors.Count > 0)
            {
                string message = "";
                foreach (var error in errors)
                {
                    message += error + "|";
                }

                return new Json<string>
                {
                    Text = "Error",
                    Success = false,
                    Response = message
                };
            }
            return new Json<string>
            {
                Text = "Confirmed",
                Success = true,
                Response = null
            };
        }
        public static Json<List<MakeupBrand>> GetAllMakeupBrands()
        {
            return MakeupBrandHandler.GetAllMakeupBrands();
        }
        private static void RatingValid(string rating, List<string> errors)
        {
            if (string.IsNullOrEmpty(rating))
            {
                errors.Add("Rating can't empty");
                return;
            }

            if (int.TryParse(rating, out int ratingInt))
            {
                if (ratingInt < 0 || ratingInt > 100)
                {
                    errors.Add("Rating must 0- 100");
                }
            }
            else
            {
                errors.Add("Rating must an integer");
            }
        }

        private static void IDValid(string ID, List<string> errors)
        {
            try
            {
                int? idInt = Convert.ToInt32(ID);
                if (!idInt.HasValue)
                {
                    errors.Add("Id is empty");
                }
            }
            catch (Exception)
            {
                errors.Add("Id must an integer");
            }
        }
        private static void BrandIDValid(string brandid, List<string> errors)
        {
            try
            {
                if (brandid == null || brandid == "")
                {
                    errors.Add("Brand ID is null");
                    return;
                }
                int brandidInt = Convert.ToInt32(brandid);
                if (MakeUpBrandRepository.GetMakeupBrandID(brandidInt) == null)
                {
                    errors.Add("Brand ID cannot be found");
                }
            }
            catch (Exception)
            {
                errors.Add("Brand Id must be a number");

            }
        }
        public static Json<MakeupBrand> UpdateMakeupBrand(string ID, string brandName, string brandRating)
        {
            Json<string> response = UpdateMakeupBrandValid(ID, brandName, brandRating);
            if (!response.Success)
            {
                return new Json<MakeupBrand>
                {
                    Text = response.Response,
                    Success = false,
                    Response = null
                };
            }

            return MakeupBrandHandler.UpdateMakeupBrand(Convert.ToInt32(ID), brandName, Convert.ToInt32(brandRating));
        }
        private static Json<string> UpdateMakeupBrandValid(string ID, string brandName, string brandRating)
        {
            List<string> errors = new List<string>();
            BrandIDValid(ID, errors);
            NameValid(brandName, errors);
            RatingValid(brandRating, errors);

            if (errors.Count > 0)
            {
                string message = "";
                foreach (var error in errors)
                {
                    message += error + "|";
                }

                return new Json<string>
                {
                    Text = "Error",
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
        private static void NameValid(string name, List<string> errors)
        {
            if (string.IsNullOrEmpty(name))
            {
                errors.Add("Name is empty");
            }
            else
            {
                if (name.Length < 1 || name.Length > 99)
                {
                    errors.Add("Name length must 1-99");
                }
            }
        }
    }
}