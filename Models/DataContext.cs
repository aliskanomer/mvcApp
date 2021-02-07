using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace myBudget.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dbConnection")
        {
            Database.SetInitializer(new dataInitializer());
        }
        public DbSet<incomes> Incomes { get; set; }
        public DbSet<expences> Expences { get; set; }
    }
}