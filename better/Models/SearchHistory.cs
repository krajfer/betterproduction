using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace better.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public string DateOfSearch { get; set; }
        public int CityId { get; set; }
        public int ModuleId { get; set; }
    }
}