using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class DrugOrder
    {
        [Key] 
        public int Id { get; set; }
        public string OrderName { get; set; }
        
        
    }
}
