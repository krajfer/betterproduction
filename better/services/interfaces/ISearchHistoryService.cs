using better.Models;
using better.Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace better.services.interfaces
{
    public interface ISearchHistoryService
    {
        ResultCostDTO GetSearchHistory(string cityName, ModuleListDTO moduleListDTO);
        OperationSuccesDTO<IList<SearchHistory>> GetSearchHistories();
        OperationResultDTO AddSearchHistory(SearchHistory searchHistory);
    }
}
