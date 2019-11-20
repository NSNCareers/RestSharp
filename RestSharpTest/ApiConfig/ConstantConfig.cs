using System;
namespace RestSharpApiTest.Config
{
    public static class ConstantConfig
    {
        public static string EmployeeUrl { get; set; } = "https://localhost:5001/Employee/";

        public static string AddressUrl { get; set; } = "https://localhost:5001/Address/";
    }
}
