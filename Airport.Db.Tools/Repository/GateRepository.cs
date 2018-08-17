using System;
using System.Collections.Generic;
using System.Linq;
using Airport.Db.Tools.Context;
using Airport.Db.Tools.Contracts;
using Airport.Db.Tools.Helpers;
using Airport.Db.Tools.Models;
using Airport.Db.Tools.Repository.Interfaces;

namespace Airport.Db.Tools.Repository
{
    class GateRepository : IGateRepository
    {
        private readonly AirportDbContext _context = AirportDbContext.GetInstance();
        private GateModel _gate;

        public bool Remove(long id)
        {
            if(id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            using (_context)
            {
                this._gate = this._context.Gate.FirstOrDefault(x => x.Id == id);

                if (this._gate == null)
                {
                    return false;
                }

                this._context.Gate.Remove(this._gate);
                this._context.SaveChanges();
            }

            return true;
        }

        public bool Add(GateContractsModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using (_context)
            {
                this._gate = ModelConverterHelper.GetModelFromContract(model);
                this._context.Gate.Add(this._gate);
                this._context.SaveChanges();
            }

            return true;
        }

        public List<GateContractsModel> GetAllGates()
        {
            List<GateContractsModel> gates = new List<GateContractsModel>();

            using (_context)
            {
                List<GateModel> gateModels = this._context.Gate.ToList();

                foreach (GateModel model in gateModels)
                {
                    gates.Add(ModelConverterHelper.GetContractModel(model));
                }
            }

            return gates;
        }

        public GateContractsModel GetById(long gateId)
        {
            if (gateId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(gateId));
            }

            using (_context)
            {
                this._gate = this._context.Gate.FirstOrDefault(x => x.Id == gateId);
            }

            return this._gate == null ? null : ModelConverterHelper.GetContractModel(this._gate);
        }

        public bool Save(GateContractsModel gate)
        {
            if (gate == null)
            {
                throw new ArgumentNullException(nameof(gate));
            }

            using (_context)
            {
                this._gate = this._context.Gate.FirstOrDefault(x => x.Id == gate.Id);
                this._gate = ModelConverterHelper.GetModelFromContract(gate);
                this._context.SaveChanges();
            }

            return true;
        }
    }
}
