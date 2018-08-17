using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Airport.Db.Tools.Context;
using Airport.Db.Tools.Contracts;
using Airport.Db.Tools.Helpers;
using Airport.Db.Tools.Models;
using Airport.Db.Tools.Repository.Interfaces;

namespace  Airport.Db.Tools.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerModel _customer;
        private readonly AirportDbContext _context = AirportDbContext.GetInstance();

        public bool Save(CustomerContractsModel customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            this._customer = ModelConverterHelper.GetModelFromContract(customer);

            using (_context)
            {
                var customerModel = _context.Customer.FirstOrDefault(x => x.Id == this._customer.Id);
                customerModel = _customer;
                _context.SaveChanges();
            }

            return true;
        }

        public bool Add(CustomerContractsModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using (_context)
            {
                this._customer = ModelConverterHelper.GetModelFromContract(model);
                this._context.Customer.Add(this._customer);
            }

            return true;
        }

        public CustomerContractsModel GetById(long customerId)
        {
            CustomerModel customer;

            using (_context)
            {
                customer = _context.Customer.FirstOrDefault(x => x.Id == customerId);
            }

            return customer == null ? null : ModelConverterHelper.GetContractModel(customer);
        }

        public List<CustomerContractsModel> GetAllCustomers()
        {
            List<CustomerContractsModel> customerList = new List<CustomerContractsModel>();

            using (_context)
            {
                var customers = _context.Customer.ToList();

                foreach (var customer in customers)
                {
                    customerList.Add(ModelConverterHelper.GetContractModel(customer));
                }
            }

            return customerList;
        }

        public bool RemoveById(long customerId)
        {
            if (customerId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(customerId));
            }

            using (_context)
            {
                this._customer = this._context.Customer.FirstOrDefault(x => x.Id == customerId);

                if (this._customer == null)
                {
                    return false;
                }

                this._context.Customer.Remove(this._customer);
                this._context.SaveChanges();
            }

            return true;
        }

        
    }
}
