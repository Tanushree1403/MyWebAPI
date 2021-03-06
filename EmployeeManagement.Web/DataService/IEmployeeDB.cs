﻿using EmployeeManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.DataService
{
    public interface IEmployeeDB
    {
        List<Employees> GetAllEmployees(bool includeLocation = false);
        Employees GetEmployeeById(string moniker);
        void AddEmployees(Employees emp);
        void UpdateEmployees();
        void DeleteEmployess();
        List<Employees> SearchByDept();
        List<Skills> GetEmployeeSkills(string moniker);
        HttpClient CreateClient();

    }
}
