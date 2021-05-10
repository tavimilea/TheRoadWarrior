using System;

namespace TheRoadWarrior.Model
{
    public class CarRentalReservation: Reservation
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String CarModel { get; set; }

        public CarRentalReservation() : base() { }
    }
}
