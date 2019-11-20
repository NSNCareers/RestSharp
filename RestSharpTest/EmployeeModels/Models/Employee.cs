using System;
using System.Collections.Generic;
using EmployeeApp.EmployeeModels.Models;

namespace EmployeeApp.EmployeeModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCreated { get; set; }
        public string Title { get; set; }
        public string Nationality { get; set; }
        public decimal Salary { get; set; }
        public DateTime Date { get; set; }
        public virtual EmployeeProfile Profile { get; set; }
        public virtual List<Address> Address { get; set; }
        public int DepartmentId { get; set; }
    }
}

