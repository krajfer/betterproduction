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

        public OperationResultDTO UpdateCostOfWorkingHour(string cityName, double workingHourCost)
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
            context.City.Add(city);
            context.SaveChanges();

            return new OperationSuccesDTO<Module> { Message = "Sukces" };
        }

        public OperationResultDTO DeleteCity(string cityName)
        {
            var city = GetCityByName(cityName);

            if(city == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"Miasto {cityName} nie istnieje" };
            }

            context.City.Remove(city);
            context.SaveChanges();

            return new OperationSuccesDTO<Module> { Message = "Sukces" };
        }

        public OperationSuccesDTO<IList<City>> GetCities()
        {
            List<City> cities = context.City.ToList();
            return new OperationSuccesDTO<IList<City>> { Message = "Sukces", Result = cities };
        }

      
    }
}