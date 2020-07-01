using APBDPoprawkaCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDPoprawkaCSharp.Services
{
    public interface IDbService
    {
        //public Project GetProject(int id);
        public TeamMember GetMember(int id);
        public String DeleteProject(int id);
    }
}
