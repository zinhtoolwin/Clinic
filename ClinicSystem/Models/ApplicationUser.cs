using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public bool Active { get; set; }
    }
}

//var druglist = await _context.Drugs.Include(s => s.DrugOrders).ThenInclude(sc => sc.Drug).ToListAsync();
//var patientlist = await _context.Patients.ToListAsync();