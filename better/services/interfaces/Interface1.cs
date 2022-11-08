using better.Models;
using better.Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace better.services.interfaces
{
    public interface ICityService
    {
        City GetCityByName(string cityName);
        OperationSuccesDTO<IList<City>> GetCities();
        OperationResultDTO UpdateCostOfWrkingHour(string cityName, double workingHourCost);
        OperationResultDTO UpdateTransportCost(string cityName, double transportCost);
        OperationResultDTO AddCity(City city);
        OperationResultDTO DeleteCity(string cityName);
    }
}
