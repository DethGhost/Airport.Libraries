using Airport.Site.Mvc.Models.Enumirations;

namespace Airport.Site.Mvc.Models.Contracts
{
    public class PlaneContractsModel
    {
        public long Id { get; set; }
        public PlaneType Type { get; set; }
        public int MaxPassenger { get; set; }
    }
}
