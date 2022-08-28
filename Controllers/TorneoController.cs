using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTorneo.Models;

namespace eventosDeportivos.Controllers
{
    public class TorneoController : Controller
    {
        private readonly eventosDeportivosContext _context;

        public TorneoController(eventosDeportivosContext context)
        {
            _context = context;
        }

        // GET: Torneo
        public async Task<IActionResult> Index()
        {
            var eventosDeportivosContext = _context.Torneo.Include(t => t.municipio);
            return View(await eventosDeportivosContext.ToListAsync());
        }

        // GET: Torneo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Torneo == null)
            {
                return NotFound();
            }

            var torneo = await _context.Torneo
                .Include(t => t.municipio)
                .FirstOrDefaultAsync(m => m.torneoId == id);
            if (torneo == null)
            {
                return NotFound();
            }

            return View(torneo);
        }

        // GET: Torneo/Create
        public IActionResult Create()
        {
            ViewData["municipioId"] = new SelectList(_context.Municipio, "municipioId", "nombre");
            return View();
        }

        // POST: Torneo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("torneoId,nombre,categoria,fechaInicio,fechaFinal,municipioId")] Torneo torneo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(torneo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["municipioId"] = new SelectList(_context.Municipio, "municipioId", "nombre", torneo.municipioId);
            return View(torneo);
        }

        // GET: Torneo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Torneo == null)
            {
                return NotFound();
            }

            var torneo = await _context.Torneo.FindAsync(id);
            if (torneo == null)
            {
                return NotFound();
            }
            ViewData["municipioId"] = new SelectList(_context.Municipio, "municipioId", "nombre", torneo.municipioId);
            return View(torneo);
        }

        // POST: Torneo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("torneoId,nombre,categoria,fechaInicio,fechaFinal,municipioId")] Torneo torneo)
        {
            if (id != torneo.torneoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(torneo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TorneoExists(torneo.torneoId))
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
            ViewData["municipioId"] = new SelectList(_context.Municipio, "municipioId", "nombre", torneo.municipioId);
            return View(torneo);
        }

        // GET: Torneo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Torneo == null)
            {
                return NotFound();
            }

            var torneo = await _context.Torneo
                .Include(t => t.municipio)
                .FirstOrDefaultAsync(m => m.torneoId == id);
            if (torneo == null)
            {
                return NotFound();
            }

            return View(torneo);
        }

        // POST: Torneo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Torneo == null)
            {
                return Problem("Entity set 'eventosDeportivosContext.Torneo'  is null.");
            }
            var torneo = await _context.Torneo.FindAsync(id);
            if (torneo != null)
            {
                _context.Torneo.Remove(torneo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TorneoExists(int id)
        {
          return (_context.Torneo?.Any(e => e.torneoId == id)).GetValueOrDefault();
        }
    }
}
