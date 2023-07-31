using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarrosMvc.Models;

namespace CarrosMvc.Controllers
{
    public class CarroDieselController : Controller
    {
        private readonly CarroDbContext _context;

        public CarroDieselController(CarroDbContext context)
        {
            _context = context;
        }

        // GET: CarroDiesel
        public async Task<IActionResult> Index()
        {
              return _context.CarrosDiesel != null ? 
                          View(await _context.CarrosDiesel.ToListAsync()) :
                          Problem("Entity set 'CarroDbContext.CarrosDiesel'  is null.");
        }

        // GET: CarroDiesel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarrosDiesel == null)
            {
                return NotFound();
            }

            var carroDiesel = await _context.CarrosDiesel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carroDiesel == null)
            {
                return NotFound();
            }

            return View(carroDiesel);
        }

        // GET: CarroDiesel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarroDiesel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CapacidadeCarga,VolumeCacamba,Id,NumeroChassi,NumeroMotor,CustoProducao")] CarroDiesel carroDiesel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carroDiesel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carroDiesel);
        }

        // GET: CarroDiesel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarrosDiesel == null)
            {
                return NotFound();
            }

            var carroDiesel = await _context.CarrosDiesel.FindAsync(id);
            if (carroDiesel == null)
            {
                return NotFound();
            }
            return View(carroDiesel);
        }

        // POST: CarroDiesel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CapacidadeCarga,VolumeCacamba,Id,NumeroChassi,NumeroMotor,CustoProducao")] CarroDiesel carroDiesel)
        {
            if (id != carroDiesel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carroDiesel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroDieselExists(carroDiesel.Id))
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
            return View(carroDiesel);
        }

        // GET: CarroDiesel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarrosDiesel == null)
            {
                return NotFound();
            }

            var carroDiesel = await _context.CarrosDiesel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carroDiesel == null)
            {
                return NotFound();
            }

            return View(carroDiesel);
        }

        // POST: CarroDiesel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarrosDiesel == null)
            {
                return Problem("Entity set 'CarroDbContext.CarrosDiesel'  is null.");
            }
            var carroDiesel = await _context.CarrosDiesel.FindAsync(id);
            if (carroDiesel != null)
            {
                _context.CarrosDiesel.Remove(carroDiesel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroDieselExists(int id)
        {
          return (_context.CarrosDiesel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
