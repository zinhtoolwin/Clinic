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
    public class DrugSellsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DrugSellsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DrugSells
        public async Task<IActionResult> Index()
        {
            var drugList = await _context.Drugs.Include(s => s.DrugSellDrugs).ThenInclude(sc => sc.Drug).ToListAsync();
            return View(await _context.DrugSells.ToListAsync());
        }

        // GET: DrugSells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugSell = await _context.DrugSells
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drugSell == null)
            {
                return NotFound();
            }

            return View(drugSell);
        }

        // GET: DrugSells/Create
        public IActionResult Create()
        {

            var drugs = _context.Drugs.ToList();

            List<DrugSellDrugViewModel> scList = new List<DrugSellDrugViewModel>();

           List<DrugViewModel> drgList = new List<DrugViewModel>();

            foreach (Drug c in drugs)
            {
                scList.Add(new DrugSellDrugViewModel() { DrugIdd = c.DrugId, DrugName = c.Name , Price=c.Price   });
            }
            foreach(Drug c in drugs)
            {
                drgList.Add(new DrugViewModel() { DrugIdd = c.DrugId, DrugName = c.Name });
            }
            var std = new DrugSellViewModel()
            {
                DrugSellList = scList,
                DrugItemList = drgList

                //new List<DrugViewModel>()
            };
            ViewData["DrugPrice"] = new SelectList(_context.Drugs, "Id", "Price");
            return View(std);
            
        }

        // POST: DrugSells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DrugSellViewModel drug)
        {
            if (ModelState.IsValid)
            {
                /*IList<DrugSellViewModel> newDrugsSells = new List<DrugSellViewModel>()
                {
                    new DrugSellViewModel(){PatientName=drug.PatientName, Qty=drug.Qty , Total_Price=drug.Total_Price ,Total_Amt=drug.Total_Amt}
                };
                IList<DrugViewModel> newDrugvm = new List<DrugViewModel>()
                {
                   
                };

                */

                var std = new DrugSell()
                {
                    PatientName = drug.PatientName,
                    Total_Price = drug.Total_Amt,
                    
                    
                };
                _context.DrugSells.Add(std);

                await _context.SaveChangesAsync();
                List<DrugSellDrug> drugsellList = new List<DrugSellDrug>();

               foreach(DrugViewModel dm in drug.DrugItemList)
                {
                    drugsellList.Add(new DrugSellDrug(){
                       
                        DrugsellId = std.Id ,
                        DrugId = dm.DrugIdd
                    });
                   
                }
                _context.AddRange(drugsellList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

                //foreach (DrugSellDrugViewModel cv in drug.DrugSellList)
                //{
                //    if (cv.IsChecked == true)
                //        drugsellList.Add(new DrugSellDrug() { DrugsellId = std.Id, DrugId = cv.DrugId });
                //}

                // _context.DrugSellDrugs.AddRange(drugsellList);
                //await _context.SaveChangesAsync();
              

               
            }
            return View(drug);
        }

        // GET: DrugSells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugSell = await _context.DrugSells.FindAsync(id);
            if (drugSell == null)
            {
                return NotFound();
            }
            return View(drugSell);
        }

        // POST: DrugSells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Qty,Total_Price")] DrugSell drugSell)
        {
            if (id != drugSell.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drugSell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrugSellExists(drugSell.Id))
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
            return View(drugSell);
        }

        // GET: DrugSells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugSell = await _context.DrugSells
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drugSell == null)
            {
                return NotFound();
            }

            return View(drugSell);
        }

        // POST: DrugSells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drugSell = await _context.DrugSells.FindAsync(id);
            _context.DrugSells.Remove(drugSell);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrugSellExists(int id)
        {
            return _context.DrugSells.Any(e => e.Id == id);
        }
    }
}
