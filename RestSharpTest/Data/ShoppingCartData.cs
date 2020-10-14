using RestSharpTest.Models;
using System;
using System.Collections.Generic;

namespace RestSharpTest.Data
{
    public static class ShoppingCartData
    {
        private static Random random = new Random();

        private static int id = 100;

        public static ShoppingCart ShoppingCartInit()
        {
            var nextInteger = random.Next(1,20000);
            ShoppingCart shoppingCart = new ShoppingCart
            {
                Gender = "Male",
                CustomerName = $"Regina{nextInteger}",
                OrderQuantity = "435",
                Price = 43.00m,
                Message = "My name is Regina",
                Address = new CustomerAddress
                {
                    HouseNumber = 22,
                    Street = "London Street",
                    Town = "Coventry",
                    PostCode = "CV2 3HH"
                },
                Item = new List<Item>
                {
                   new Item
                   {
                    Size=34,
                    Weight=1002,
                    Seller="Amazon",
                    ItemName = "Rice"
                   },
                    new Item
                   {
                    Size=35,
                    Weight=1003,
                    Seller="Argos",
                    ItemName = "Fufu"
                   },
                }
            };
            return shoppingCart;
        }

        public static ShoppingCart ShoppingCartUpdate(int id)
        {
            var nextInteger = random.Next(1, 20000);
            ShoppingCart shoppingCart = new ShoppingCart
            {
                Id = id,
                Gender = "Female",
                CustomerName = $"Betina{nextInteger}",
                OrderQuantity = "0998",
                Price = 35.00m,
                Message = "My name is Betina",
                Address = new CustomerAddress
                {
                    Id = id,
                    CartId = id,
                    HouseNumber = 44,
                    Street = "New Street",
                    Town = "Ohio",
                    PostCode = "CV5 6HH"
                },
                Item = new List<Item>
                {
                   new Item
                   {
                    Id = id,
                    CartId = id,
                    Size=345,
                    Weight=5009,
                    Seller="Argos",
                    ItemName = "Tea"
                   },
                    new Item
                   {
                    Id = id,
                    CartId = id,
                    Size=85,
                    Weight=8003,
                    Seller="Asda",
                    ItemName = "Meat"
                   },
                }
            };
            return shoppingCart;
        }
    }
}
