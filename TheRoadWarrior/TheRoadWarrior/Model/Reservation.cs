using System;

namespace TheRoadWarrior.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        //Trip owning this reservation
        public Trip Trip;
        public float Price { get; set; }
        public float AmountAlreadyPaid { get; set; }
        public String Observations { get; set; }
        //if added by agency, this will identify the agency, else null
#nullable enable
        public AgencyUser? AgencyUser  { get; set; }
#nullable disable
    }
}
