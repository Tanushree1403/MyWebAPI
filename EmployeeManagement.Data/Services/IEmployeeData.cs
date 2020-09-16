using EmployeeManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Data.Services
{
    public interface IEmployeeData
    {
        List<Employees> GetAllEmployees();
        Employees GetEmployeeById();
        void AddEmployees(Employees emp);
        void UpdateEmployees();
        void DeleteEmployess();
        List<Employees> SearchByDept();

    }
}
