using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Speciality")]
        public int SpecialityID { get; set; }
        public Speciality Speciality { get; set; }

        public int Age { get; set; }
        public string DoctorNRC { get; set; }
        public string NRC { get; set; }
        public string Gender { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Email { get; set; }
        public int PhoneNo { get; set; }


        public ICollection<Schedule> Schedules { get; set; }

        public ICollection<DoctorOrder> DoctorOrders { get; set; }

      

    }
}
