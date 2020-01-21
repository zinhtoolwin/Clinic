using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class DrugOrderViewModel
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        
        public int OrderId { get; set; }
        public Order Order { get; set; }
      
        public int Qty { get; set; }
        public bool IsBillCleared { get; set; }
        public int Frequency { get; set; }
      
        public int DoctorFee { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MMMM/yyyy}")]
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public List<DrugOrderDrugViewModel> DrugOrderList { get; set; }
        public List<DrugViewModelForOrder> DrugItemList { get; set; }
    }
}
