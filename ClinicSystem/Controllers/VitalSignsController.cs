using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicSystem.Data;
using ClinicSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClinicSystem.Controllers
{
    [Authorize]
    public class VitalSignsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VitalSignsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VitalSigns
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VitalSigns.Include(v => v.Patient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VitalSigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vitalSign = await _context.VitalSigns
                .Include(v => v.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vitalSign == null)
            {
                return NotFound();
            }

            return View(vitalSign);
        }

        // GET: VitalSigns/Create
        public async Task<IActionResult> CreateAsync(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(Id);
            if (patient == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Name", patient.Id);
            return View();
            //ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id");
            //return View();



            //ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Name");
            //return View();
        }

        // POST: VitalSigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,Height,Weight,Temperature,BloodSugar,BloodPressureUNo,BloodPressureLNo")] VitalSign vitalSign)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(vitalSign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", vitalSign.PatientId);
            return View(vitalSign);
        }

        // GET: VitalSigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vitalSign = await _context.VitalSigns.FindAsync(id);
            if (vitalSign == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", vitalSign.PatientId);
            return View(vitalSign);
        }

        // POST: VitalSigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,Height,Weight,Temperature,BloodSugar,BloodPressureUNo,BloodPressureLNo")] VitalSign vitalSign)
        {
            if (id != vitalSign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vitalSign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VitalSignExists(vitalSign.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", vitalSign.PatientId);
            return View(vitalSign);
        }

        // GET: VitalSigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vitalSign = await _context.VitalSigns
                .Include(v => v.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vitalSign == null)
            {
                return NotFound();
            }

            return View(vitalSign);
        }

        // POST: VitalSigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vitalSign = await _context.VitalSigns.FindAsync(id);
            _context.VitalSigns.Remove(vitalSign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VitalSignExists(int id)
        {
            return _context.VitalSigns.Any(e => e.Id == id);
        }
    }
}
