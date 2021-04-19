using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheRoadWarrior.Model
{
    public class LoginResponseWrapper
    {
        public int ResponseCode { get; set; }
        public String Description { get; set; }
        public String ApiKey { get; set; }
    }
}
