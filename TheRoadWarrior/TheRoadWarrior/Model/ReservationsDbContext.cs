using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TheRoadWarrior.Model.Hashing;

namespace TheRoadWarrior.Model
{
    public class ReservationsDbContext: DbContext
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
            TravellerUser usr = TravellerUsers.ToList().Find(usr => PasswordHasher.checkHash(usr.ApiKey, apiKey));
            if (usr == null)
            {
                throw InvalidOperationException("User does not exist");
            }
            return usr;
        }
        public void CreateTravellerUser(String apiKey, String loginHash, String username)
        {
            if(TravellerUsers.ToList().Find(usr => usr.UserName == username) != null)
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
        }

    }
}
