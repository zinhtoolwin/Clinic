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
        
      

        [HttpGet("getAppointmentTableByDays/{scheduleId}/{treateDate}")]
        public IEnumerable<Appointment> GetAppointmentTableByDays(int scheduleId, DateTime treateDate)
        {
            
            var list = _context.Appointments.Include(s=>s.Schedule).ThenInclude(d=>d.Doctor).Include(p=>p.Patient).Where(a => a.Schedule.Id == scheduleId).Where(o=>o.TreatementDate== treateDate).ToList();
            return list;
        }

        [HttpGet("getVitalByPatient/{id}")]
        public IEnumerable<VitalSign> GetVitalByPatient(int id)
        {
            var list = _context.VitalSigns.Include(b=>b.Patient).Where(a => a.Patient.Id == id);
            return list;
        }

        [HttpGet("getDrugsTableByPatientId/{PaId}")]
        public IEnumerable<DoctorOrderDrug> GetDrugsTableByPatientId(int PaId)
        {
            var list = _context.DoctorOrderDrugs.Include(b=>b.DoctorOrder).ThenInclude(t=>t.Patient).Include(e=>e.DoctorOrder).ThenInclude(i=>i.Doctor).Include(a=>a.Drug).Where(c=>c.DoctorOrder.PatientId==PaId);
            return list;
        }


    }
}