using MyWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebAPI.Models
{
    public class EmployeeModel
    {
        //[MapTo(nameof(Employees.EmpJobTitle))]
        public string JobTitle { get; set; }

        //[MapTo(nameof(Employees.EmpFisrtName))]
        public string FisrtName { get; set; }

        //[MapTo(nameof(Employees.EmpSecondName))]
        public string SecondName { get; set; }

        //[MapTo(nameof(Employees.EmpCode))]
        public string Code { get; set; }

        //[MapTo(nameof(Employees.EmpEmailId))]
        public string EmailId { get; set; }

        //[MapTo(nameof(Employees.EmpContact))]
        public string Contact { get; set; }

        //[MapTo(nameof(Employees.EmpSalary))]
        public double Salary { get; set; }

        //[MapTo(nameof(Employees.EmpDept))]
        public string DeptId { get; set; }

        //[MapTo(nameof(Employees.EmpCity))]
        //public string City { get; set; }

        public string DeptName { get; set; }

        public LocationModel EmpLocation { get; set; }
    }
}