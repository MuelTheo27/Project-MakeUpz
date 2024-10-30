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
    public class CartHandler
    {

        public static Json<List<Cart>> RemoveCartsByID(List<int> cartID)
        {
            string errorMessage = "Error to remove cart: ";
            foreach (int cartIDs in cartID)
            {
                if (CartRepository.RemoveCartByID(cartIDs) == 0)
                {
                    errorMessage += cartID + ", ";
                }
            }
            if (errorMessage != "Error to remove cart: ")
            {
                return new Json<List<Cart>>
                {
                    Text = errorMessage.Substring(0, errorMessage.Length - 2),
                    Success = false,
                    Response = null
                };
            }
            return new Json<List<Cart>>
            {
                Text = "All Cart removed",
                Success = true,               
                Response = null
            };
        }
        public static int GenerateID()
        {
            Cart cart = CartRepository.GetLastCart();
            if (cart == null)
            {
                return 1;
            }
            return cart.CartID + 1;
        }
        public static Json<Cart> GetCartID(int ID)
        {
            Cart cart = CartRepository.CreateCartID(ID);
            if (cart == null)
            {
                return new Json<Cart>
                {
                    Text = "Cart not found",
                    Success = false,
                    Response = null
                };
            }
            return new Json<Cart>
            {
                Text = "Cart found",
                Success = true,               
                Response = cart
            };
        }
        public static Json<Cart> InsertCart(int userID, int makeupID, int Quantity)
        {
            Cart cart = CartsFactory.CreateCart(GenerateID(), userID, makeupID, Quantity);
            if (CartRepository.InsertCart(cart) == 0)
            {
                return new Json<Cart>
                {
                    Text = "Error to insert cart",
                    Success = false,
                    Response = null
                };
            }
            return new Json<Cart>
            {
                Text = "Cart inserted",
                Success = true,
                Response = cart
            };
        }
        public static Json<List<Cart>> GetCartUserID(int userID)
        {
            List<Cart> carts = CartRepository.CartByUserID(userID);
            if (carts.Count == 0)
            {
                return new Json<List<Cart>>
                {
                    Text = "Cart not found",
                    Success = false,                  
                    Response = null
                };
            }
            return new Json<List<Cart>>
            {
                Text = "Cart found",
                Success = true,     
                Response = carts
            };
        }
    }
}