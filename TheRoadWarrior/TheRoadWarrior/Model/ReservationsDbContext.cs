using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TheRoadWarrior.Model.Hashing;

namespace TheRoadWarrior.Model
{
    public class ReservationsDbContext : DbContext, IReservationsDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AgencyUser> AgencyUsers { get; set; }
        public DbSet<TravellerUser> TravellerUsers { get; set; }
        public DbSet<CarRentalReservation> CarRentalReservations { get; set; }
        public DbSet<HotelReservation> HotelReservations { get; set; }
        public DbSet<PlaneTicketReservation> PlaneTicketReservations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Trip> Trips { get; set; }

        public ReservationsDbContext([NotNullAttribute] DbContextOptions options) : base(options) //config
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=reservations.db");
        }
        public TravellerUser GetUser(String username)
        {
            TravellerUser usr = TravellerUsers.ToList().Find(usr => usr.UserName == username);
            if (usr == null)
            {
                throw InvalidOperationException("User does not exist");
            }
            return usr;
        }
        public TravellerUser GetUserByApiKey(String apiKey)
        {
            TravellerUser usr = TravellerUsers.ToList().Find(usr => PasswordHasher.CheckHash(usr.ApiKey, apiKey));
            if (usr == null)
            {
                throw InvalidOperationException("User does not exist");
            }
            return usr;
        }
        public void CreateTravellerUser(String apiKey, String loginHash, String username)
        {
            if (TravellerUsers.ToList().Find(usr => usr.UserName == username) != null)
            {
                throw InvalidOperationException("UserAlreadyExists");
            }
            TravellerUser usr = new()
            {
                LoginHash = loginHash,
                ApiKey = apiKey,
                UserName = username,
                Trips = new List<Trip>()
            };
            TravellerUsers.Add(usr);
            this.SaveChanges();
        }

        private Exception InvalidOperationException(string v)
        {
            throw new NotImplementedException();
        }

        public void CreateTrip(int forUserId, String tripName)
        {
            Trip trip = new()
            {
                TripName = tripName,
                HotelReservations = new List<HotelReservation>(),
                CarRentalReservations = new List<CarRentalReservation>(),
                PlaneTicketReservations = new List<PlaneTicketReservation>(),
            };
            TravellerUser usr = TravellerUsers.ToList().Find(usr => usr.Id == forUserId);
            usr.Trips.Add(trip);
            this.SaveChanges();
        }

        public void AddHotelReservationToTrip(
            int forTripId,
            String hotelName,
            DateTime startDate,
            DateTime endDate,
            String adress,
            float price,
            float amountAlreadyPaid,
            AgencyUser agencyUser = null,
            String observations = "")
        {
            HotelReservation hrs = new()
            {
                Price = price,
                AmountAlreadyPaid = amountAlreadyPaid,
                Observations = observations,
                AgencyUser = agencyUser,
                StartingPeriod = startDate,
                EndingPeriod = endDate,
                Adress = adress,
                HotelName = hotelName
            };
            var trip = Trips.ToList().Find(tr => tr.Id == forTripId);
            trip.HotelReservations.Add(hrs);
            this.SaveChanges();
        }

        public void AddPlaneTicketReservationToTrip(
                                                        int forTripId,
                                                        string ticketNumber,
                                                        string flightNumber,
                                                        DateTime depDate,
                                                        DateTime arrDate,
                                                        string from,
                                                        string to,
                                                        float amountAlreadyPaid,
                                                        float price,
                                                        string observations = "",
                                                        AgencyUser agencyUser = null)
        {
            PlaneTicketReservation rsv = new()
            {
                Price = price,
                AmountAlreadyPaid = amountAlreadyPaid,
                Observations = observations,
                AgencyUser = agencyUser,
                TicketNumber = ticketNumber,
                FlightNumber = flightNumber,
                DepartingFrom = from,
                ArrivingAt = to,
                DepartureDate = depDate,
                ArrivalDate = arrDate,
            };
            var trip = Trips.ToList().Find(tr => tr.Id == forTripId);
            trip.PlaneTicketReservations.Add(rsv);
        }

        public void AddCarRentalReservation(
            int forTripId,
            DateTime start,
            DateTime end,
            string carModel,
            float price,
            float amountAlreadyPaid,
            string observations = "",
            AgencyUser agencyUser = null)
        {
            CarRentalReservation rvs = new()
            {
                Price = price,
                AmountAlreadyPaid = amountAlreadyPaid,
                Observations = observations,
                AgencyUser = agencyUser,
                StartDate = start,
                CarModel = carModel,
            };

            var trip = Trips.ToList().Find(tr => tr.Id == forTripId);
            trip.CarRentalReservations.Add(rvs);
            this.SaveChanges();
        }
    }
}
