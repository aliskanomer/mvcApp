using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace myBudget.Entity
{
    public class dataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            //incomes dummy data
            List<incomes> incomesTest = new List<incomes>()
            {
                new incomes(){incomeName="Salary",incomeAmount=1670,incomeDate=DateTime.Now},
            };
            foreach (var income in incomesTest)
            {
                context.Incomes.Add(income);
            }
            context.SaveChanges();

            //expences dummy data
            List<expences> expencesTest = new List<expences>()
            {
                new expences(){expenceName="Car",expenceAmount=60,expenceDate=DateTime.Now},
                new expences(){expenceName="Clothing",expenceAmount=320,expenceDate=DateTime.Now},
                new expences(){expenceName="Food",expenceAmount=85,expenceDate=DateTime.Now},
                new expences(){expenceName="Leisure",expenceAmount=35,expenceDate=DateTime.Now},
                new expences(){expenceName="Living",expenceAmount=560,expenceDate=DateTime.Now},

            };
            foreach (var expence in expencesTest)
            {
                context.Expences.Add(expence);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}