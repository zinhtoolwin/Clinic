using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class DrugSellViewModel
    {
        [Key]
        public int Id { get; set; }
        public string PatientName { get; set; }
        public int Total_Amt { get; set; }

       public int Qty { get; set; }

        public List<DrugSellDrugViewModel> DrugSellList { get; set; }
        public List<DrugViewModel> DrugItemList { get; set; }
    }
}
