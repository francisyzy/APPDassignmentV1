using APPDassignmentV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPDassignmentV1
{
    class Cart
    {
        public static class shoppingCart
        {
            public static void initializeShoppingCart()
            {
                CartItems = new List<CartItem>();
            }
            private static List<CartItem> CartItems { get; set; }
            public static void AddCartItem(CartItem inItem)
            {
                CartItems.Add(inItem);
            }
            public static void RemoveCartItem(int inResourceId)
            {
                CartItems.RemoveAll(input => input.ResourceId == inResourceId);
            }
            public static List<CartItem> GetCartItems()
            {
                return CartItems;
            }
        }

        public class CartItem : Resource
        {
            public CartItem(Resource inResource)
            {
                this.ResourceId = inResource.ResourceId;
                this.Name = inResource.Name;
                this.ChargePerHour = inResource.ChargePerHour;
            }
            public DateTime BookingDateTime { get; set; }
            public DateTime BookingStartDateAndTime { get; set; }
            public DateTime BookingEndDateAndTime { get; set; }
            public int SubTotal
            {
                get
                {
                    return 0;
                }
            }
        }//End of Cart
    }
}
