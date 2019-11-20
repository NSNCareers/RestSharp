using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.EmployeeModels
{
    public class Address
    {
        public int Id { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string Postcode{ get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public int EmployeeId { get; set; }
    }
}
