using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace better.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TransportCostToCity { get; set; }
        public double PriceByHour { get; set; }
        public virtual SearchHistory SearchHistory { get; set; }

    }
}