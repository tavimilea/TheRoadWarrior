﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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