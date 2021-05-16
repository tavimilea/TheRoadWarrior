using Microsoft.AspNetCore.Mvc;
using TheRoadWarrior.Model;
using TheRoadWarrior.Model.Hashing;
using TheRoadWarrior.Model.RequestWrappers;

namespace TheRoadWarrior.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ReservationsDbContext database;
        public LoginController(ReservationsDbContext db)
        {
            database = db;
        }

        [HttpPost]
        public LoginResponseWrapper Post(LoginRequest request)
        {
            LoginResponseWrapper rsp = new LoginResponseWrapper();
            {
                try
                {
                    var usr = database.GetUser(request.Username);
                    if (PasswordHasher.CheckHash(request.Password, usr.LoginHash)) {
                        rsp.ResponseCode = (int)ResponseConstants.SUCCES;
                        rsp.Description = "ok";
                        rsp.ApiKey = usr.ApiKey;
                    }
                }
                catch
                {
                    rsp.ResponseCode = (int)ResponseConstants.FAIL;
                    rsp.Description = "Wrong password/username";
                }
            }
            return rsp;
        }

        //[HttpGet("apiToken")]
        
       // public 
    }
}
