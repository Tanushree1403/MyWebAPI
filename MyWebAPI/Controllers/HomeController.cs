using AutoMapper;
using MyWebAPI.Auth;
using MyWebAPI.Entities;
using MyWebAPI.Filters;
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

        # region GetRequest

        [HttpGet]
        [Route("employees")]
        [BasicAuth]
        [LoginFilter]
        public IHttpActionResult GetEmployees(bool includeLocation = false)
        {
            try
            {
                var result = _objEmployeeDb.ReadEmployees(includeLocation);
                var mappedResult = _mapper.Map<IList<EmployeeModel>>(result);
                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{moniker}", Name ="Employee")]
        [LoginFilter]
        public IHttpActionResult GetEmployeesById(string moniker, bool includeLocation = false)
        {
            try
            {
                var result = _objEmployeeDb.ReadEmployeesById(moniker, includeLocation);
                var mappedResult = _mapper.Map<EmployeeModel>(result);
                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SearchByDeptId")]
        [LoginFilter]
        public IHttpActionResult SearchByDeptId(string deptId, bool includeLocation = false)
        {
            try
            {
                var result = _objEmployeeDb.SearchByDept(deptId, includeLocation);
                var mappedResult = _mapper.Map<IList<EmployeeModel>>(result);
                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;
            }

        }


#endregion

        [HttpPost]
        [Route("Add")]
        [LoginFilter]
        public IHttpActionResult PostEmployee(EmployeeModel emp)
        {
            // check if moniker already exists.
            if (_objEmployeeDb.ReadEmployeesById(emp.Code) != null)
                 ModelState.AddModelError("Moniker","Moniker already in Use");

            if (ModelState.IsValid)
            {
                try
                {
                    var mappedResult = _mapper.Map<Employees>(emp);
                    var newModel = _mapper.Map<EmployeeModel>(mappedResult);
                    var location = Url.Link("Employee", new { moniker = newModel.Code });
                    if (_objEmployeeDb.InsertEmployee(mappedResult))
                        return Created("Employee", location);
                    else
                        return InternalServerError();

                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{moniker}")]
        [LoginFilter]
        public IHttpActionResult DeleteEmployee(string moniker)
        {
            Employees emp = _objEmployeeDb.ReadEmployeesById(moniker);
            var mappedResult = _mapper.Map<Employees>(emp);
            return Ok(_objEmployeeDb.DeleteEmployees(mappedResult));
        }
    }
}
