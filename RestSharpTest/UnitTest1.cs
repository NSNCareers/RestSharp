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
        private string id;
        private string idUpdated;
        private string idRemoved;

        [SetUp]
        public void Setup()
        {
            shoppingCart = ShoppingCartData.ShoppingCartInit();
        }

        [Test, Order(1)]
        public void GetToken()
        {
            var token = shoppingCart.Id;
            var results = GetRequest.GetToken(token);
            Assert.NotNull(results);
        }

        [Test, Order(5)]
        public void GetUserFromShoppingCartAsyncJson()
        {
            id = GetRequest.results; //
            var results = GetRequest.GetUserFromShoppingCartAsyncJson(int.Parse(id));
            Assert.IsInstanceOf<object>(results);
        }

        [Test, Order(3)]
        public void GetAllUsersFromShoppingCartAsyncJson()
        {
            var token = shoppingCart.Id;
            var results = GetRequest.GetAllUsersFromShoppingCart(token);
            Assert.IsInstanceOf<object>(results);
        }

        [Test,Order(2)]
        public void CreateShoppingCartAsyncJson()
        {
            var itemId = shoppingCart.Id;
            var res = GetRequest.CreateShoppingCartAsyncJson(shoppingCart,itemId);
            var res1 = res.Content.ToString().TrimStart('"');
            var results = res1.ToString().TrimEnd('"');
            id = GetRequest.results;
            var responce = $"Successfully added Item with Id:{id}";
            Assert.AreEqual(results,responce);
        }

        [Test, Order(4)]
        public void UpdateShoppingCartAsyncJson()
        {
            var itemId = int.Parse(id);
            _shoppingCart = ShoppingCartData.ShoppingCartUpdate(int.Parse(id));
            var res = GetRequest.UpdateShoppingCartAsyncJson(_shoppingCart,itemId);
            var res1 = res.Content.ToString().TrimStart('"');
            var results = res1.ToString().TrimEnd('"');
            idUpdated = GetRequest.updateResults;
            var responce = $"Successfully updated user with Id:{idUpdated}";
            Assert.AreEqual(results, responce);
        }

        [Test, Order(6)]
        public void RemoveShoppingCartAsyncJson()
        {
            var itemId = int.Parse(id);
            var res = GetRequest.DeleteShoppingCartAsyncJson(itemId);
            var res1 = res.Content.ToString().TrimStart('"');
            var results = res1.ToString().TrimEnd('"');
            idRemoved = GetRequest.removedResults;
            var responce = $"Successfully removed User with Id:{id}";
            Assert.AreEqual(results, responce);
        }
    }
}