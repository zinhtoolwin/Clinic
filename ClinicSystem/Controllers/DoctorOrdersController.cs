using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicSystem.Data;
using ClinicSystem.Models;

namespace ClinicSystem.Controllers
{
    public class DoctorOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: DoctorOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DoctorOrders.Include(d => d.Doctor).Include(d => d.Patient).Include(a=>a.DoctorOrderDrugs).ThenInclude(b=>b.Drug).ToListAsync();
            return View(await applicationDbContext);
        }

        // GET: DoctorOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorOrder = await _context.DoctorOrders
                .Include(d => d.Doctor)
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorOrder == null)
            {
                return NotFound();
            }

            return View(doctorOrder);
        }

        // GET: DoctorOrders/Create
        public IActionResult Create(int doctorId,int patientId)
        {
            var drugs = _context.Drugs.ToList();

            List<DoctorOrderDrugViewModel> scList = new List<DoctorOrderDrugViewModel>();

            List<DrugViewModel> drgList = new List<DrugViewModel>();

            foreach (Drug c in drugs)
            {
                scList.Add(new DoctorOrderDrugViewModel() { DrugIdd = c.DrugId, DrugName = c.Name, Price = c.Price });
            }
            foreach (Drug c in drugs)
            {
                drgList.Add(new DrugViewModel() { DrugIdd = c.DrugId, DrugName = c.Name });
            }
            var std = new DoctorOrderViewModel()
            {
                DoctorOrderList = scList,
                DrugItemList = drgList

                //new List<DrugViewModel>()
            };
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name");
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Name");
            return View(std);
        }

        // POST: DoctorOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorOrderViewModel doctorOrder)
        {
            if (ModelState.IsValid)
            {
                /*
                _context.Add(doctorOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                */
                var std = new DoctorOrder()
                {
                    DoctorId = doctorOrder.DoctorId,
                    PatientId = doctorOrder.PatientId,
                    TotalPrice = doctorOrder.TotalPrice

                };
                _context.DoctorOrders.Add(std);

                await _context.SaveChangesAsync();

                List<DoctorOrderDrug> doctorOrderList = new List<DoctorOrderDrug>();

                foreach (DrugViewModel dm in doctorOrder.DrugItemList)
                {
                    doctorOrderList.Add(new DoctorOrderDrug()
                    {

                        DoctorOrderId = std.Id,
                        DrugId = dm.DrugIdd
                    });

                }
                _context.AddRange(doctorOrderList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", doctorOrder.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", doctorOrder.PatientId);
            return View(doctorOrder);
        }

        // GET: DoctorOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorOrder = await _context.DoctorOrders.FindAsync(id);
            if (doctorOrder == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", doctorOrder.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", doctorOrder.PatientId);
            return View(doctorOrder);
        }

        // POST: DoctorOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorId,PatientId,TotalPrice")] DoctorOrder doctorOrder)
        {
            if (id != doctorOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorOrderExists(doctorOrder.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", doctorOrder.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", doctorOrder.PatientId);
            return View(doctorOrder);
        }

        // GET: DoctorOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorOrder = await _context.DoctorOrders
                .Include(d => d.Doctor)
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorOrder == null)
            {
                return NotFound();
            }

            return View(doctorOrder);
        }

        // POST: DoctorOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorOrder = await _context.DoctorOrders.FindAsync(id);
            _context.DoctorOrders.Remove(doctorOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorOrderExists(int id)
        {
            return _context.DoctorOrders.Any(e => e.Id == id);
        }
    }
}
