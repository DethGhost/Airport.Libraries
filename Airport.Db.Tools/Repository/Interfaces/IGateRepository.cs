using System.Collections.Generic;
using Airport.Db.Tools.Contracts;

namespace Airport.Db.Tools.Repository.Interfaces
{
    public interface IGateRepository
    {
        bool Save(GateContractsModel model);
        bool Remove(long id);
        bool Add(GateContractsModel model);
        GateContractsModel GetById(long id);
        List<GateContractsModel> GetAllGates();
    }
}