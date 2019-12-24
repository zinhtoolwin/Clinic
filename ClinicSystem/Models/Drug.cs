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

            DoctorOrderDrugs = new List<DoctorOrderDrug>();
        }
        public int DrugId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
      

        public int Price { get; set; }
        
        //for Extra Patient
        public ICollection<DrugSellDrug> DrugSellDrugs { get; set; }

        //for Clinic Patient
        public ICollection<DoctorOrderDrug> DoctorOrderDrugs { get; set; }
       
    }
}
