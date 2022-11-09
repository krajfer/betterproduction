using better.Models;
using better.Models.ModelsDTO;
using better.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace better.services.Implementations
{
    public class CityService : ICityService
    {
        private readonly CalculatorContext context;

        public CityService(CalculatorContext context)
        {
            this.context = context;
        }

       

        public City GetCityByName(string cityName)
        {
            return context.City.Where(city => city.Name == cityName).FirstOrDefault();
        }

       

        public OperationResultDTO UpdateTransportCost(string cityName, double transportCost)
        {
            var updateCity = context.City.Where(city => city.Name == cityName).FirstOrDefault();
            if (updateCity == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"Miasto {cityName} nie istnieje" };
            }
            updateCity.TransportCostToCity = transportCost;
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Sukces" };
        }

        public OperationResultDTO UpdateCostOfWrkingHour(string cityName, double workingHourCost)
        {
            var updateCity = context.City.Where(city => city.Name == cityName).FirstOrDefault();
            if (updateCity == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"Miasto {cityName} nie istnieje" };
            }
            updateCity.PriceByHour = workingHourCost;
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Sukces" };
        }


        public OperationResultDTO AddCity(City city)
        {
            throw new NotImplementedException();
        }

        public OperationResultDTO DeleteCity(string cityName)
        {
            throw new NotImplementedException();
        }

        public OperationSuccesDTO<IList<City>> GetCities()
        {
            throw new NotImplementedException();
        }

      
    }
}