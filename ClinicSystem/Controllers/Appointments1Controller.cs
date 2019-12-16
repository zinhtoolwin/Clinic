using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicSystem.Data;
using ClinicSystem.Models;

namespace ClinicSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Appointments1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Appointments1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Appointments1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        // GET: api/Appointments1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        [HttpGet("getDoctor")]
        public IEnumerable<Doctor> GetDoctor()
        {
            return _context.Doctors.ToList();
        }

        [HttpGet("getSpecialities")]
        public IEnumerable<Speciality> GetSepcial()
        {
            return _context.Specialities.ToList();
        }

        [HttpGet("getSchedule")]
        public IEnumerable<Schedule> GetSchedule()
        {
            return _context.Schedules.ToList();
        }

        [HttpGet("getDoctorBySpecial/{specialId}")]
        public IEnumerable<Doctor> GetDoctorBySpecial(int specialId)
        {
            var list = _context.Doctors.Where(a => a.Speciality.Id == specialId);
            return list;
        }

        [HttpGet("getScheduleByDoctor/{doctorId}")]
        public IEnumerable<Schedule> GetScheduleByDoctor(int doctorId)
        {
            var list = _context.Schedules.Where(a => a.Doctor.Id == doctorId);
            return list;
        }

        [HttpGet("getTimeBySchedule/{scheduleId}")]
        public IEnumerable<Schedule> GetTimeBySchedule(int scheduleId)
        {
            var list = _context.Schedules.Where(a => a.Id ==scheduleId);
            return list;
        }

        // PUT: api/Appointments1/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Appointments1
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
        }

        // DELETE: api/Appointments1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointment>> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return appointment;
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
    }
}
