using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRoadWarrior.Model.RequestWrappers
{
    public class AddHotelReservationRequest
    {
        public int TripId { get; set; }
        public string ApiKey { get; set; } 
        public string HotelName { get; set; }
        public string Adress { get; set; }
        public DateTime StartingPeriod { get; set; }
        public DateTime EndingPeriod { get; set; }
        public float Price { get; set; }
        public float AmountAlreadyPaid { get; set; }
        public string Observations { get; set; }
    }
}
