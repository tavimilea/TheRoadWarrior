using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRoadWarrior.Model;
using TheRoadWarrior.Model.Hashing;
using TheRoadWarrior.Model.RequestWrappers;

namespace TheRoadWarrior.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        readonly ReservationsDbContext Database;
        public RegisterController(ReservationsDbContext db)
        {
            Database = db;
        }

        [HttpPost]
        public LoginResponseWrapper Post(RegisterRequest request)
        {
            LoginResponseWrapper rsp = new LoginResponseWrapper();
            String loginHash = PasswordHasher.getHash(request.Password + request.Username);
            String apiKey = PasswordHasher.getHash(request.Password);
            if(request.PasswordCheck != request.Password)
            {
                rsp.ResponseCode = 400;
                rsp.Description = "Passwords do not match";
                return rsp;
            }
            try
            {
                Database.CreateTravellerUser(apiKey, loginHash, request.Username);
                rsp.ResponseCode = 200;
                rsp.ApiKey = apiKey;
                rsp.Description = "ok";
            }
            catch
            {
                rsp.ResponseCode = 400;
                rsp.Description = "This user already exists";
            }
            return rsp;
        }

    }
}
