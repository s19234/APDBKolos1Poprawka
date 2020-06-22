using APBDPoprawkaCSharp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDPoprawkaCSharp.Controllers
{
    [ApiController]
    [Route("api/teammembers")]
    public class TeamMemberController : ControllerBase
    {
        IDbService service;

        public TeamMemberController(IDbService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetTeamMember(int id)
        {
            var member = service.GetMember(id);
            if (member == null)
                return BadRequest("Member not found");
            else
                return Ok(member);
        }
    }
}
