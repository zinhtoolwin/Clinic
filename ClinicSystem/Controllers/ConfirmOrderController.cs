using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicSystem.Data;
using ClinicSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem.Controllers
{
    [Authorize]
    public class ConfirmOrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfirmOrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var drugList = await _context.Drugs.Include(s => s.DrugOrders).ThenInclude(sc => sc.Drug).ToListAsync();
            var applicationDbContext = _context.Order.Include(o => o.Doctor).Include(o => o.Patient);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Name");
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name");
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> ConOrder()
        {
            var drugList = await _context.Drugs.Include(s => s.DrugOrders).ThenInclude(sc => sc.Drug).ToListAsync();
            var applicationDbContext = _context.Order.Include(o => o.Doctor).Include(o => o.Patient);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Name");
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name");
            return View(await applicationDbContext.ToListAsync());
        }


        public async Task<IActionResult> Confirm_Order(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var orders = await _context.Order
                .Include(o => o.Doctor)
                .Include(o => o.Patient)
                .Select(o=>new DrugOrderViewModel() {Id=o.Id,DoctorId=o.Doctor.Id,PatientId=o.Patient.Id,IsBillCleared=o.IsBillClear,Doctor=o.Doctor,Patient=o.Patient}).FirstOrDefaultAsync(m => m.Id == Id);

            var drugorderlist = _context.DrugOrders.ToList();

            var drugorder = _context.DrugOrders.Where(d=>d.OrderId==Id).Select(c => new DrugOrderDrugViewModel
            {
                DrugIdd = c.DrugId,
                DrugName = c.Drug.Name,
                Price = c.Drug.Price,
                Qty = c.Qty,
                Total_Amt = c.Total_Qty,
                Frequency = c.Frequency
               
            }).ToList();
            orders.DrugOrderList = drugorder;

            if (orders == null)
            {
                return NotFound();
            }

            

            return View(orders);
        }
       


    }
}