using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcDeportista.Models;

namespace eventosDeportivos.Controllers
{
    public class DeportistaController : Controller
    {
        private readonly eventosDeportivosContext _context;

        public DeportistaController(eventosDeportivosContext context)
        {
            _context = context;
        }

        // GET: Deportista
        public async Task<IActionResult> Index()
        {
            var eventosDeportivosContext = _context.Deportista.Include(d => d.equipo);
            return View(await eventosDeportivosContext.ToListAsync());
        }

        // GET: Deportista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Deportista == null)
            {
                return NotFound();
            }

            var deportista = await _context.Deportista
                .Include(d => d.equipo)
                .FirstOrDefaultAsync(m => m.documento == id);
            if (deportista == null)
            {
                return NotFound();
            }

            return View(deportista);
        }

        // GET: Deportista/Create
        public IActionResult Create()
        {
            ViewData["equipoId"] = new SelectList(_context.Equipo, "equipoId", "deporte");
            return View();
        }

        // POST: Deportista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("direccion,RH,EPS,fechaNacimiento,equipoId,documento,nombre,apellido,genero,telefono,correo")] Deportista deportista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deportista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["equipoId"] = new SelectList(_context.Equipo, "equipoId", "deporte", deportista.equipoId);
            return View(deportista);
        }

        // GET: Deportista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Deportista == null)
            {
                return NotFound();
            }

            var deportista = await _context.Deportista.FindAsync(id);
            if (deportista == null)
            {
                return NotFound();
            }
            ViewData["equipoId"] = new SelectList(_context.Equipo, "equipoId", "deporte", deportista.equipoId);
            return View(deportista);
        }

        // POST: Deportista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("direccion,RH,EPS,fechaNacimiento,equipoId,documento,nombre,apellido,genero,telefono,correo")] Deportista deportista)
        {
            if (id != deportista.documento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deportista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeportistaExists(deportista.documento))
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
            ViewData["equipoId"] = new SelectList(_context.Equipo, "equipoId", "deporte", deportista.equipoId);
            return View(deportista);
        }

        // GET: Deportista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Deportista == null)
            {
                return NotFound();
            }

            var deportista = await _context.Deportista
                .Include(d => d.equipo)
                .FirstOrDefaultAsync(m => m.documento == id);
            if (deportista == null)
            {
                return NotFound();
            }

            return View(deportista);
        }

        // POST: Deportista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Deportista == null)
            {
                return Problem("Entity set 'eventosDeportivosContext.Deportista'  is null.");
            }
            var deportista = await _context.Deportista.FindAsync(id);
            if (deportista != null)
            {
                _context.Deportista.Remove(deportista);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeportistaExists(int id)
        {
          return (_context.Deportista?.Any(e => e.documento == id)).GetValueOrDefault();
        }
    }
}
