using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using EmployeeManagement.Web.Models;
using Newtonsoft.Json;

namespace EmployeeManagement.Web.DataService
{
    public class EmployeeDB : IEmployeeDB, IDisposable
    {
        public void AddEmployees(Employees emp)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployess()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }

        public List<Employees> GetAllEmployees()
        {
            List<Employees> EmpInfo = new List<Employees>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44349/");
                    client.DefaultRequestHeaders.Clear();
                 // string credentials=  Convert.ToBase64String("tanu:12345");
                   AuthenticationHeaderValue auth = new AuthenticationHeaderValue("Basic", "tanu:12345");
                   client.DefaultRequestHeaders.Authorization = auth;  //"tanu:12345";
                    var responseTask = client.GetAsync("api/Home/employees");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = result.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        EmpInfo = JsonConvert.DeserializeObject<List<Employees>>(EmpResponse);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return EmpInfo;
            //throw new NotImplementedException();
        }

        public Employees GetEmployeeById()
        {
            throw new NotImplementedException();
        }

        public List<Employees> SearchByDept()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployees()
        {
            throw new NotImplementedException();
        }
    }
}