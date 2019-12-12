using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class Speciality
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Doctor> Doctors { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
