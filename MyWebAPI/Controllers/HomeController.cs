﻿using AutoMapper;
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
        [Route("employees")]
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
        [Route("{moniker}")]
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

        [HttpPost]
        [Route("Add")]
        public IHttpActionResult PostEmployee(EmployeeModel emp)
        {
            try
            {
                var mappedResult = _mapper.Map<Employees>(emp);
                return Ok(_objEmployeeDb.InsertEmployee(mappedResult));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
