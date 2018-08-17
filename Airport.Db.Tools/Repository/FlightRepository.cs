using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Airport.Db.Tools.Context;
using Airport.Db.Tools.Contracts;
using Airport.Db.Tools.Helpers;
using Airport.Db.Tools.Models;

namespace Airport.Db.Tools.Repository
{
    class FlightRepository
    {
        private FlightModel _flight;
        private readonly AirportDbContext _context = AirportDbContext.GetInstance();

        public bool Save(FlightContractsModel flight)
        {
            if (flight == null)
            {
                throw new ArgumentNullException(nameof(flight));
            }

            using (_context)
            {
                this._flight = this._context.Flight.FirstOrDefault(x => x.Id == flight.Id);
                this._flight = ModelConverterHelper.GetModelFromContract(flight);
                this._context.SaveChanges();
            }

            return true;
        }

        public bool Add(FlightContractsModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using (_context)
            {
                this._flight = ModelConverterHelper.GetModelFromContract(model);
                this._context.Flight.Add(_flight);
                this._context.SaveChanges();
            }

            return true;
        }

        public bool RemoveById(long flightId)
        {
            if (flightId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(flightId));
            }

            using (_context)
            {
                this._flight = _context.Flight.FirstOrDefault(x => x.Id == flightId);

                if (this._flight == null)
                {
                    return false;
                }

                this._context.Flight.Remove(this._flight);
                this._context.SaveChanges();
            }

            return true;
        }

        public FlightContractsModel GetFlightById(long flightId)
        {
            if (flightId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(flightId));
            }

            using (_context)
            {
                this._flight = this._context.Flight.FirstOrDefault(x => x.Id == flightId);

                if (this._flight == null)
                {
                    return null;
                }
            }

            return ModelConverterHelper.GetContractModel(this._flight);
        }

        public List<FlightContractsModel> GetAllFlights()
        {
            List<FlightContractsModel> flightContracts = new List<FlightContractsModel>();

            using (_context)
            {
                IEnumerable<FlightModel> flights = _context.Flight.ToList();

                foreach (var flightModel in flights)
                {
                    flightContracts.Add(ModelConverterHelper.GetContractModel(flightModel));
                }
            }

            return flightContracts;
        }

    }
}
