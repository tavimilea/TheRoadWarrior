using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRoadWarrior.Model.RequestWrappers
{
    public class AddPlaneTicketReservationRequest
    {

      
        public float AmountAlreadyPaid { get; set; }
        public String Observations { get; set; }
        public String TicketNumber { get; set; }
        public String FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public String DepartingFrom { get; set; }
        public String ArrivingAt { get; set; }
    }
}
