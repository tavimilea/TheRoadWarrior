using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRoadWarrior.Model;
using TheRoadWarrior.Model.RequestWrappers;

namespace TheRoadWarrior.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        ReservationDbContext Database;
        public LoginController(ReservationDbContext db)
        {
            Database = db;
        }

        [HttpPost("authenticate")]
        public LoginResponseWrapper Get (LoginRequest request)
        {
            LoginResponseWrapper rsp = new LoginResponseWrapper();
            if(request.Create)
            {
                String loginHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
                String apiKey = BCrypt.Net.BCrypt.HashPassword(request.Password + request.Username);
                String reservationHash = BCrypt.Net.BCrypt.HashPassword(request.Username);
                try
                {
                    Database.CreateTravellerUser(apiKey, reservationHash, loginHash, request.Username);
                    rsp.ResponseCode = 200;
                    rsp.Description = "ok";
                    rsp.ApiKey = apiKey;
                    rsp.ReservationKey = reservationHash;
                } catch
                {
                    rsp.ResponseCode = 400;
                    rsp.Description = "This user already exists";
                }
            } else
            {
               try
                {
                    var usr = Database.GetUser(request.Username);
                    if(BCrypt.Net.BCrypt.Verify(request.Password, usr.LoginHash)) {
                        rsp.ResponseCode = 200;
                        rsp.Description = "ok";
                        rsp.ApiKey = usr.ApiKey;
                        rsp.ReservationKey = usr.ReservationHash;
                    }
                } 
                catch
                {
                    rsp.ResponseCode = 400;
                    rsp.Description = "Wrong password/username";
                }
            }
            return rsp;
        }
    }
}
