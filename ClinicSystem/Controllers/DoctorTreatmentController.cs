using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicSystem.Data;
using ClinicSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorTreatmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DoctorTreatmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getSpecial")]
        public IEnumerable<Speciality> GetSpecial()
        {
            return _context.Specialities;
        }

        [HttpGet("getDoctorBySpecial/{specialId}")]
        public IEnumerable<Doctor> GetDoctorBySpecial(int specialId)
        {
            var list = _context.Doctors.Where(a => a.Speciality.Id == specialId);
            return list;
        }
        [HttpGet("getPartByDoctor/{doctorId}")]
        public IEnumerable<Schedule> GetPartByDoctor(int doctorId)
        {
            var list = _context.Schedules.Where(a => a.Doctor.Id == doctorId);
            return list;
        }
        [HttpGet("getTreatmentDateBySchduleDay/{scheduleId}")]
        public IEnumerable<Appointment> GetTreatmentDateBySchduleDay(int scheduleId)
        {
            var list = _context.Appointments.Where(a => a.Schedule.Id ==scheduleId);
            return list;
        }
      [HttpGet("getShowAppointment/{schduleId}")]
      public IEnumerable<Appointment> GetShowAppointment(int schduleId)
        {
            var list = _context.Appointments.Where(a => a.Schedule.Id == schduleId);
            return list;

        }

        [HttpGet("getAppointmentTableByDays/{day}")]
        public IEnumerable<Appointment> GetAppointmentTableByDays(int day)
        {
            
            var list = _context.Appointments.Include(s=>s.Schedule).ThenInclude(d=>d.Doctor).Include(p=>p.Patient).Where(a => a.Id == day).ToList();
            return list;
        }

        [HttpGet("getVitalTableByPatientName/{patientName}")]
        public IEnumerable<VitalSign> getVitalTableByPatientName(string patientName)
        {

            var list = _context.VitalSigns.Include(r=>r.Patient).Where(a => a.Patient.Name == patientName);
            return list;
        }
    }
}