using Airport.Db.Tools.Contracts;
using Airport.Db.Tools.Models;

namespace Airport.Db.Tools.Helpers
{
    static class ModelConverterHelper
    {
        public static FlightContractsModel GetContractModel(FlightModel model)
        {
            return new FlightContractsModel
            {
                Id = model.Id,
                Gate = GetContractModel(model.Gate),
                Status = model.Status,
                ArrivalTime = model.ArrivalTime,
                ArrivalCity = model.ArrivalCity,
                DepartureTime = model.DepartureTime,
                Type = model.FlightType,
                DepartureCity = model.DepartureCity,
                Price = model.Price,
                Plane = GetContractModel(model.Plane)
            };
        }

        public static PlaneContractsModel GetContractModel(PlaneModel model)
        {
            return new PlaneContractsModel
            {
                Id = model.Id,
                Type = model.Type,
                MaxPassenger = model.MaxPassenger
            };
        }

        public static GateContractsModel GetContractModel(GateModel model)
        {
            return new GateContractsModel()
            {
                Id = model.Id,
                Gate = model.Gate,
                Status = model.Status
            };
        }

        public static FlightModel GetModelFromContract(FlightContractsModel flight)
        {
            return new FlightModel
            {
                Id = flight.Id,
                ArrivalCity = flight.ArrivalCity,
                ArrivalTime = flight.ArrivalTime,
                DepartureCity = flight.DepartureCity,
                DepartureTime = flight.DepartureTime,
                FlightType = flight.Type,
                Gate = GetModelFromContract(flight.Gate),
                Plane = GetModelFromContract(flight.Plane),
                Price = flight.Price,
                Status = flight.Status
            };
        }

        public static GateModel GetModelFromContract(GateContractsModel model)
        {
            return model == null ? null : new GateModel
            {
                Id = model.Id,
                Gate = model.Gate,
                Status = model.Status
            };
        }

        public static PlaneModel GetModelFromContract(PlaneContractsModel model)
        {
            return model == null ? null : new PlaneModel
            {
                Id = model.Id,
                MaxPassenger = model.MaxPassenger,
                Type = model.Type
            };
        }

        public static CustomerContractsModel GetContractModel(CustomerModel model)
        {
            return new CustomerContractsModel
            {
                Id = model.Id,
                FirestName = model.FirestName,
                PassportNumber = model.PassportNumber,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                BirthDate = model.BirthDate
            };
        }

        public static CustomerModel GetModelFromContract(CustomerContractsModel customer)
        {
            return new CustomerModel
            {
                Id = customer.Id,
                FirestName = customer.FirestName,
                MiddleName = customer.MiddleName,
                LastName = customer.LastName,
                PassportNumber = customer.PassportNumber,
                BirthDate = customer.BirthDate
            };
        }
    }
}
