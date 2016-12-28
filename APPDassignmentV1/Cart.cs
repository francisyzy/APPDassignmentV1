using APPDassignmentV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPDassignmentV1
{
    
        public static class shoppingCart
        {
            public static void initializeShoppingCart()//When program is opened, shopping cart will be created
            {
                CartItems = new List<CartItem>();
            }
            private static List<CartItem> CartItems { get; set; }
            public static void AddCartItem(CartItem inItem)//Add item into cart
            {
                //inItem is the item that will be added to cart
                CartItems.Add(inItem);
            }
            public static void RemoveCartItem(string inResourceId)//Remove item from shopping card
            {
                //Read the input resoure id to remove that item with the matching resource id
                CartItems.RemoveAll(input => input.resourceId == inResourceId);
            }
            public static List<CartItem> GetCartItems()
            {
                return CartItems;
            }
            public static double totalprice()
            {
                double a = 0;
                foreach (CartItem item in CartItems)
                {
                    a += item.itemPrice;
                }
                return a;
        }
    }

        public class CartItem : Resource
        {
            public CartItem(Resource inResource)
            {
                this.resourceId = inResource.resourceId;
                this.price = inResource.price;
                this.resourceType = inResource.resourceType;
                

            }
            public DateTime BookingDateTime { get; set; }
            public DateTime BookingStartDateAndTime { get; set; }
            public DateTime BookingEndDateAndTime { get; set; }
            public double itemPrice;
            public double CalculatePrice(DateTime S, DateTime E)
            {
                double cartItemPrice;
                TimeSpan totalDate = E - S;
                cartItemPrice = totalDate.Days * this.price;
                this.itemPrice = cartItemPrice;
                return cartItemPrice;
            }

    }
}
