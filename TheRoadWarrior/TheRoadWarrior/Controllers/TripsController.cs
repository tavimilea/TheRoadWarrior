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
    }
}
