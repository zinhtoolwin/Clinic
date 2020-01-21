using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicSystem.Data;
using ClinicSystem.Models;
using System.Security.Claims;

namespace ClinicSystem.Controllers
{
    public class BillingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BillingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Billings
        public async Task<IActionResult> Index()
        {
            var doctorlist = _context.Doctors.ToList();
            var applicationDbContext = _context.Billings.Include(b => b.Order).ThenInclude(b=>b.Patient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Billings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billing = await _context.Billings
                .Include(b => b.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billing == null)
            {
                return NotFound();
            }

            return View(billing);
        }

        // GET: Billings/Create
        public async Task<IActionResult> Create(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var orders = await _context.Order
                .Include(o => o.Doctor)
                .Include(o => o.Patient)
                .Select(o => new DrugOrderViewModel() { Id = o.Id, DoctorId = o.Doctor.Id, PatientId = o.Patient.Id, IsBillCleared = o.IsBillClear, Doctor = o.Doctor, Patient = o.Patient }).FirstOrDefaultAsync(m => m.Id == Id);
            var drugorderlist = _context.DrugOrders.ToList();

            var drugorder = _context.DrugOrders.Where(d => d.OrderId == Id).Select(c => new DrugOrderDrugViewModel
            {
                DrugIdd = c.DrugId,
                DrugName = c.Drug.Name,
                Price = c.Drug.Price,
                Qty = c.Qty,
                Total_Amt = c.Total_Qty,
                Frequency = c.Frequency,
                Total_AmtandQty = c.Total_Qty*c.Drug.Price
              

            }).ToList();
            orders.DrugOrderList = drugorder;
 

            if (orders == null)
            {
                return NotFound();
            }



            return View(orders);
        }

        // POST: Billings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,DoctorFee,CreatedDate,CreatedBy")] Billing billing ,DrugOrderViewModel drug)
        {
            if (ModelState.IsValid)
            {
                var std = new Billing()
                {
                    CreatedBy = User.FindFirstValue(ClaimTypes.Name),
                    CreatedDate = DateTime.Now,
                    DoctorFee = drug.DoctorFee,
                    IsBillDone = true,
                   OrderId = drug.Id

                };
 
                _context.Add(std);
                await _context.SaveChangesAsync();
               
            }
            // ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", billing.OrderId);
            //return View(std);
            return RedirectToAction(nameof(Index));
        }

        // GET: Billings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billing = await _context.Billings.FindAsync(id);
            if (billing == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", billing.OrderId);
            return View(billing);
        }

        // POST: Billings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,DoctorFee,CreatedDate,CreatedBy")] Billing billing)
        {
            if (id != billing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillingExists(billing.Id))
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
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", billing.OrderId);
            return View(billing);
        }

        // GET: Billings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billing = await _context.Billings
                .Include(b => b.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billing == null)
            {
                return NotFound();
            }

            return View(billing);
        }

        // POST: Billings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billing = await _context.Billings.FindAsync(id);
            _context.Billings.Remove(billing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillingExists(int id)
        {
            return _context.Billings.Any(e => e.Id == id);
        }
    }
}
