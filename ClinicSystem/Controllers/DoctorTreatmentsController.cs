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
    public class DoctorTreatmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DoctorTreatmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DoctorTreatments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorTreatment>>> GetDoctorTreatment()
        {
            return await _context.DoctorTreatment.ToListAsync();
        }

        // GET: api/DoctorTreatments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorTreatment>> GetDoctorTreatment(int id)
        {
            var doctorTreatment = await _context.DoctorTreatment.FindAsync(id);

            if (doctorTreatment == null)
            {
                return NotFound();
            }

            return doctorTreatment;
        }

        // PUT: api/DoctorTreatments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctorTreatment(int id, DoctorTreatment doctorTreatment)
        {
            if (id != doctorTreatment.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctorTreatment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorTreatmentExists(id))
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

        // POST: api/DoctorTreatments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DoctorTreatment>> PostDoctorTreatment(DoctorTreatment doctorTreatment)
        {
            _context.DoctorTreatment.Add(doctorTreatment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctorTreatment", new { id = doctorTreatment.Id }, doctorTreatment);
        }

        // DELETE: api/DoctorTreatments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DoctorTreatment>> DeleteDoctorTreatment(int id)
        {
            var doctorTreatment = await _context.DoctorTreatment.FindAsync(id);
            if (doctorTreatment == null)
            {
                return NotFound();
            }

            _context.DoctorTreatment.Remove(doctorTreatment);
            await _context.SaveChangesAsync();

            return doctorTreatment;
        }

        private bool DoctorTreatmentExists(int id)
        {
            return _context.DoctorTreatment.Any(e => e.Id == id);
        }
    }
}
