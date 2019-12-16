using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Day { get; set; }

        [DataType(DataType.Time)]
        public DateTime FromTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime ToTime { get; set; }

       public ICollection<Appointment> Appointments { get; set; }
    }
}
