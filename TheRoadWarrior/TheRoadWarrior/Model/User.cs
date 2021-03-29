using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRoadWarrior.Model;

namespace TheRoadWarrior
{
    public class User
    {
        public int Id { get; set; }
        public String ApiKey { get; set; }
        public String LoginHash { get; set; }
    }
}
