using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using RestSharpApiTest.Config;
using RestSharpTest.Models;
using System;
using System.Threading.Tasks;

namespace RestSharpApiTest.RestSharp_Handler
{
    public static class GetRequest
    {
        private const string Message = "Error retrieving response";
        private static string Url = ConstantConfig.ShoppingCartUrl;
        private static Uri url = new Uri(Url);
        private static RestClient client = new RestClient(url);
        private static JsonDeserializer json = new JsonDeserializer();



        public static string GetToken(int userId)
        {
            RestRequest request = new RestRequest("v2/shopping/" + "{userId}", Method.GET);
            request.AddUrlSegment("userId", userId);
            request.AddHeader("cache-control", "no-cache");

            //Task added to execute function hence result can be awaited
            //var response = client.Execute(request).Content;
            var responseResults = GetAsyncResponse<object>(client, request).GetAwaiter().GetResult().Content;
            return responseResults;
        }

        public static ShoppingCart GetAllUsersFromShoppingCart(int userId)
        {
            RestRequest request = new RestRequest("v3/shopping/" + "{id}", Method.GET);
            //var token = GetToken(userId);
            request.AddHeader("cache-control", "no-cache");
            //request.AddParameter("Authorization", token, ParameterType.HttpHeader);

            // Strongly typed results
            var results = client.Execute<ShoppingCart>(request);

            var listOfUsers = results.Data;

            return listOfUsers;
        }

        public static IRestResponse GetUserFromShoppingCartAsync(int id)
        {
            RestRequest request = new RestRequest("v3/shopping/" + "{id}", Method.GET);
            //var token = GetToken(id);
            request.AddUrlSegment("id", id);
            request.AddHeader("cache-control", "no-cache");
            //request.AddParameter("Authorization", token, ParameterType.HttpHeader);

            var responseResults = GetAsyncResponse<ShoppingCart>(client,request).GetAwaiter().GetResult();
            return responseResults;
        }

        public static IRestResponse GetUserFromShoppingCartAsyncJson(int id)
        {
            RestRequest request = new RestRequest("v3/shopping" + "{id}", Method.GET);
            //var token = GetToken(id);
            request.AddUrlSegment("id", id);
            request.AddHeader("cache-control", "no-cache");
            //request.AddParameter("Authorization", token, ParameterType.HttpHeader);

            var responseResults = GetAsyncResponse<ShoppingCart>(client, request).GetAwaiter().GetResult();
            return responseResults;
        }

        public static IRestResponse UpdateShoppingCartAsyncJson(ShoppingCart shoppingCart,int tokenId)
        {
            RestRequest request = new RestRequest("v3/shopping", Method.PUT);
            request.AddJsonBody(shoppingCart);
            //var token = GetToken(tokenId);
            request.AddHeader("cache-control", "no-cache");
            //request.AddParameter("Authorization", token, ParameterType.HttpHeader);

            var responseResults = GetAsyncResponse<ShoppingCart>(client, request).GetAwaiter().GetResult();
            return responseResults;
        }

        public static IRestResponse DeleteShoppingCartAsyncJson(int id)
        {
            RestRequest request = new RestRequest("v3/shopping/" + "{id}", Method.DELETE);
            request.AddUrlSegment("id", id);
            //var token = GetToken(id);
            request.AddHeader("cache-control", "no-cache");
            //request.AddParameter("Authorization", token, ParameterType.HttpHeader);

            var responseResults = GetAsyncResponse<ShoppingCart>(client, request).GetAwaiter().GetResult();
            return responseResults;
        }

        public static IRestResponse CreateShoppingCartAsyncJson(ShoppingCart shoppingCart,int tokenId)
        {
            var token = GetToken(tokenId);
            //client.Authenticator = new JwtAuthenticator(token);
            RestRequest request = new RestRequest("v1/shopping", Method.POST);
            request.AddJsonBody(shoppingCart);
            request.AddHeader("cache-control", "no-cache");
            //request.AddParameter("Authorization", token, ParameterType.HttpHeader);

            var responseResults = GetAsyncResponse<object>(client, request).GetAwaiter().GetResult();
            return responseResults;
        }

        private static async Task<IRestResponse<T>> GetAsyncResponse<T>(RestClient client,IRestRequest request) where T: class, new ()
        {
            var taskCompleteSourse = new TaskCompletionSource<IRestResponse<T>>();
            client.ExecuteAsync<T>(request,restresults =>
            {
                if (restresults.ErrorException != null)
                {
                    throw new ApplicationException(Message,restresults.ErrorException);
                }
                taskCompleteSourse.SetResult(restresults);
            });

            return await taskCompleteSourse.Task;
        }

    }
}
