using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcColegioArbitral.Models;

namespace eventosDeportivos.Controllers
{
    public class colegioArbitralController : Controller
    {
        private readonly eventosDeportivosContext _context;

        public colegioArbitralController(eventosDeportivosContext context)
        {
            _context = context;
        }

        // GET: colegioArbitral
        public async Task<IActionResult> Index()
        {
              return _context.colegioArbitral != null ? 
                          View(await _context.colegioArbitral.ToListAsync()) :
                          Problem("Entity set 'eventosDeportivosContext.colegioArbitral'  is null.");
        }

        // GET: colegioArbitral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.colegioArbitral == null)
            {
                return NotFound();
            }

            var colegioArbitral = await _context.colegioArbitral
                .FirstOrDefaultAsync(m => m.colegioArbitralId == id);
            if (colegioArbitral == null)
            {
                return NotFound();
            }

            return View(colegioArbitral);
        }

        // GET: colegioArbitral/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: colegioArbitral/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("colegioArbitralId,NIT,nombre,resolucion,direccion,telefono,correo")] colegioArbitral colegioArbitral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colegioArbitral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colegioArbitral);
        }

        // GET: colegioArbitral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.colegioArbitral == null)
            {
                return NotFound();
            }

            var colegioArbitral = await _context.colegioArbitral.FindAsync(id);
            if (colegioArbitral == null)
            {
                return NotFound();
            }
            return View(colegioArbitral);
        }

        // POST: colegioArbitral/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("colegioArbitralId,NIT,nombre,resolucion,direccion,telefono,correo")] colegioArbitral colegioArbitral)
        {
            if (id != colegioArbitral.colegioArbitralId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colegioArbitral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!colegioArbitralExists(colegioArbitral.colegioArbitralId))
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
            return View(colegioArbitral);
        }

        // GET: colegioArbitral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.colegioArbitral == null)
            {
                return NotFound();
            }

            var colegioArbitral = await _context.colegioArbitral
                .FirstOrDefaultAsync(m => m.colegioArbitralId == id);
            if (colegioArbitral == null)
            {
                return NotFound();
            }

            return View(colegioArbitral);
        }

        // POST: colegioArbitral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.colegioArbitral == null)
            {
                return Problem("Entity set 'eventosDeportivosContext.colegioArbitral'  is null.");
            }
            var colegioArbitral = await _context.colegioArbitral.FindAsync(id);
            if (colegioArbitral != null)
            {
                _context.colegioArbitral.Remove(colegioArbitral);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool colegioArbitralExists(int id)
        {
          return (_context.colegioArbitral?.Any(e => e.colegioArbitralId == id)).GetValueOrDefault();
        }
    }
}
