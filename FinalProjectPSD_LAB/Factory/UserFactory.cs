using FinalProjectPSD_LAB.Models;
using FinalProjectPSD_LAB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Factory
{
    public class UserFactory
    {
        public static User CreateUser(int userID,string name, string email, string gender, DateTime dob, string password)
        {
            return new User
            {
                UserID = userID,
                Username = name,
                UserEmail = email,
                UserDOB = dob,
                UserGender = gender,
                UserRole = "customer",
                UserPassword = password
            };
        }
    }
}