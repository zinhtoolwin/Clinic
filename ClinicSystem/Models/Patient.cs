using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class Patient
    {
        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public string Gender { get; set; }
        public int PhoneNo { get; set; }
        public string MariitalStatus { get; set; }
        public string Address { get; set; }
        
        public ICollection<VitalSign> VitalSigns { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public ICollection<DoctorOrder> DoctorOrders { get; set; }
    }
}
