using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace better.Models
{
    public class CalculatorContext: DbContext
    {
        public CalculatorContext(): base("name=DefaultConnection")
        {

        }

        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<City> City { get; set; }

    }
}