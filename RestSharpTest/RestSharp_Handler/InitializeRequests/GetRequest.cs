using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EmployeeApp.EmployeeModels;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharpApiTest.Config;
using RestSharpTest.Data;
using Controller = RestSharpApiTest.Config.Controller;

namespace RestSharpApiTest.InitializeRequests
{
    public static class GetRequest
    {
        private const string Message = "Error retrieving response";

        private static string Url = ConstantConfig.EmployeeUrl;

        public static string GetEmployeesWithIdOne(string id)
        {
            Uri url = new Uri(Url);

            RestClient client = new RestClient(url);

            RestRequest request = new RestRequest($"{EndPoints.GetEmployeeById}/" + "{employeeId}", Method.GET);

            request.AddUrlSegment("employeeId", id);

            //Task added to execute function hence result can be awaited
            var response = client.Execute(request).Content;
            return response;
        }

        public static string GetEmployeesWithIdTwo(string id)
        {
            Uri url = new Uri(Url);

            RestClient client = new RestClient(url);

            RestRequest request = new RestRequest($"{EndPoints.GetEmployeeById}/" + "{employeeId}", Method.GET);

            request.AddUrlSegment("employeeId", id);
            // Strongly typed results
            var results = client.Execute<Employee>(request);

            var firstName = results.Data.FirstName;

            return firstName;
        }

        public static IRestResponse GetEmployeesWithIdAsync(string id)
        {
            Uri url = new Uri(Url);
            RestClient client = new RestClient(url);

            RestRequest request = new RestRequest($"{EndPoints.GetEmployeeById}/" + "{employeeId}", Method.GET);

            request.AddUrlSegment("employeeId", id);

            var responseResults = GetAsyncResponse<object>(client,request).GetAwaiter().GetResult();
            return responseResults;
        }

        public static object GetEmployeesWithIdAsyncJson(string id)
        {
            Uri url = new Uri(Url);
            var json = new JsonDeserializer();
            RestClient client = new RestClient(url);

            RestRequest request = new RestRequest($"{EndPoints.GetEmployeeById}/" + "{employeeId}", Method.GET);

            request.AddUrlSegment("employeeId", id);

            var responseResults = GetAsyncResponse<object>(client, request).GetAwaiter().GetResult();
            var jsonResults = json.Deserialize<object>(responseResults);
            return jsonResults;
        }

        public static object UpdateEmployeesWithIdAsyncJson(Employee employee)
        {
            Uri url = new Uri(Url);
            RestClient client = new RestClient(url);

            RestRequest request = new RestRequest($"{EndPoints.UpdateEmployee}", Method.PUT);
            request.AddJsonBody(employee);

            var responseResults = GetAsyncResponse<object>(client, request).GetAwaiter().GetResult();
            return responseResults;
        }

        public static object DeleteEmployeesWithIdAsyncJson(string id)
        {
            Uri url = new Uri(Url);
            RestClient client = new RestClient(url);

            RestRequest request = new RestRequest($"{EndPoints.RemoveEmployee}/" + "{employeeId}", Method.DELETE);

            request.AddUrlSegment("employeeId", id);

            var responseResults = GetAsyncResponse<object>(client, request).GetAwaiter().GetResult();
            return responseResults;
        }

        public static object CreateEmployeesWithIdAsyncJson(Employee employee)
        {
            Uri url = new Uri(Url);
            RestClient client = new RestClient(url);

            RestRequest request = new RestRequest($"{EndPoints.CreateEmployee}", Method.POST);

            request.AddJsonBody(employee);

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
