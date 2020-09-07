using MyWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebAPI.Repository
{
    public interface IEmployeeDb
    {
        List<Employees> ReadEmployees(bool includeLocation = false);
        bool InsertEmployee(Employees emp);
        bool UpdateEmployees(Employees emp);
        bool DeleteEmployees(Employees emp);
        Employees ReadEmployeesById(string moniker, bool includeLocation = false);
        List<Employees> SearchByDept(string DeptId, bool includeLocation = false);

    }
}
