using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.EmployeeModels
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int YearsOfExperience { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
