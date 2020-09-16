using EmployeeManagement.Data.Models;
using EmployeeManagement.Data.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EmployeeManagement.Data.DAL
{
    class EmployeeDB : IEmployeeData
    {
        public void AddEmployees(Employees emp)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("");

            }
            //throw new NotImplementedException();
        }

        public void DeleteEmployess()
        {
            throw new NotImplementedException();
        }

        public List<Employees> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employees GetEmployeeById()
        {
            throw new NotImplementedException();
        }

        public List<Employees> SearchByDept()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
