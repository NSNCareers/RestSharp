using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using RestSharpApiTest.Config;
using RestSharpTest.Models;
using System;
using System.Text.RegularExpressions;
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
        public static string results { get; set; }
        public static string updateResults { get; set;}
        public static string removedResults { get; set; }



        public static IRestResponse GetToken(int userId)
        {
            RestRequest request = new RestRequest("v2/shopping/" + "{userId}", Method.GET);
            request.AddUrlSegment("userId", userId);
            request.AddHeader("cache-control", "no-cache");

            //Task added to execute function hence result can be awaited
            //var response = client.Execute(request).Content;
            var responseResults = GetAsyncResponse<object>(client, request).GetAwaiter().GetResult();
            return responseResults;
        }

        public static IRestResponse GetAllUsersFromShoppingCart(int userId)
        {
            RestRequest request = new RestRequest("v3/shopping", Method.GET);
            //var token = GetToken(userId);
            request.AddHeader("cache-control", "no-cache");
            //request.AddParameter("Authorization", token, ParameterType.HttpHeader);

            // Strongly typed results
            var responseResults = GetAsyncResponse<object>(client, request).GetAwaiter().GetResult();

            return responseResults;
        }

        public static IRestResponse GetUserFromShoppingCartAsyncJson(int id)
        {
            RestRequest request = new RestRequest("v3/shopping/" + "{id}", Method.GET);
            //var token = GetToken(id);
            request.AddUrlSegment("id", id);
            request.AddHeader("cache-control", "no-cache");
            //request.AddParameter("Authorization", token, ParameterType.HttpHeader);

            var responseResults = GetAsyncResponse<object>(client, request).GetAwaiter().GetResult();
            return responseResults;
        }

        public static IRestResponse UpdateShoppingCartAsyncJson(ShoppingCart shoppingCart,int tokenId)
        {
            RestRequest request = new RestRequest("v3/shopping", Method.POST);
            request.AddJsonBody(shoppingCart);
            request.AddHeader("cache-control", "no-cache");
            //var token = GetToken(tokenId);
            //request.AddParameter("Authorization", token, ParameterType.HttpHeader);

            var responseResults = GetAsyncResponse<object>(client, request).GetAwaiter().GetResult();
            updateResults = responseResults.Data.ToString().TrimStart('S', 'u', 'c', 'c', 'e', 's', 's', 'f', 'u', 'l', 'l', 'y', ' ','u', 'p', 'd', 'a','t','e','d',' ','u','s','e', 'r', ' ', 'w', 'i', 't', 'h', ' ', 'I', 'd', ':');
            return responseResults;
        }

        public static IRestResponse DeleteShoppingCartAsyncJson(int id)
        {
            RestRequest request = new RestRequest("v3/shopping/" + "{id}", Method.DELETE);
            request.AddUrlSegment("id", id);
            //var token = GetToken(id);
            request.AddHeader("cache-control", "no-cache");
            //request.AddParameter("Authorization", token, ParameterType.HttpHeader);

            var responseResults = GetAsyncResponse<object>(client, request).GetAwaiter().GetResult();
            removedResults = responseResults.Data.ToString().TrimStart('S', 'u', 'c', 'c', 'e', 's', 's', 'f', 'u', 'l', 'l', 'y', ' ', 'r', 'e', 'm', 'o', 'v', 'e', 'd', ' ', 'U', 's', 'e', 'r', ' ', 'w', 'i', 't', 'h', ' ', 'I', 'd', ':');
            return responseResults;
        }

        public static IRestResponse CreateShoppingCartAsyncJson(ShoppingCart shoppingCart,int tokenId)
        {
            //client.Authenticator = new JwtAuthenticator(token);
            RestRequest request = new RestRequest("v3/shopping", Method.PUT);
            //request.AddParameter("Authorization", token, ParameterType.HttpHeader);
            request.AddJsonBody(shoppingCart);
            request.AddHeader("cache-control", "no-cache");

            var responseResults = GetAsyncResponse<object>(client, request).GetAwaiter().GetResult();
            results = responseResults.Data.ToString().TrimStart('S','u','c','c','e','s','s','f','u','l','l','y',' ','a','d','d','e','d','I','t','e','m',' ','w','i','t','h',' ','I','d',':');
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
