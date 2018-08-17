using Airport.Site.Mvc.Models.Enumirations;

namespace Airport.Site.Mvc.Models.Contracts
{
    public class GateContractsModel
    {
        public long Id { get; set; }
        public string Gate { get; set; }
        public GateStatus Status { get; set; }
    }
}
