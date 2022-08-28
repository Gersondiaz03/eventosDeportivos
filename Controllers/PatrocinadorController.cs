using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcPatrocinador.Models;

namespace eventosDeportivos.Controllers
{
    public class PatrocinadorController : Controller
    {
        private readonly eventosDeportivosContext _context;

        public PatrocinadorController(eventosDeportivosContext context)
        {
            _context = context;
        }

        // GET: Patrocinador
        public async Task<IActionResult> Index()
        {
              return _context.Patrocinador != null ? 
                          View(await _context.Patrocinador.ToListAsync()) :
                          Problem("Entity set 'eventosDeportivosContext.Patrocinador'  is null.");
        }

        // GET: Patrocinador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Patrocinador == null)
            {
                return NotFound();
            }

            var patrocinador = await _context.Patrocinador
                .FirstOrDefaultAsync(m => m.documento == id);
            if (patrocinador == null)
            {
                return NotFound();
            }

            return View(patrocinador);
        }

        // GET: Patrocinador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patrocinador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("direccion,tipoPersona,documento,nombre,apellido,genero,telefono,correo")] Patrocinador patrocinador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patrocinador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patrocinador);
        }

        // GET: Patrocinador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Patrocinador == null)
            {
                return NotFound();
            }

            var patrocinador = await _context.Patrocinador.FindAsync(id);
            if (patrocinador == null)
            {
                return NotFound();
            }
            return View(patrocinador);
        }

        // POST: Patrocinador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("direccion,tipoPersona,documento,nombre,apellido,genero,telefono,correo")] Patrocinador patrocinador)
        {
            if (id != patrocinador.documento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patrocinador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatrocinadorExists(patrocinador.documento))
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
            return View(patrocinador);
        }

        // GET: Patrocinador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Patrocinador == null)
            {
                return NotFound();
            }

            var patrocinador = await _context.Patrocinador
                .FirstOrDefaultAsync(m => m.documento == id);
            if (patrocinador == null)
            {
                return NotFound();
            }

            return View(patrocinador);
        }

        // POST: Patrocinador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Patrocinador == null)
            {
                return Problem("Entity set 'eventosDeportivosContext.Patrocinador'  is null.");
            }
            var patrocinador = await _context.Patrocinador.FindAsync(id);
            if (patrocinador != null)
            {
                _context.Patrocinador.Remove(patrocinador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatrocinadorExists(int id)
        {
          return (_context.Patrocinador?.Any(e => e.documento == id)).GetValueOrDefault();
        }
    }
}
