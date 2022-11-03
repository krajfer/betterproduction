using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace better.Models
{
    public class Module
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public decimal Wage { get; set; }
        public string ShortDescription { get; set; }

    }
}