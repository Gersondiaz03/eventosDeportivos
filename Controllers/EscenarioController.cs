using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcEscenario.Models;

namespace eventosDeportivos.Controllers
{
    public class EscenarioController : Controller
    {
        private readonly eventosDeportivosContext _context;

        public EscenarioController(eventosDeportivosContext context)
        {
            _context = context;
        }

        // GET: Escenario
        public async Task<IActionResult> Index()
        {
            var eventosDeportivosContext = _context.Escenario.Include(e => e.torneo);
            return View(await eventosDeportivosContext.ToListAsync());
        }

        // GET: Escenario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Escenario == null)
            {
                return NotFound();
            }

            var escenario = await _context.Escenario
                .Include(e => e.torneo)
                .FirstOrDefaultAsync(m => m.escenarioId == id);
            if (escenario == null)
            {
                return NotFound();
            }

            return View(escenario);
        }

        // GET: Escenario/Create
        public IActionResult Create()
        {
            ViewData["torneoId"] = new SelectList(_context.Torneo, "torneoId", "categoria");
            return View();
        }

        // POST: Escenario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("escenarioId,nombre,direccion,telefono,torneoId")] Escenario escenario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escenario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["torneoId"] = new SelectList(_context.Torneo, "torneoId", "categoria", escenario.torneoId);
            return View(escenario);
        }

        // GET: Escenario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Escenario == null)
            {
                return NotFound();
            }

            var escenario = await _context.Escenario.FindAsync(id);
            if (escenario == null)
            {
                return NotFound();
            }
            ViewData["torneoId"] = new SelectList(_context.Torneo, "torneoId", "categoria", escenario.torneoId);
            return View(escenario);
        }

        // POST: Escenario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("escenarioId,nombre,direccion,telefono,torneoId")] Escenario escenario)
        {
            if (id != escenario.escenarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escenario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscenarioExists(escenario.escenarioId))
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
            ViewData["torneoId"] = new SelectList(_context.Torneo, "torneoId", "categoria", escenario.torneoId);
            return View(escenario);
        }

        // GET: Escenario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Escenario == null)
            {
                return NotFound();
            }

            var escenario = await _context.Escenario
                .Include(e => e.torneo)
                .FirstOrDefaultAsync(m => m.escenarioId == id);
            if (escenario == null)
            {
                return NotFound();
            }

            return View(escenario);
        }

        // POST: Escenario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Escenario == null)
            {
                return Problem("Entity set 'eventosDeportivosContext.Escenario'  is null.");
            }
            var escenario = await _context.Escenario.FindAsync(id);
            if (escenario != null)
            {
                _context.Escenario.Remove(escenario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscenarioExists(int id)
        {
          return (_context.Escenario?.Any(e => e.escenarioId == id)).GetValueOrDefault();
        }
    }
}
