using MyWebAPI.Autofac.AutoFacCommon;
using MyWebAPI.Entities;
using MyWebAPI.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MyWebAPI.DAL
{
    [Injectable]
    public class SkillDbIO : ISkillDB
    {
        private readonly string _filePath = System.Configuration.ConfigurationManager.AppSettings["jsonFile"];

        public List<Skills> GetEmployeeSkills(string moniker)
        {
           List<Employees> emp = ReadEmployees();
            var result = emp.Where(e => e.EmpCode == moniker).FirstOrDefault();
            return result.EmpSkills;
        }

        public bool InsertSkills(string moniker, Skills skill)
        {
            List<Employees> empList = ReadEmployees();
            Employees emp1 = empList.Where(e => e.EmpCode == moniker).FirstOrDefault();
            emp1.EmpSkills.Add(skill);

            empList.RemoveAll(e => e.EmpCode == moniker);
            empList.Add(emp1);

            File.WriteAllText(_filePath, string.Empty);
            string input = JsonConvert.SerializeObject(empList, Formatting.None).ToString();
            File.WriteAllText(_filePath, input);
            return false;
        }

        private List<Employees> ReadEmployees()
        {
            try
            {
                var jsonText = File.ReadAllText(_filePath);
                List<Employees> empList = JsonConvert.DeserializeObject<List<Employees>>(jsonText);
                return empList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}