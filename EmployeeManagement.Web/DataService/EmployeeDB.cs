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
            HttpClient client = CreateClient();
            HttpRequestMessage msg = new HttpRequestMessage();
           // msg.Content =new JsonContent (emp);
           // var responseTask = client.PostAsync("api/Home/Add", emp);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                //var EmpResponse = result.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                //EmpInfo = JsonConvert.DeserializeObject<List<Employees>>(EmpResponse);
            }
            //throw new NotImplementedException();
        }

        public void DeleteEmployess()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44349/");
            client.DefaultRequestHeaders.Clear();
            // string credentials=  Convert.ToBase64String("tanu:12345");
            AuthenticationHeaderValue auth = new AuthenticationHeaderValue("Basic", "tanu:12345");
            client.DefaultRequestHeaders.Authorization = auth;  //"tanu:12345";
            return client;
        }
        public List<Employees> GetAllEmployees(bool includeLocation=false)
        {
            List<Employees> EmpInfo = new List<Employees>();
            try
            {
                HttpClient client = CreateClient();                   
                    var responseTask =(includeLocation)? client.GetAsync("api/Home/employees?IncludeLocation=true")
                        :client.GetAsync("api/Home/employees");
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

        public List<Skills> GetEmployeeSkills(string moniker)
        {
            HttpClient client = CreateClient();
            List<Skills> skill = new List<Skills>();
            var responseTask = client.GetAsync("api/Home/"+moniker+"/skills");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var skillResponse = result.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Skills List.  
                skill = JsonConvert.DeserializeObject<List<Skills>>(skillResponse);
            }
            return skill;
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