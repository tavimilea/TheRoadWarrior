using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRoadWarrior.Model.RequestWrappers
{
    public class AddTripRequest
    {
        public String TripName { get; set; }
        public String ApiKey { get; set; }
    }
}
