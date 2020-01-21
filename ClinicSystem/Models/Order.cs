using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class Order
    {
        public Order()
        {
            DrugOrders = new List<DrugOrder>();
        } 
        [Key]
        
        public int Id { get; set; }
       
        [ForeignKey("Patient")]
       
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public bool IsBillClear { get; set; }
       
        public string VoucherId { get; set; }
        public ICollection<DrugOrder> DrugOrders { get; set; }

        
    }
}
