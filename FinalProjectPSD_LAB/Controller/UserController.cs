using FinalProjectPSD_LAB.Handler;
using FinalProjectPSD_LAB.Models;
using FinalProjectPSD_LAB.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Controller
{
    public class UserController
    {
        public static Json<List<User>> GetAllUsers()
        {
            return UserHandler.GetAllUsers();
        }
        public static Json<User> UpdatePassword(int userID, string oldPassword, string newPassword)
        {
            List<string> error = new List<string>();
            UserIdValidate(userID, error);
            PasswordIsValid(oldPassword, error);
            PasswordIsValid(newPassword, error);
            if (oldPassword == newPassword)
            {
                error.Add("New password must be not the same from your old password");
            }
            if (error.Count > 0)
            {
                return GenerateErrorResponse<User>(error);
            }
            return UserHandler.UpdatePassword(userID, newPassword);
        }

        private static void UsernameIsValid(string username, List<string> error)
        {
            if (string.IsNullOrEmpty(username))
            {
                error.Add("Username is empty");
            }
            else
            {
                if (username.Length < 5 || username.Length > 15)
                {
                    error.Add("Username length must be between 5 and 15");
                }
            }
        }
        public static Json<User> GetUserID(int ID)
        {
            List<string> errors = new List<string>();
            UserIdValidate(ID, errors);
            if (errors.Count > 0)
            {
                return GenerateErrorResponse<User>(errors);
            }
            return UserHandler.GetUserId(ID);
        }

        public static Json<User> Login(string username, string password)
        {
            List<string> error = new List<string>();
            UsernameIsValid(username, error);
            PasswordIsValid(password, error);
            if (error.Count > 0)
            {
                return GenerateErrorResponse<User>(error);
            }
            return UserHandler.Login(username, password);
        }

        public static Json<User> UpdateUser(int userID, string username, string useremail, DateTime userDob, string usergender)
        {
            List<string> error = new List<string>();
            UserIdValidate(userID, error);
            UsernameIsValid(username, error);
            EmailIsValid(useremail, error);
            DobIsValid(userDob, error);
            GenderIsValid(usergender, error);

            if (error.Count > 0)
            {
                return GenerateErrorResponse<User>(error);
            }
            return UserHandler.UpdateUser(userID, username, useremail, userDob, usergender);
        }
        private static Json<T> GenerateErrorResponse<T>(List<string> errorr)
        {
            string message = "";
            foreach (var error in errorr)
            {
                message += error + "|";
            }
            return new Json<T>
            {
                Text = message,
                Success = false,
                Response = default
            };
        }

        private static void UserIdValidate(int userID, List<string> errorr)
        {
            if (userID <= 0)
            {
                errorr.Add("User Id must be greater than 0");
            }
        }
        public static Json<User> Register(string username, string email, DateTime dob, string gender, string password)
        {
            List<string> error = new List<string>();
            UsernameIsValid(username, error);
            EmailIsValid(email, error);
            DobIsValid(dob, error);
            GenderIsValid(gender, error);
            PasswordIsValid(password, error);
            if (error.Count > 0)
            {
                return GenerateErrorResponse<User>(error);
            }
            return UserHandler.Register(username, email,gender,dob, password);
        }


        private static void PasswordIsValid(string password, List<string> error)
        {
            if (string.IsNullOrEmpty(password))
            {
                error.Add("Password is empty");
            }
            else
            {
                if (!password.All(char.IsLetterOrDigit))
                {
                    error.Add("Password can only consist of alfanumeric character");
                }
            }
        }


        private static void GenderIsValid(string gender, List<string> error)
        {
            if (string.IsNullOrEmpty(gender)) { error.Add("U must Choose Gender"); }
        }

        private static void DobIsValid(DateTime dob, List<string> error)
        {
            if (dob == null) { error.Add("Choose ur birth"); }
        }

        private static void EmailIsValid(string email, List<string> error)
        {
            if (string.IsNullOrEmpty(email))
            {
                error.Add("Email is empty");
            }
            else
            {
                if (!email.EndsWith(".com"))
                {
                    error.Add("Email must ends with .com");
                }
            }
        }
    }
}