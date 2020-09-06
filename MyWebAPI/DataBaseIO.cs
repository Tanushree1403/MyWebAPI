using MyWebAPI.Models;
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

        private string _filePath = @"C:\Users\iumh\source\repos\MyWebAPI\MyWebAPI\EmployeeData.json";
        //private  readonly IEmployeeDb _objEmployeeDB;
        //public DataBaseIO(IEmployeeDb employeeDb) 
        //{
        //   this._objEmployeeDB = employeeDb;
        //}
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public List<Employees> ReadEmployees()
        {
           var jsonText = File.ReadAllText(_filePath);
            List<Employees> empList = JsonConvert.DeserializeObject<List<Employees>>(jsonText);
            return (List<Employees>)empList;
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
            throw new NotImplementedException();
        }

        public bool DeleteEmployees(Employees emp)
        {
            throw new NotImplementedException();
        }

        public Employees ReadEmployeesById(string moniker)
        {
            var jsonText = File.ReadAllText(_filePath);
            var empList = JsonConvert.DeserializeObject<List<Employees>>(jsonText);
            return empList.Where(x => x.EmpCode == moniker).FirstOrDefault();
        }
    }
}