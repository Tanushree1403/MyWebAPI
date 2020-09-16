using EmployeeManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Data.Services
{
    public interface ISKillDB
    {
        List<Skills> GetEmployeeSkills(int empId);
        void InsertSkills(Skills skill);
    }
}
