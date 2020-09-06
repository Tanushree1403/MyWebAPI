using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebAPI.Models
{
    public class EmployeeModel
    {
        public string JobTitle { get; set; }
        public string FisrtName { get; set; }
        public string SecondName { get; set; }
        public string Code { get; set; }
        public string EmailId { get; set; }
        public string Contact { get; set; }
        public string Salary { get; set; }
        public string Dept { get; set; }
        public string City { get; set; }
    }
}