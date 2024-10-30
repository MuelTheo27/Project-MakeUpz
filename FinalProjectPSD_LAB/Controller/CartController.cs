using FinalProjectPSD_LAB.Handler;
using FinalProjectPSD_LAB.Models;
using FinalProjectPSD_LAB.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Controller
{
    public class CartController
    {

        public static Json<Cart> InsertCart(int userID, int makeupID, int Quantity)
        {
            List<string> error = new List<string>();
            int uId = UserIdValidate(userID, error);
            int mId = MakeupIdValidate(makeupID, error);
            int qty = QuantityValidate(Quantity, error);
            if (error.Count > 0)
            {
                return GenerateErrorResponse<Cart>(error);
            }
            return CartHandler.InsertCart(userID, makeupID, Quantity);
        }


        public static Json<Cart> GetCartID(int cartID)
        {
            List<string> error = new List<string>();
            int cId = CartIDIsValidate(cartID, error);
            if (error.Count > 0)
            {
                return GenerateErrorResponse<Cart>(error);
            }
            return CartHandler.GetCartID(cartID);
        }

        public static Json<List<Cart>> RemoveCartsID(List<int> cartID)
        {
            List<string> error = new List<string>();
            foreach (var cartId in cartID)
            {
                CartIDIsValidate(cartId, error);
            }
            if (error.Count > 0)
            {
                return GenerateErrorResponse<List<Cart>>(error);
            }
            return CartHandler.RemoveCartsByID(cartID);
        }

        private static Json<T> GenerateErrorResponse<T>(List<string> errors)
        {
            string message = "";
            foreach (var error in errors)
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

        public static Json<List<Cart>> GetCardUserID(int userID)
        {
            List<string> error = new List<string>();
            int uId = UserIdValidate(userID, error);
            if (error.Count > 0)
            {
                return GenerateErrorResponse<List<Cart>>(error);
            }
            return CartHandler.GetCartUserID(userID);
        }
        private static int MakeupIdValidate(int makeupID, List<string> error)
        {
            if (makeupID <= 0)
            {
                error.Add("Makeup ID must > 0");
            }
            return makeupID;
        }
        private static int UserIdValidate(int userID, List<string> error)
        {
            if (userID <= 0)
            {
                error.Add("User ID must > 0");
            }
            return userID;
        }

        private static int QuantityValidate(int Quantity, List<string> error)
        {
            if (Quantity <= 0)
            {
                error.Add("Quantity must > 0");
            }
            return Quantity;
        }

        private static int CartIDIsValidate(int cartID, List<string> error)
        {
            if (cartID <= 0)
            {
                error.Add("Cart ID must > 0");
            }
            return cartID;
        }
    }
}