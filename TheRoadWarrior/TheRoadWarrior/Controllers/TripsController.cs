using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                rsp.ResponseCode = 200;
            } catch
            {
                rsp.Description = "Key provided is invalid";
                rsp.ResponseCode = 400;
            }
            return rsp;
        }
    }
}
