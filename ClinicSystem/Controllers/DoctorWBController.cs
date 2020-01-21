using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClinicSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem.Controllers
{
    public class DoctorWBController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DoctorWBController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // login ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var doctor = _context.Doctors.Where(d => d.UserId == userId).FirstOrDefault();

            var dayOfWeek = GetDayOfWeek();
            //int dayOfWeek = DateTime.Today.DayOfWeek == DayOfWeek.Sunday
            //     ? 7
            //     : (int)DateTime.Today.DayOfWeek;
            // 

            var schedule = _context.Schedules.Where(s => s.DoctorId == doctor.Id && s.Day == dayOfWeek).FirstOrDefault();
            if (schedule == null)
            {
                return NotFound();
            }
            try
            {
                var patientList = _context.Appointments.Where(a => a.ScheduleId == schedule.Id).Include(p => p.Patient).ToList();

                return View(patientList);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        private string GetDayOfWeek()
        {
            string day = "Monday";
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
                day = "Monday";

            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
            {
                day = "Tuesday";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Wednesday)
            {
                day = "Wednesday";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
            {
                day = "Thursday";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Friday)
            {
                day = "Friday";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
            {
                day = "Saturday";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
            {
                day = "Sunday";
            }
            return day;
        }
    }
}