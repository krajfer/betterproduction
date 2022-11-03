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
        public decimal TransportCostToCity { get; set; }
        public decimal PriceByHour { get; set; }

    }
}