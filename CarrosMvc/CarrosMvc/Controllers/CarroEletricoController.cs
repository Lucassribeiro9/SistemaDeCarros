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
    public class CarroEletricoController : Controller
    {
        private readonly CarroDbContext _context;

        public CarroEletricoController(CarroDbContext context)
        {
            _context = context;
        }

        // GET: CarroEletrico
        public async Task<IActionResult> Index()
        {
              return _context.CarrosEletricos != null ? 
                          View(await _context.CarrosEletricos.ToListAsync()) :
                          Problem("Entity set 'CarroDbContext.CarrosEletricos'  is null.");
        }

        // GET: CarroEletrico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarrosEletricos == null)
            {
                return NotFound();
            }

            var carroEletrico = await _context.CarrosEletricos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carroEletrico == null)
            {
                return NotFound();
            }

            return View(carroEletrico);
        }

        // GET: CarroEletrico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarroEletrico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Potencia,DuracaoBateria,Id,NumeroChassi,NumeroMotor,CustoProducao")] CarroEletrico carroEletrico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carroEletrico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carroEletrico);
        }

        // GET: CarroEletrico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarrosEletricos == null)
            {
                return NotFound();
            }

            var carroEletrico = await _context.CarrosEletricos.FindAsync(id);
            if (carroEletrico == null)
            {
                return NotFound();
            }
            return View(carroEletrico);
        }

        // POST: CarroEletrico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Potencia,DuracaoBateria,Id,NumeroChassi,NumeroMotor,CustoProducao")] CarroEletrico carroEletrico)
        {
            if (id != carroEletrico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carroEletrico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroEletricoExists(carroEletrico.Id))
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
            return View(carroEletrico);
        }

        // GET: CarroEletrico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarrosEletricos == null)
            {
                return NotFound();
            }

            var carroEletrico = await _context.CarrosEletricos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carroEletrico == null)
            {
                return NotFound();
            }

            return View(carroEletrico);
        }

        // POST: CarroEletrico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarrosEletricos == null)
            {
                return Problem("Entity set 'CarroDbContext.CarrosEletricos'  is null.");
            }
            var carroEletrico = await _context.CarrosEletricos.FindAsync(id);
            if (carroEletrico != null)
            {
                _context.CarrosEletricos.Remove(carroEletrico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroEletricoExists(int id)
        {
          return (_context.CarrosEletricos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
