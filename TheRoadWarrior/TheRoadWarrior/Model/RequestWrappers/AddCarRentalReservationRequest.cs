using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRoadWarrior.Model.RequestWrappers
{
    public class AddCarRentalReservationRequest
    {   
        public string ApiKey { get; set; }
        public int TripId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String CarModel { get; set; }
        public float Price { get; set; }
        public float AmountAlreadyPaid { get; set; }
        public String Observations { get; set; }

    }
}
