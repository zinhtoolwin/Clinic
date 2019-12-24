using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class DrugSell
    {
        public DrugSell()
        {
            DrugSellDrugs = new List<DrugSellDrug>();
        }
        public int Id { get; set; }
        public string PatientName { get; set; }
        public int Qty { get; set; }
        public int Total_Price { get; set; }

        //for extra patient
        public ICollection<DrugSellDrug> DrugSellDrugs { get; set; }
        
        
    }
}
