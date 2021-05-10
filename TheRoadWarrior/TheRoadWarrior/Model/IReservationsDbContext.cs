using Microsoft.EntityFrameworkCore;
using System;

namespace TheRoadWarrior.Model
{
    public interface IReservationsDbContext
    {
        DbSet<AgencyUser> AgencyUsers { get; set; }
        DbSet<CarRentalReservation> CarRentalReservations { get; set; }
        DbSet<HotelReservation> HotelReservations { get; set; }
        DbSet<PlaneTicketReservation> PlaneTicketReservations { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        DbSet<TravellerUser> TravellerUsers { get; set; }
        DbSet<Trip> Trips { get; set; }
        DbSet<User> Users { get; set; }

        void AddCarRentalReservation(int forTripId, DateTime start, DateTime end, string carModel, float price, float amountAlreadyPaid, string observations = "", AgencyUser agencyUser = null);
        void AddHotelReservationToTrip(int forTripId, string hotelName, DateTime startDate, DateTime endDate, string adress, float price, float amountAlreadyPaid, AgencyUser agencyUser = null, string observations = "");
        void AddPlaneTicketReservationToTrip(int forTripId, string ticketNumber, string flightNumber, DateTime depDate, DateTime arrDate, string from, string to, float amountAlreadyPaid, float price, string observations = "", AgencyUser agencyUser = null);
        void CreateTravellerUser(string apiKey, string loginHash, string username);
        void CreateTrip(int forUserId, string tripName);
        TravellerUser GetUser(string username);
        TravellerUser GetUserByApiKey(string apiKey);
    }
}