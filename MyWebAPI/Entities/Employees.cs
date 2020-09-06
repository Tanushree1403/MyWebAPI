using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebAPI.Entities
{
    public class Employees
    {
        public string EmpId { get; set; }
        public string EmpJobTitle { get; set; }
        public string EmpFisrtName { get; set; }
        public string EmpSecondName { get; set; }
        public string EmpCode { get; set; }
        public string EmpEmailId { get; set; }
        public string EmpContact { get; set; }
        public string EmpSalary { get; set; }
        public string EmpDept { get; set; }
        public string EmpCity { get; set; }
    }
}