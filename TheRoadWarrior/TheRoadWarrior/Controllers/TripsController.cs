using Microsoft.AspNetCore.Mvc;
using TheRoadWarrior.Model;
using TheRoadWarrior.Model.RequestWrappers;
using TheRoadWarrior.Model.ResponseWrappers;

namespace TheRoadWarrior.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        readonly ReservationsDbContext Database;
        public TripsController(ReservationsDbContext db)
        {
            Database = db;
        }
        [HttpPost]
        public  AddTripResponse AddTrip (AddTripRequest rq)
        {
            AddTripResponse rsp = new AddTripResponse();
            try
            {
                var usr = Database.GetUserByApiKey(rq.ApiKey);
                Database.CreateTrip(usr.Id, rq.TripName);
                rsp.Description = "Created";
                rsp.ResponseCode = (int) ResponseConstants.SUCCES;
            } catch
            {
                rsp.Description = "Key provided is invalid";
                rsp.ResponseCode = (int) ResponseConstants.SUCCES;
            }
            return rsp;
        }

        [HttpPost, Route("HotelReservations")]
        public AddTripResponse AddHotelReservationToTrip(AddHotelReservationRequest req)
        {
            AddTripResponse rsp = new AddTripResponse();
            var usr = Database.GetUserByApiKey(req.ApiKey);
            var trip = usr.Trips.Find(tr => tr.Id == req.TripId);
            if(trip == null)
            {
                rsp.Description = "Could not find the targeted trip";
                rsp.ResponseCode = (int)ResponseConstants.FAIL;
                return rsp;
            }
            
            Database.AddHotelReservationToTrip(
                trip.Id,
                req.HotelName,
                req.StartingPeriod,
                req.EndingPeriod,
                req.Adress,
                req.Price,
                req.AmountAlreadyPaid,
                null,
                req.Observations);
            rsp.Description = "Hotel Reservation Added Succesfully";
            rsp.ResponseCode = (int)ResponseConstants.SUCCES;
            return rsp;
        }

        [HttpPost, Route("CarReservations")]
        public AddTripResponse AddCarRentalReservation(AddCarRentalReservationRequest req)
        {
            AddTripResponse rsp = new AddTripResponse();
            var usr = Database.GetUserByApiKey(req.ApiKey);
            var trip = usr.Trips.Find(tr => tr.Id == req.TripId);
            if (trip == null)
            {
                rsp.Description = "Could not find the targeted trip";
                rsp.ResponseCode = (int)ResponseConstants.FAIL;
                return rsp;
            }
            Database.AddCarRentalReservation(
                trip.Id,
                req.StartDate,
                req.EndDate,
                req.CarModel,
                req.Price,
                req.AmountAlreadyPaid,
                req.Observations);
            rsp.Description = "Car Rental Reservation Added Succesfully";
            rsp.ResponseCode = (int)ResponseConstants.SUCCES;
            return rsp;
        }

       // [HttpPost, Route("CarReservations")]
    }
}
