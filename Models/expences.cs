using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace myBudget.Entity
{
    public class expences
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        public string expenceName { get; set; }
        [DisplayName("Amount")]
        public int expenceAmount { get; set; }
        [DisplayName("Date")]
        public DateTime expenceDate { get; set; }
    }
}