using System;
using System.ComponentModel.DataAnnotations;

namespace TheRoadWarrior.Model.RequestWrappers
{
    public class RegisterRequest
    {
        [Required]
        public String Password { get; set; }
        [Required]
        public String Username { get; set; }
        [Required]
        public String PasswordCheck { get; set; }

    }
}
