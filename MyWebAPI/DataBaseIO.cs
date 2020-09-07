using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MyWebAPI.Repository;
using MyWebAPI.Autofac.AutoFacCommon;
using MyWebAPI.Entities;

namespace MyWebAPI
{
    [Injectable]
    public class DataBaseIO:IDisposable,IEmployeeDb
    {

        private readonly string _filePath = System.Configuration.ConfigurationManager.AppSettings["jsonFile"];
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public List<Employees> ReadEmployees(bool includeDept= false)
        {                
            return DeserializeJson(includeDept); 
        }

        public bool InsertEmployee(Employees emp)
        {
            char[] trimChars = new char[] { ']','}'};
           string input= JsonConvert.SerializeObject(emp, Formatting.None).ToString();
            string data= File.ReadAllText(_filePath).TrimEnd(trimChars);
            File.WriteAllText(_filePath, data+ ","+input +"]}");
            return true;
        }

        public bool UpdateEmployees(Employees emp)
        {
            //Employees empOld = ReadEmployeesById(emp.EmpCode);
            return true;
        }

        public bool DeleteEmployees(Employees emp)
        {
            throw new NotImplementedException();
        }

        public Employees ReadEmployeesById(string moniker, bool includeDept)
        {
            List<Employees> empList= DeserializeJson(includeDept);
            return empList.Where(x => x.EmpCode == moniker).FirstOrDefault();
        }

        private List<Employees> DeserializeJson(bool includeDept=false)
        {
            var jsonText = File.ReadAllText(_filePath);
            List<Employees> empList = JsonConvert.DeserializeObject<List<Employees>>(jsonText);
            if(!includeDept)
             empList.ForEach(e=>e.EmpDept=null);
            return empList;
        }
    }
}