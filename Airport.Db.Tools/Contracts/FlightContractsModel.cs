using System;
using Airport.Db.Tools.Repository.Enumirations;

namespace Airport.Db.Tools.Contracts
{
    public class FlightContractsModel
    {
        public long Id { get; set; }
        public FlightType Type { get; set; }
        public decimal Price { get; set; }
        public PlaneContractsModel Plane { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity{ get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public GateContractsModel Gate { get; set; }
        public FlightStatus Status { get; set; }
    }
}
