using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class DoctorOrderViewModel
    {
       
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int TotalPrice { get; set; }

        public List<DoctorOrderDrugViewModel> DoctorOrderList { get; set; }
        public List<DrugViewModel> DrugItemList { get; set; }
    }
}
