using System.Collections.Generic;
using Airport.Db.Tools.Contracts;

namespace Airport.Db.Tools.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        bool Save(CustomerContractsModel model);
        bool RemoveById(long id);
        bool Add(CustomerContractsModel model);
        CustomerContractsModel GetById(long id);
        List<CustomerContractsModel> GetAllCustomers();
    }
}