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

        public List<Employees> ReadEmployees(bool includeLocation = false)
        {                
            return DeserializeJson(includeLocation); 
        }

        public Employees ReadEmployeesById(string moniker, bool includeLocation = false)
        {
            List<Employees> empList = DeserializeJson(includeLocation);
            return empList.Where(x => x.EmpCode == moniker).FirstOrDefault();
        }
        public List<Employees> SearchByDept(string DeptId, bool includeLocation = false)
        {
            List<Employees> empList = DeserializeJson(includeLocation);
            var result = (from e in empList where e.EmpDept.DeptId == DeptId select e).ToList();
            return result;

        }

        public bool InsertEmployee(Employees emp)
        {
            try
            {
                
                string input = JsonConvert.SerializeObject(emp, Formatting.None).ToString();
                string data = File.ReadAllText(_filePath).Trim();
                data = data.TrimEnd(']');
                File.WriteAllText(_filePath, data + ",\r\n" + input + "]");
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool UpdateEmployees(Employees emp)
        {
            //Employees empOld = ReadEmployeesById(emp.EmpCode);
            return true;
        }

        public bool DeleteEmployees(Employees emp)
        {
            List<Employees> empList = ReadEmployees();
            empList.RemoveAll(e => e.EmpCode == emp.EmpCode);
            //clear the file
            File.WriteAllText(_filePath, String.Empty);

            string input = JsonConvert.SerializeObject(empList, Formatting.None).ToString();
            File.WriteAllText(_filePath,input);
            return true;
        }
        private List<Employees> DeserializeJson(bool includeLocation = false)
        {
            try
            {
                var jsonText = File.ReadAllText(_filePath);
                List<Employees> empList = JsonConvert.DeserializeObject<List<Employees>>(jsonText);
                if (!includeLocation)
                    empList.ForEach(e => e.EmpLocation = null);
                return empList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}