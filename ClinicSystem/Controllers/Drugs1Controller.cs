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
    public class Drugs1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Drugs1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Drugs1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drug>>> GetDrug()
        {
            return await _context.Drugs.ToListAsync();
        }

        // GET: api/Drugs1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drug>> GetDrug(int id)
        {
            var drug = await _context.Drugs.FindAsync(id);

            if (drug == null)
            {
                return NotFound();
            }

            return drug;
        }

        // PUT: api/Drugs1/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrug(int id, Drug drug)
        {
            if (id != drug.DrugId)
            {
                return BadRequest();
            }

            _context.Entry(drug).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugExists(id))
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

        // POST: api/Drugs1
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Drug>> PostDrug(Drug drug)
        {
            _context.Drugs.Add(drug);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrug", new { id = drug.DrugId }, drug);
        }

        // DELETE: api/Drugs1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Drug>> DeleteDrug(int id)
        {
            var drug = await _context.Drugs.FindAsync(id);
            if (drug == null)
            {
                return NotFound();
            }

            _context.Drugs.Remove(drug);
            await _context.SaveChangesAsync();

            return drug;
        }

        private bool DrugExists(int id)
        {
            return _context.Drugs.Any(e => e.DrugId == id);
        }
    }
}
