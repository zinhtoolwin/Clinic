using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class DoctorOrder
    {
        public DoctorOrder()
        {
            DoctorOrderDrugs = new List<DoctorOrderDrug>();
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int TotalPrice { get; set; }

        public ICollection<DoctorOrderDrug> DoctorOrderDrugs { get; set; }
    }
}
