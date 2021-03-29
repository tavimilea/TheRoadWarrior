using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheRoadWarrior.Model
{
    public class HotelReservation: Reservation
    {
        public String HotelName { get; set; }
        public String Adress { get; set; }
        public DateTime StartingPeriod { get; set; }
        public DateTime EndingPeriod { get; set; }
        public HotelReservation() : base() {}
    }
}
