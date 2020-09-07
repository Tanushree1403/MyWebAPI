using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebAPI.Models
{
    public class LocationModel
    {
        public string EmpState { get; set; }
        public int EmpZipCode { get; set; }
        public string EmpCity { get; set; }
    }
}