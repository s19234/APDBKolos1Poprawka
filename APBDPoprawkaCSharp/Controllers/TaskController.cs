using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBDPoprawkaCSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDPoprawkaCSharp.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        IDbService service;

        public TaskController(IDbService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AddTask(Models.Task addTask)
        {
            if (service.Add(addTask))
                return Ok("task added");
            return BadRequest("Request cannot be applied to this database");
        }
    }
}