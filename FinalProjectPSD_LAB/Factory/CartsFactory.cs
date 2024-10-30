using FinalProjectPSD_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace FinalProjectPSD_LAB.Factory
{
    public class CartsFactory
    {
        public static Cart CreateCart(int cartID, int userID, int makeupID, int quantity)
        {
            return new Cart
            {
                CartID = cartID,
                UserID = userID,
                MakeupID = makeupID,
                Quantity = quantity
            };
        }
    }
}