using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBDPoprawkaCSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDPoprawkaCSharp.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        IDbService _service;
        public ProjectController(IDbService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var result = _service.DeleteProject(id);
            if (result.Length == 0)
                return BadRequest("Id mismatched or something");
            else
                return Ok("Project deleted");
        }
    }
}