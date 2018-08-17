using System.Data.Entity;
using Airport.Db.Tools.Models;

namespace Airport.Db.Tools.Context
{
    class AirportDbContext : DbContext
    {
        private static AirportDbContext _instance;

        private AirportDbContext()
            : base("DBConnection")
        { }

        public static AirportDbContext GetInstance()
        {
            return _instance ?? new AirportDbContext();
        }

        public DbSet<CustomerModel> Customer { get; set; }
        public DbSet<FlightModel> Flight { get; set; }
        public DbSet<GateModel> Gate { get; set; }
        public DbSet<PlaneModel> Plane { get; set; }
    }
}
