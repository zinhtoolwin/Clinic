using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class DoctorOrderDrug
    {
        public int DoctorOrderId { get; set; }
        public DoctorOrder DoctorOrder { get; set; }

        public int DrugId { get; set; }
        public Drug Drug { get; set; }
    }
}
