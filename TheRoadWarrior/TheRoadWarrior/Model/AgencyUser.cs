using System;
using System.Collections.Generic;

namespace TheRoadWarrior.Model
{
    public class AgencyUser
    {
        public int Id { get; set; }
        public String Name { get; set; }
        //resevations created by this Agency
        List<Reservation> Reservations { get; set; }
        public AgencyUser()
        {
            Reservations = new List<Reservation>();
        }
    }
}
