﻿using AutoMapper;
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
            CreateMap<Employees, EmployeeModel>()
                .ForMember(e => e.JobTitle, opt => opt.MapFrom(src => src.EmpJobTitle))
                .ForMember(e => e.City, opt => opt.MapFrom(src => src.EmpCity))
                .ForMember(e => e.Code, opt => opt.MapFrom(src => src.EmpCode))
                .ForMember(e => e.Contact, opt => opt.MapFrom(src => src.EmpContact))
                .ForMember(e => e.Dept, opt => opt.MapFrom(src => src.EmpDept))
                .ForMember(e => e.EmailId, opt => opt.MapFrom(src => src.EmpEmailId))
                .ForMember(e => e.FisrtName, opt => opt.MapFrom(src => src.EmpFisrtName))
                .ForMember(e => e.Salary, opt => opt.MapFrom(src => src.EmpSalary))
                .ForMember(e => e.SecondName, opt => opt.MapFrom(src => src.EmpSecondName));
        }
    }
}