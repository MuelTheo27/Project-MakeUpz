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
    public class UserHandler
    {
        public static Json<User> UpdatePassword(int userID, string Password)
        {
            User user = UserRepository.GetUserID(userID);
            user.UserPassword = Password;
            if (UserRepository.UpdateUser(user) == 0)
            {
                return new Json<User>
                {
                    Text = "Failed updated user",
                    Success = false,
                    Response = null
                };
            }
            return new Json<User>
            {
                Text = "Success updated user",
                Success = true,
                Response = user
            };
        }

        public static Json<User> UpdateUser(int userID, string userName, string userEmail, DateTime userDob, string userGender)
        {
            User user = UserRepository.GetUserID(userID);
            user.Username = userName;
            user.UserEmail = userEmail;
            user.UserDOB = userDob;
            user.UserGender = userGender;
            if (UserRepository.UpdateUser(user) == 0)
            {
                return new Json<User>
                {
                    Text = "Failed to update user",
                    Success = false,
                    Response = null
                };
            }
            return new Json<User>
            {
                Text = "Success update user",
                Success = true,
                Response = user
            };
        }

        public static Json<List<User>> GetAllUsers()
        {
            List<User> users = UserRepository.GetAllUsers();
            if (users.Count > 0)
            {
                return new Json<List<User>>
                {
                    Text = "Success",
                    Success = true,
                    Response = users
                };
            }
            return new Json<List<User>>
            {
                Text = "No users found",
                Success = false,
                Response = null
            };
        }
         public static int GenerateID()
        {
            User user = UserRepository.GetLastUser();

            if (user == null)
            {
                return 1;
            }
            return user.UserID + 1;
        }

        public static Json<User> Login(string username, string password)
        {
            User user = UserRepository.GetUserUsername(username);
            if (user != null && user.UserPassword == password)
            {
                return new Json<User>
                {
                    Text = "Success",
                    Success = true,
                    Response = user
                };
            }
            return new Json<User>
            {
                Text = "Invalid user data",
                Success = false,
                Response = null
            };
        }
        public static Json<User> GetUserId(int ID)
        {
            User user = UserRepository.GetUserID(ID);
            if (user != null)
            {
                return new Json<User>
                {
                    Text = "Success",
                    Success = true,
                    Response = user
                };
            }
            return new Json<User>
            {
                Text = "User not found",
                Success = false,
                Response = null
            };
        }
        public static Json<User> Register(string username, string email, string gender, DateTime dob, string password)
        {
            if (UserRepository.GetUserUsername(username) != null)
            {
                return new Json<User>
                {
                    Text = "User already exist",
                    Success = false,
                    Response = null
                };
            }

            User user = UserFactory.CreateUser(GenerateID(), username, email, gender,dob, password);

            if (UserRepository.InsertUser(user) == 0)
            {
                return new Json<User>
                {
                    Text = "Something went wrong",
                    Success = false,
                    Response = null
                };
            }

            return new Json<User>
            {
                Text = "Success",
                Success = true,
                Response = user
            };
        }
    }
}