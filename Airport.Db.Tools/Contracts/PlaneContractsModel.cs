using Airport.Db.Tools.Repository.Enumirations;

namespace Airport.Db.Tools.Contracts
{
    public class PlaneContractsModel
    {
        public long Id { get; set; }
        public PlaneType Type { get; set; }
        public int MaxPassenger { get; set; }
    }
}
