using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class VitalSign
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public double Temperature { get; set; }
        public double BloodSugar { get; set; }
        public double BloodPressureUNo { get; set; }
        public double BloodPressureLNo { get; set; }

        
    }
}
