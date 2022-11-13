using better.Models;
using better.Models.ModelsDTO;
using better.services.interfaces;
using System;
using better.services.Implementations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace better.services.Implementations
{
    public class CalculatorCostService:ICalculatorCostService
    {
        private readonly CalculatorContext context;
        private readonly ICityService cityService;
        private readonly IModuleService moduleService;
        private readonly ISearchHistoryService searchHistoryService;

        public CalculatorCostService(CalculatorContext context, ICityService cityService, IModuleService moduleService, ISearchHistoryService searchHistoryService)
        {
            this.context = context;
            this.cityService = cityService;
            this.moduleService = moduleService;
            this.searchHistoryService = searchHistoryService;
        }

        OperationResultDTO ICalculatorCostService.CalculateCost(string cityName, ModuleListDTO moduleListDTO)
        {
            var city = cityService.GetCityByName(cityName);

            if(city == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"Miasto {cityName} nie istnieje" };
            }

            var modulesCost = city.TransportCostToCity;

            foreach (String moduleName in moduleListDTO.ModuleList)
            {
                var module = moduleService.GetModuleByName(moduleName);

                if(module == null)
                {
                    return new OperationErrorDTO { Code = 404, Message = $"Modół {moduleName} nie istnieje" };
                }

                modulesCost = modulesCost + module.Price + (module.AssemblyTime * city.PriceByHour);
            }
            modulesCost = modulesCost * 1.3;

            return new OperationSuccesDTO<ResultCostDTO> { Message = "Sukces", Result = new ResultCostDTO { Cost = modulesCost, InSearchHistory = false } };
        }

    }
}