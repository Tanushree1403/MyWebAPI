using MyWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebAPI.Models
{
    public class EmployeeModel
    {
        public string JobTitle { get; set; }
        
        [Required]
        public string FisrtName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string EmailId { get; set; }

        //[MapTo(nameof(Employees.EmpContact))]
        public string Contact { get; set; }

        //[MapTo(nameof(Employees.EmpSalary))]
        public double Salary { get; set; }

        [Required]
        public string DeptId { get; set; }

        //[MapTo(nameof(Employees.EmpCity))]
        //public string City { get; set; }

        [Required]
        public string DeptName { get; set; }

        public LocationModel EmpLocation { get; set; }
    }
}