using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebAPI.Entities;
using MyWebAPI.Models;
namespace MyWebAPI.MapperClasses
{
    public class EmployeeMappingProfile: Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employees, EmployeeModel>();
        }
    }
}