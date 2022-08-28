using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMunicipio.Models;

namespace eventosDeportivos.Controllers
{
    public class MunicipioController : Controller
    {
        private readonly eventosDeportivosContext _context;

        public MunicipioController(eventosDeportivosContext context)
        {
            _context = context;
        }

        // GET: Municipio
        public async Task<IActionResult> Index()
        {
              return _context.Municipio != null ? 
                          View(await _context.Municipio.ToListAsync()) :
                          Problem("Entity set 'eventosDeportivosContext.Municipio'  is null.");
        }

        // GET: Municipio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Municipio == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipio
                .FirstOrDefaultAsync(m => m.municipioId == id);
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // GET: Municipio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Municipio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("municipioId,nombre")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(municipio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(municipio);
        }

        // GET: Municipio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Municipio == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipio.FindAsync(id);
            if (municipio == null)
            {
                return NotFound();
            }
            return View(municipio);
        }

        // POST: Municipio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("municipioId,nombre")] Municipio municipio)
        {
            if (id != municipio.municipioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(municipio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MunicipioExists(municipio.municipioId))
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
            return View(municipio);
        }

        // GET: Municipio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Municipio == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipio
                .FirstOrDefaultAsync(m => m.municipioId == id);
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // POST: Municipio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Municipio == null)
            {
                return Problem("Entity set 'eventosDeportivosContext.Municipio'  is null.");
            }
            var municipio = await _context.Municipio.FindAsync(id);
            if (municipio != null)
            {
                _context.Municipio.Remove(municipio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MunicipioExists(int id)
        {
          return (_context.Municipio?.Any(e => e.municipioId == id)).GetValueOrDefault();
        }
    }
}
