using FinalProjectPSD_LAB.Factory;
using FinalProjectPSD_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Repository
{
    public class CartRepository
    {
        private static Database_MakeMeUpzzEntities3 db = new Database_MakeMeUpzzEntities3();

        public static int InsertCart(Cart cart)
        {
            db.Carts.Add(cart);
            return db.SaveChanges();
        }

        public static List<Cart> CartByUserID(int userID)
        {
            return db.Carts.Where(x => x.UserID == userID).ToList();
        }

        public static Cart CreateCartID(int cartID)
        {
            return db.Carts.Find(cartID);
        }


        public static Cart GetLastCart()
        {
            return db.Carts.ToList().LastOrDefault();
        }
        public static int RemoveCartByID(int cartID)
        {
            Cart delete = CreateCartID(cartID);
            if (delete != null)
            {
                db.Carts.Remove(delete);
                return db.SaveChanges();
            }
            return 0;
        }
    }
}