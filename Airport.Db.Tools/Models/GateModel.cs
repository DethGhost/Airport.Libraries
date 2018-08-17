using Airport.Db.Tools.Repository.Enumirations;

namespace Airport.Db.Tools.Models
{
    class GateModel
    {
        public long Id { get; set; }
        public string Gate { get; set; }
        public GateStatus Status { get; set; }
    }
}
