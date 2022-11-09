using better.Models;
using better.Models.ModelsDTO;
using better.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace better.services.Implementations
{
    public class SearchHistoryService:ISearchHistoryService
    {
        private readonly CalculatorContext context;
        private readonly IModuleService moduleService;
        private readonly ICityService cityService;

        public SearchHistoryService(CalculatorContext context, IModuleService moduleService, ICityService cityService)
        {
            this.context = context;
            this.moduleService = moduleService;
            this.cityService = cityService;
        }

        public OperationResultDTO AddSearchHistory(SearchHistory searchHistory)
        {
            context.SearchHistory.Add(searchHistory);
            context.SaveChanges();

            return new OperationSuccesDTO<Module> { Message = "Sukces" };
        }

        public OperationResultDTO AddSearchHistroy(SearchHistory searchHistory)
        {
            throw new NotImplementedException();
        }

        public ResultCostDTO GetSearchHistory(string cityName, ModuleListDTO moduleListDTO)
        {
            var city = cityService.GetCityByName(cityName);
            if (city == null)
            {
                return new ResultCostDTO { InSearchHistory = false};
            }
            var searchHistoryList = context.SearchHistory.Where(sh => sh.CityId == city.Id);
            if (searchHistoryList == null)
            {
                return new ResultCostDTO { InSearchHistory = false };
            }
            int counterModule = 0;
            foreach(SearchHistory searchHistory in searchHistoryList)
            {
                counterModule = 0;
                foreach(string searchHistoryPar in moduleListDTO.ModuleList)
                {
                    if(searchHistory.ModuleName1==searchHistoryPar|| searchHistory.ModuleName2==searchHistoryPar|| searchHistory.ModuleName3 == searchHistoryPar || searchHistory.ModuleName4 == searchHistoryPar)
                    {
                        counterModule++;
                    }
                    else
                    {
                        break;
                    }
                }
                if(moduleListDTO.ModuleList.Count() ==ModuleHasValue(searchHistory) && moduleListDTO.ModuleList.Count() == counterModule)
                {
                    return new ResultCostDTO {  InSearchHistory = true,Cost = searchHistory.ProductionCost};    
                }
            }return new ResultCostDTO { InSearchHistory = false };
        }

        OperationSuccesDTO<IList<SearchHistory>> ISearchHistoryService.GetSearchHistories()
        {
            List<SearchHistory> searchHistories = context.SearchHistory.ToList();

            return new OperationSuccesDTO<IList<SearchHistory>> { Message = "Sukces", Result = searchHistories };
        }

        private int ModuleHasValue(SearchHistory SearchHistory)
        {
            int couter = 0;

            if (!(SearchHistory.ModuleName1 == string.Empty)) couter++;
            if (!(SearchHistory.ModuleName2 == string.Empty)) couter++;
            if (!(SearchHistory.ModuleName3 == string.Empty)) couter++;
            if (!(SearchHistory.ModuleName4 == string.Empty)) couter++;

            return couter;
        }

    }
}