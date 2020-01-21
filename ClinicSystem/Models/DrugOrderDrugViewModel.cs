using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class DrugOrderDrugViewModel
    {
        public int DrugIdd { get; set; }
        public string DrugName { get; set; }
        public int OrderId { get; set; }
        public int Qty { get; set; }
        public int Total_Amt { get; set; }
        public int Price { get; set; }
        public int Frequency { get; set; }
        public int Total_AmtandQty { get; set; }



    }
}
