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
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var drugList = await _context.Drugs.Include(s => s.DrugOrders).ThenInclude(sc => sc.Drug).ToListAsync();
            var applicationDbContext = _context.Order.Include(o => o.Doctor).Include(o => o.Patient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Doctor)
                .Include(o => o.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var patient = _context.Appointments
                .Include(a => a.Patient)
                .Select(a => new Appointment() {Id = a.Id,Patient =a.Patient }).FirstOrDefault(c=>c.Id==Id);

           
            //var selectlist = from s in order.VoucherId orderby order.Id descending select s;

            var drugs = _context.Drugs.ToList();
            List<DrugOrderDrugViewModel> OrderList = new List<DrugOrderDrugViewModel>();
            List<DrugViewModelForOrder> drglist = new List<DrugViewModelForOrder>();

            foreach (Drug c in drugs)
            {
                OrderList.Add(new DrugOrderDrugViewModel() { DrugIdd = c.DrugId, DrugName = c.Name, Price = c.Price});
            }
            foreach (Drug c in drugs)
            {
                drglist.Add(new DrugViewModelForOrder() { DrugIdd = c.DrugId, DrugName = c.Name,   });
            }
            var std = new DrugOrderViewModel()
            {
                
                DrugOrderList = OrderList,
                DrugItemList = drglist
            };
           // std.Patient = patient.Patient;
           
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name");
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Name");
            return View(std);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,PatientId,DoctorId,IsBillClear,VoucherId")]Order order, DrugOrderViewModel drug)
        {
           
            string vId = _context.Order
                .OrderByDescending(p => p.Id)
                .Select(p=>p.VoucherId)
                .FirstOrDefault();
            
           

            // [Bind("OrderId,PatientId,DoctorId,IsBillClear")]Order order,
            if (ModelState.IsValid)
            {
                //_context.DrugOrders.Add(std);
                //await _context.SaveChangesAsync();

                ICollection<DrugOrder> drugOrderList = new List<DrugOrder>();

                foreach (DrugViewModelForOrder dm in drug.DrugItemList)
                {
                    order.DrugOrders.Add(new DrugOrder()
                    {
                       
                        DrugId = dm.DrugIdd,
                        Qty = dm.Qty,
                        Frequency = dm.Frequency,
                        Total_Qty = dm.Total_Qty,
                        
                        

                    });

                }
                
                if (vId == null)
                {
                    string p = "C00000";
                    int j = 1;
                    string p2 = p + j;
                    string j2 = j.ToString();
                    int k = j2.Length;
                    int t = p2.Length - k;
                    string z = p2.Substring(0, t);
                    p2 = z + j;
                    j++;


                    order.VoucherId = p2;
                }
                else
                {
                    string tj = vId.Substring(5);
                    int r = int.Parse(tj);
                    r = r + 1;
                    string r2 = r.ToString();
                    int x = r2.Length;
                    int q = vId.Length - x;
                    string o = vId.Substring(0, q);
                    order.VoucherId = o + r;

                }
               


                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name", order.DoctorId);
           ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Name", order.PatientId);
            return View();
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name", order.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Name", order.PatientId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,PatientId,DoctorId,IsBillClear")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", order.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", order.PatientId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Doctor)
                .Include(o => o.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
