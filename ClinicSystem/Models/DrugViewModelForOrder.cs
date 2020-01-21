using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class DrugViewModelForOrder
    {
        public int DrugIdd { get; set; }
        public string DrugName { get; set; }

        public int OrderId { get; set; }
        public int Qty { get; set; }
        public int Total_Qty { get; set; }
        public int Frequency { get; set; }
    }
}
