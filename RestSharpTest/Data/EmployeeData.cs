using System;
using System.Collections.Generic;
using EmployeeApp.EmployeeModels;
using EmployeeApp.EmployeeModels.Models;

namespace RestSharpTest.Data
{
    public static class EmployeeData
    {
        public static Employee InitializeEmployee()
        {
            Employee employee = new Employee
            {
                Title = "Dr",
                FirstName = "Ben",
                LastName = "Askren",
                Date = DateTime.Now,
                IsDeleted = false,
                IsCreated = false,
                Salary = 402m,
                Nationality = "USA",
                Age = 99,
                DepartmentId = 4,
                Address = new List<Address>
                {
                    new Address
                    {
                    Street = "Line Road",
                    HouseNumber = "234",
                    Postcode = "POBox 552",
                    County = "Los Angeles",
                    Country = "USA",
                    }
                },
                Profile = new EmployeeProfile
                {
                    CarType = "BMW",
                    NickName = "Latino",
                    ProfilePic = "http://wwww.latinpic.com"
                }
            };

            return employee;
        }

        public static Employee UpdateEmployee()
        {
            Employee employee = new Employee
            {
                EmployeeId = 21,
                Title = "Dr",
                FirstName = "Miller",
                LastName = "Queenten",
                Date = DateTime.Now,
                IsDeleted = false,
                IsCreated = false,
                Salary = 402m,
                Nationality = "USA",
                Age = 99,
                DepartmentId = 4,
                Address = new List<Address>
                {
                    new Address
                    {
                    Street = "Line Road",
                    HouseNumber = "234",
                    Postcode = "POBox 552",
                    County = "Los Angeles",
                    Country = "USA",
                    }
                },
            };

            return employee;
        }
    }
}
