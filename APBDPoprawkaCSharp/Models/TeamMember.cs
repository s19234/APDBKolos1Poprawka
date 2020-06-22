using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDPoprawkaCSharp.Models
{
    public class TeamMember
    {
        public int IdTeamMember { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
