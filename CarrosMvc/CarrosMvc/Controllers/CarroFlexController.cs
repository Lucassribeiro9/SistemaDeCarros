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
    public class CarroFlexController : Controller
    {
        private readonly CarroDbContext _context;

        public CarroFlexController(CarroDbContext context)
        {
            _context = context;
        }

        // GET: CarroFlex
        public async Task<IActionResult> Index()
        {
              return _context.CarrosFlex != null ? 
                          View(await _context.CarrosFlex.ToListAsync()) :
                          Problem("Entity set 'CarroDbContext.CarrosFlex'  is null.");
        }

        // GET: CarroFlex/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarrosFlex == null)
            {
                return NotFound();
            }

            var carroFlex = await _context.CarrosFlex
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carroFlex == null)
            {
                return NotFound();
            }

            return View(carroFlex);
        }

        // GET: CarroFlex/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarroFlex/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroPortas,Cilindrada,Id,NumeroChassi,NumeroMotor,CustoProducao")] CarroFlex carroFlex)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carroFlex);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carroFlex);
        }

        // GET: CarroFlex/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarrosFlex == null)
            {
                return NotFound();
            }

            var carroFlex = await _context.CarrosFlex.FindAsync(id);
            if (carroFlex == null)
            {
                return NotFound();
            }
            return View(carroFlex);
        }

        // POST: CarroFlex/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroPortas,Cilindrada,Id,NumeroChassi,NumeroMotor,CustoProducao")] CarroFlex carroFlex)
        {
            if (id != carroFlex.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carroFlex);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroFlexExists(carroFlex.Id))
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
            return View(carroFlex);
        }

        // GET: CarroFlex/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarrosFlex == null)
            {
                return NotFound();
            }

            var carroFlex = await _context.CarrosFlex
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carroFlex == null)
            {
                return NotFound();
            }

            return View(carroFlex);
        }

        // POST: CarroFlex/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarrosFlex == null)
            {
                return Problem("Entity set 'CarroDbContext.CarrosFlex'  is null.");
            }
            var carroFlex = await _context.CarrosFlex.FindAsync(id);
            if (carroFlex != null)
            {
                _context.CarrosFlex.Remove(carroFlex);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroFlexExists(int id)
        {
          return (_context.CarrosFlex?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
