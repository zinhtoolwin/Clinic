using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controllers
{
    public class DoctorWorkBenchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorWorkBenchController(ApplicationDbContext context)
        {
            _context = context;
        }



    }
}