using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class DrugOrder
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Drug")]
        public int DrugId { get; set; }
        public Drug Drug { get; set; }


        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Qty { get; set; }
        public int Total_Qty { get; set; }
        public int Frequency { get; set; }

       

        
        
    }
}
