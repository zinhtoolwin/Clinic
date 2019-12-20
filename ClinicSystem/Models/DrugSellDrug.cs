using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class DrugSellDrug
    {
        public int DrugId { get; set; }
        public Drug Drug { get; set; }
        public int DrugsellId { get; set; }
        public DrugSell DrugSell { get; set; }  
       
    }
}
