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
    public class LoginController : ControllerBase
    {
        readonly ReservationsDbContext Database;
        public LoginController(ReservationsDbContext db)
        {
            Database = db;
        }

        [HttpPost]
        public LoginResponseWrapper Post (LoginRequest request)
        {
            LoginResponseWrapper rsp = new LoginResponseWrapper();
            {
               try
                {
                    var usr = Database.GetUser(request.Username);
                    if(PasswordHasher.checkHash(request.Password, usr.LoginHash)) {
                        rsp.ResponseCode = 200;
                        rsp.Description = "ok";
                        rsp.ApiKey = usr.ApiKey;
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
