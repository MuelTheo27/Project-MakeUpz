using FinalProjectPSD_LAB.Factory;
using FinalProjectPSD_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace FinalProjectPSD_LAB.Repository
{
    public class UserRepository
    {
        private static Database_MakeMeUpzzEntities3 db = new Database_MakeMeUpzzEntities3();
        public static List<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public static User GetLastUser()
        {
            return db.Users.ToList().LastOrDefault();
        }


        public static User GetUserUsername(string username)
        {
            return db.Users.Where(u  => u.Username == username).FirstOrDefault();
        }

        public static int UpdateUser(User user)
        {
            User User = GetUserID(user.UserID);
            User.Username = user.Username;
            User.UserEmail = user.UserEmail;
            User.UserGender = user.UserGender;
            User.UserPassword = user.UserPassword;
            return db.SaveChanges();
        }

        public static User GetUserID(int ID)
        {
            return db.Users.Find(ID);
        }

        public static int InsertUser(User user)
        {
            db.Users.Add(user);
            return db.SaveChanges();
        }
    }
}