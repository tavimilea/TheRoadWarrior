using System;

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
