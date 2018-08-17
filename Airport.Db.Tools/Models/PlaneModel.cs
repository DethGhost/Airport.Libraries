using Airport.Db.Tools.Repository.Enumirations;

namespace Airport.Db.Tools.Models
{
    class PlaneModel
    {
        public long Id { get; set; }
        public PlaneType Type { get; set; }
        public int MaxPassenger { get; set; }
    }
}
