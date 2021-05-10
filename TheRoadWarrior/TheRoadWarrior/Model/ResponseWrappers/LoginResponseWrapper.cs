using System;

namespace TheRoadWarrior.Model
{
    public class LoginResponseWrapper
    {
        public int ResponseCode { get; set; }
        public String Description { get; set; }
        public String ApiKey { get; set; }
    }
}
