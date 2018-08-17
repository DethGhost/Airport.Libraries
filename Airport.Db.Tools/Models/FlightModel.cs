using System;
using Airport.Db.Tools.Repository.Enumirations;

namespace Airport.Db.Tools.Models
{
    class FlightModel
    {
        public long Id { get; set; }
        public FlightType FlightType { get; set; }
        public decimal Price { get; set; }
        public PlaneModel Plane { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity{ get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public GateModel Gate { get; set; }
        public FlightStatus Status { get; set; }
    }
}
