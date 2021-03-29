using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheRoadWarrior.Model
{
    public class TravellerUser : User
    {

        [Required]
        public String ReservationHash { get; set; }
        [Required]
        public List<Trip> Trips { get; set; }
        public TravellerUser(): base() {
            Trips = new List<Trip>();
        }
        public String UserName { get; set; }
    }
}
