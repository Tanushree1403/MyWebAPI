using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Web.Models
{
    public class Employees
    {
        [Display(Name ="Job Title")]
        public string JobTitle { get; set; }

        [Display(Name = "First Name")]
        public string FisrtName { get; set; }

        [Display(Name = "Last Name")]
        public string SecondName { get; set; }

        [Display(Name = "Employee Code")]
        public string Code { get; set; }

        [Display(Name = "Email Id")]
        public string EmailId { get; set; }

        [Display(Name = "Contact")]
        public string Contact { get; set; }

        [Display(Name = "Salary")]
        public double Salary { get; set; }

        [Display(Name = "Department Id")]
        public string DeptId { get; set; }

        [Display(Name = "Department Name")]
        public string DeptName { get; set; }

        [Display(Name = "Address")]
        public Location EmpLocation { get; set; }

        public List<Skills> EmpSkills { get; set; }
    }
}