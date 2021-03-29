using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheRoadWarrior.Model
{
    public class CarRentalReservation: Reservation
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String CarModel { get; set; }

        CarRentalReservation() : base() { }
    }
}
