using NUnit.Framework;
using RestSharpApiTest.RestSharp_Handler;
using RestSharpTest.Data;
using RestSharpTest.Models;

namespace RestSharpTest
{
    public class Tests
    {
        private ShoppingCart shoppingCart;
        private ShoppingCart _shoppingCart;

        [SetUp]
        public void Setup()
        {
            shoppingCart = ShoppingCartData.ShoppingCartInit();
            _shoppingCart = ShoppingCartData.ShoppingCartUpdate();
        }

        [Test]
        public void GetToken()
        {
            var token = shoppingCart.Id;
            var results = GetRequest.GetToken(token);
            Assert.NotNull(results);
        }

        [Test]
        public void GetUserFromShoppingCartAsync()
        {
            var itemId = shoppingCart.Id;
            var results = GetRequest.GetUserFromShoppingCartAsync(itemId);
            Assert.IsInstanceOf<ShoppingCart>(results);
        }

        [Test]
        public void GetUserFromShoppingCartAsyncJson()
        {
            var itemId = shoppingCart.Id;
            var results = GetRequest.GetUserFromShoppingCartAsyncJson(itemId);
            Assert.IsInstanceOf<ShoppingCart>(results);
        }

        [Test]
        public void GetAllUsersFromShoppingCartAsyncJson()
        {
            var token = shoppingCart.Id;
            var results = GetRequest.GetAllUsersFromShoppingCart(token);
            Assert.IsInstanceOf<ShoppingCart>(results);
        }

        [Test]
        public void CreateShoppingCartAsyncJson()
        {
            var itemId = shoppingCart.Id;
            var results = GetRequest.CreateShoppingCartAsyncJson(shoppingCart,itemId);
            var responce = $"Successfully added Item with Id:{itemId}";
            Assert.AreEqual(results.Content,responce);
        }

        [Test]
        public void DeleteShoppingCartAsyncJson()
        {
            var itemId = shoppingCart.Id;
            var results = GetRequest.DeleteShoppingCartAsyncJson(itemId);
            var responce = $"Successfully removed User with Id:{itemId}";
            Assert.AreEqual(results, responce);
        }

        [Test]
        public void UpdateShoppingCartAsyncJson()
        {
            var itemId = shoppingCart.Id;
            var results = GetRequest.UpdateShoppingCartAsyncJson(_shoppingCart,itemId);
            Assert.NotNull(results);
        }
    }
}