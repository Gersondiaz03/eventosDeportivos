using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCancha.Models;

namespace eventosDeportivos.Controllers
{
    public class CanchaController : Controller
    {
        private readonly eventosDeportivosContext _context;

        public CanchaController(eventosDeportivosContext context)
        {
            _context = context;
        }

        // GET: Cancha
        public async Task<IActionResult> Index()
        {
            var eventosDeportivosContext = _context.Cancha.Include(c => c.escenario);
            return View(await eventosDeportivosContext.ToListAsync());
        }

        // GET: Cancha/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cancha == null)
            {
                return NotFound();
            }

            var cancha = await _context.Cancha
                .Include(c => c.escenario)
                .FirstOrDefaultAsync(m => m.canchaId == id);
            if (cancha == null)
            {
                return NotFound();
            }

            return View(cancha);
        }

        // GET: Cancha/Create
        public IActionResult Create()
        {
            ViewData["escenarioId"] = new SelectList(_context.Escenario, "escenarioId", "direccion");
            return View();
        }

        // POST: Cancha/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("canchaId,nombre,disciplina,cantidadEspectadores,medidas,escenarioId")] Cancha cancha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cancha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["escenarioId"] = new SelectList(_context.Escenario, "escenarioId", "direccion", cancha.escenarioId);
            return View(cancha);
        }

        // GET: Cancha/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cancha == null)
            {
                return NotFound();
            }

            var cancha = await _context.Cancha.FindAsync(id);
            if (cancha == null)
            {
                return NotFound();
            }
            ViewData["escenarioId"] = new SelectList(_context.Escenario, "escenarioId", "direccion", cancha.escenarioId);
            return View(cancha);
        }

        // POST: Cancha/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("canchaId,nombre,disciplina,cantidadEspectadores,medidas,escenarioId")] Cancha cancha)
        {
            if (id != cancha.canchaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cancha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CanchaExists(cancha.canchaId))
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
            ViewData["escenarioId"] = new SelectList(_context.Escenario, "escenarioId", "direccion", cancha.escenarioId);
            return View(cancha);
        }

        // GET: Cancha/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cancha == null)
            {
                return NotFound();
            }

            var cancha = await _context.Cancha
                .Include(c => c.escenario)
                .FirstOrDefaultAsync(m => m.canchaId == id);
            if (cancha == null)
            {
                return NotFound();
            }

            return View(cancha);
        }

        // POST: Cancha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cancha == null)
            {
                return Problem("Entity set 'eventosDeportivosContext.Cancha'  is null.");
            }
            var cancha = await _context.Cancha.FindAsync(id);
            if (cancha != null)
            {
                _context.Cancha.Remove(cancha);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CanchaExists(int id)
        {
          return (_context.Cancha?.Any(e => e.canchaId == id)).GetValueOrDefault();
        }
    }
}
