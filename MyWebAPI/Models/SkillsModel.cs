using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebAPI.Models
{
    public class SkillsModel
    {
        public string SkillId { get; set; }
        public string SkillName { get; set; }
        public bool IsCertified { get; set; }
    }
}