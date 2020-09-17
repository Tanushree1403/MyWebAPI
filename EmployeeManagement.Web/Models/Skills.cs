using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Web.Models
{
    public class Skills
    {
        public string SkillId { get; set; }
        public string SkillName { get; set; }
        public bool IsCertified { get; set; }
    }
}