using AutoMapper;
using MyWebAPI.DAL;
using MyWebAPI.Entities;
using MyWebAPI.Models;
using MyWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebAPI.Controllers
{
    [RoutePrefix("api/Home/{moniker}/skills")]
    public class SkillsController : ApiController
    {
        private readonly ISkillDB _skillDB;
        private readonly IMapper _IMapper;
        public SkillsController(ISkillDB skillDb, IMapper mapper)
        {
            _skillDB = skillDb;
            _IMapper = mapper;
        }

        [HttpGet]
        [Route()]
        public IHttpActionResult GetSkills(string moniker)
        {
           return Ok(_skillDB.GetEmployeeSkills(moniker));
        }

        [HttpPost]
        [Route("Add")]
        public IHttpActionResult PostSkills(string moniker, SkillsModel skill)
        {
            var mappedResult = _IMapper.Map<Skills>(skill);
            return Ok(_skillDB.InsertSkills(moniker, mappedResult));
        }
    }
}
