using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebAPI.Entities
{
    public class Employees
    {
        public int EmpId { get; set; }
        public string EmpJobTitle { get; set; }
        public string EmpFisrtName { get; set; }
        public string EmpSecondName { get; set; }
        public string EmpCode { get; set; }
        public string EmpEmailId { get; set; }
        public string EmpContact { get; set; }
        public double EmpSalary { get; set; }
        public Departments EmpDept { get; set; }
        public Location EmpLocation { get; set; }

    }
}