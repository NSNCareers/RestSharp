using System.Threading.Tasks;
using EmployeeApp.EmployeeModels;
using NUnit.Framework;
using RestSharpApiTest.InitializeRequests;
using RestSharpTest.Data;

namespace RestSharpTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetEmployeeWithIdOne()
        {
            var results = GetRequest.GetEmployeesWithIdOne("3");
            Assert.NotNull(results);
        }

        [Test]
        public void GetEmployeeWithIdTwo()
        {
            var results = GetRequest.GetEmployeesWithIdTwo("1");
            Assert.NotNull(results);
        }

        [Test]
        public void GetEmployeeWithIdAsync()
        {
            var results = GetRequest.GetEmployeesWithIdAsync("2");
            Assert.NotNull(results);
        }

        [Test]
        public void GetEmployeeWithIdAsyncJson()
        {
            var results = GetRequest.GetEmployeesWithIdAsyncJson("2");
            Assert.NotNull(results);
        }

        [Test]
        public void CreateEmployeeWithIdAsyncJson()
        {
            var employeeData = EmployeeData.InitializeEmployee();
            var results = GetRequest.CreateEmployeesWithIdAsyncJson(employeeData);
            Assert.NotNull(results);
        }

        [Test]
        public void DeleteEmployeeWithIdAsyncJson()
        {
            var results = GetRequest.DeleteEmployeesWithIdAsyncJson("12");
            Assert.NotNull(results);
        }

        [Test]
        public void UpdateEmployeeWithIdAsyncJson()
        {
            var employeeData = EmployeeData.UpdateEmployee();
            var results = GetRequest.UpdateEmployeesWithIdAsyncJson(employeeData);
            Assert.NotNull(results);
        }
    }
}