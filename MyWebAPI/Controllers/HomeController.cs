using AutoMapper;
using MyWebAPI.Entities;
using MyWebAPI.Models;
using MyWebAPI.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace MyWebAPI.Controllers
{
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        private readonly IEmployeeDb _objEmployeeDb;
        private readonly IMapper _mapper;
        public HomeController(IEmployeeDb ObjEmployeeDb, IMapper mapper)
        {
            this._objEmployeeDb = ObjEmployeeDb;
            this._mapper = mapper;
        }
        [HttpGet]
        [System.Web.Http.Route("employees")]
        public IHttpActionResult GetEmployees()
        {
            var result= _objEmployeeDb.ReadEmployees();
            var mappedResult = _mapper.Map<IList<EmployeeModel>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("Add")]
        public IHttpActionResult PostEmployee(EmployeeModel emp)
        {
            var mappedResult = _mapper.Map<Employees>(emp);
             return Ok(_objEmployeeDb.InsertEmployee(mappedResult));
        }
    }
}
