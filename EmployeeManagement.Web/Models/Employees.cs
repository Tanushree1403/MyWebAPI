using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Web.Models
{
    public class Employees
    {
        public string JobTitle { get; set; }

        public string FisrtName { get; set; }

        public string SecondName { get; set; }

        public string Code { get; set; }
   
        public string EmailId { get; set; }

        public string Contact { get; set; }

        public double Salary { get; set; }

        public string DeptId { get; set; }

        public string DeptName { get; set; }

        public Location EmpLocation { get; set; }

        public List<Skills> EmpSkills { get; set; }
    }
}