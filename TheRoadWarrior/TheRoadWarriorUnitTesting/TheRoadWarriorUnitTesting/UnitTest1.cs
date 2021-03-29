using System;
using TheRoadWarrior.Model;
using Xunit;

namespace TheRoadWarriorUnitTesting
{
    public class UnitTest1
    {
        private ReservationDbContext Db;
        public UnitTest1(ReservationDbContext db)
        {
            this.Db = db;
        }
        [Fact]
        public void Test1()
        {
            Console.WriteLine(Db);
        }
    }
}
