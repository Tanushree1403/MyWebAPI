﻿using Newtonsoft.Json;
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

        public List<Employees> ReadEmployees(bool includeLocation = false)
        {                
            return DeserializeJson(includeLocation); 
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

        public Employees ReadEmployeesById(string moniker, bool includeLocation)
        {
            List<Employees> empList= DeserializeJson(includeLocation);
            return empList.Where(x => x.EmpCode == moniker).FirstOrDefault();
        }

        private List<Employees> DeserializeJson(bool includeLocation=false)
        {
            var jsonText = File.ReadAllText(_filePath);
            List<Employees> empList = JsonConvert.DeserializeObject<List<Employees>>(jsonText);
            if(!includeLocation)
             empList.ForEach(e=>e.EmpLocation=null);
            return empList;
        }
    }
}