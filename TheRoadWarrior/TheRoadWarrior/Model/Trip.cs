using System;
using System.Collections.Generic;

namespace TheRoadWarrior.Model
{
    public class Trip
    {
        public int Id { get; set; }
        //Owner of this trip
        public User User { get; set; }
        public List<CarRentalReservation> CarRentalReservations { get; set; }
        public List<HotelReservation> HotelReservations { get; set; }
        public List<PlaneTicketReservation> PlaneTicketReservations { get; set; }
        public String TripName { get; set; }
        public Trip()
        {
            CarRentalReservations = new List<CarRentalReservation>();
            HotelReservations = new List<HotelReservation>();
            PlaneTicketReservations = new List<PlaneTicketReservation>();
        }
    }
}
