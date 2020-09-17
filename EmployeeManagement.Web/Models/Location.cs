using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Web.Models
{
    public class Location
    {
        public string EmpState { get; set; }
        public int EmpZipCode { get; set; }
        public string EmpCity { get; set; }
    }
}