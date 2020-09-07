using MyWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebAPI.Repository
{
    public interface ISkillDB
    {
        List<Skills> GetEmployeeSkills(string moniker);
        bool InsertSkills(string moniker, Skills skill);
    }
}
