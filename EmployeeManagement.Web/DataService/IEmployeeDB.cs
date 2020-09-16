using EmployeeManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.DataService
{
    public interface IEmployeeDB
    {
        List<Employees> GetAllEmployees();
        Employees GetEmployeeById();
        void AddEmployees(Employees emp);
        void UpdateEmployees();
        void DeleteEmployess();
        List<Employees> SearchByDept();

    }
}
