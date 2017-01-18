using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace APPDassignmentV1.Models
{

    public class ResourceData//main data structure
    {
        public List<Resource> resource { get; set; }
        public List<region> region { get; set; }
        public List<resourceType> resourceTypes { get; set; }
        public List<picture> pictures { get; set; }
        public List<booking> bookings { get; set; }
    }

    public class resourceType//data structure for resource type as there is resource type id
    {
        public string resourceTypeName { get; set; }
        public string resourceTypeID { get; set; }
    }
    public class Resource//main data type for abstraction
    {

        public string resourceId { get; set; }
        public int postalCode { get; set; }
        public string fullAddress { get; set; }
        public int regionId { get; set; } //maybe call in map api to look up MRT
        public double price { get; set; }
        public int resourceTypeID { get; set; } //1 = unit || 2= room
        public int resourceSize { get; set; }
        public int aircon { get; set; }
    }
    public class picture
    {
        public int pictureId { get; set; }
        public byte[] picturee { get; set; }
    }

    public class region
    {
        public int regionId { get; set; }
        public string regionName { get; set; }
    }

    public class booking
    {
        public int bookingId { get; set; }
        public DateTime bookingDate { get; set; }
        public DateTime bookingStartDate { get; set; }
        public DateTime bookingEndDate { get; set; }
        public int resourceId { get; set; }
        public string email { get; set; }
    }

    public class user //user class
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phoneNum { get; set; }
    }

    public class currentUser : user //something like shopping cart but to check which user is currently using the program
    {
        public static currentUser cu;
        public static void initializeCurrentuser()
        {
            cu = new currentUser();
        }
        public void setcurrentUser(user u)
        {
            cu.firstName = u.firstName;
            cu.lastName = u.lastName;
            cu.email = u.email;
            cu.phoneNum = u.phoneNum;
        }

        //public currentUser(user u)
        //{
        //    this.firstName = u.firstName;
        //    this.lastName = u.lastName;
        //    this.email = u.email;
        //    this.phoneNum = u.phoneNum;
        //    this.creditCardNum = u.creditCardNum;
        //}

        public static currentUser GetCurrentUser()
        {
            return cu;
        }
    }

    //public class shoppingCartItem:Resource
    //{
    //    public shoppingCartItem(Resource inResource)
    //    {
    //        this.resourceId = inResource.resourceId;
    //        this.address = inResource.address;
    //        this.price = inResource.price;
    //        this.resourceType = inResource.resourceType;
    //    }
    //    public DateTime startDate { get; set; }
    //    public DateTime endDate { get; set; }
    //    public double itemPrice;
    //    public double CalculatePrice (DateTime S, DateTime E)
    //    {
    //        double cartItemPrice;
    //        TimeSpan totalDate = E - S;
    //        cartItemPrice = totalDate.Days * this.price;
    //        this.itemPrice = cartItemPrice;
    //        return cartItemPrice;
    //    }
    //}

    //public class shoppingCart
    //{
    //    private static List<shoppingCartItem> shoppingCartItems { get; set; }
    //    public static void initializeShoppingCart()
    //    {
    //        shoppingCartItems = new List<shoppingCartItem>();
    //    }

    //    public static void AddCartItem(shoppingCartItem inItem)
    //    {
    //        shoppingCartItems.Add(inItem);
    //    }

    //    public static void RemoveCartItem(string inResourceId)
    //    {
    //        shoppingCartItems.RemoveAll(input => input.resourceId == inResourceId);
    //        //kiv
    //    }

    //    public static List<shoppingCartItem> GetCartItem()
    //    {
    //        return shoppingCartItems;
    //    }

    //    public double totalPrice()
    //    {
    //        double a = 0;
    //        foreach (shoppingCartItem item in shoppingCartItems)
    //        {
    //            a += item.itemPrice;
    //        }
    //        return a;
    //    }
    //}
    //shopping cart code moved to cart.cs
}