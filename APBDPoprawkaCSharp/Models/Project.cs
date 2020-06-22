using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDPoprawkaCSharp.Models
{
    public class Project
    {
        public string ProjectName { get; set; }
        public int? IdProject { get; set; }
        public DateTime DeadLine { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
