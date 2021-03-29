using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheRoadWarrior.Model
{
    public class PlaneTicketReservation: Reservation
    {
        public String TicketNumber { get; set; }
        public String FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public String DepartingFrom { get; set; }
        public String ArrivingAt { get; set; }
        public PlaneTicketReservation(): base() { }
    }
}
