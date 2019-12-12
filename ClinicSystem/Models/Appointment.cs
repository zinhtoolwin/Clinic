using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime Date { get; set; }

        [ForeignKey("Specility")]
        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        

        [ForeignKey("Schedule")]

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

    }
}
