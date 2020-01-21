using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class Drug
    {
        public Drug()
        {
            DrugSellDrugs = new List<DrugSellDrug>();
            DrugOrders = new List<DrugOrder>();
        }
        public int DrugId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public ICollection<DrugSellDrug> DrugSellDrugs { get; set; }
       public ICollection<DrugOrder> DrugOrders { get; set; }
    }
}
