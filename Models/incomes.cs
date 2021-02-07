using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace myBudget.Entity
{
    public class incomes
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        public string incomeName { get; set; }
        [DisplayName("Amount")]
        public int incomeAmount { get; set; }
        [DisplayName("Date")]
        public DateTime incomeDate { get; set; }
    }
}