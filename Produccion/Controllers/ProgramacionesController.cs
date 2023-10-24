using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Producciones.Models;
using Producciones.Data;
using Microsoft.AspNetCore.Authorization;

namespace Producciones.Controllers
{
    [Authorize()]
    public class ProgramacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgramacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Programaciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Programacions.Include(p => p.Articulo).Include(p => p.Estado).Include(p => p.Proceso).Include(p => p.SupervisorNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Programaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Programacions == null)
            {
                return NotFound();
            }

            var programacion = await _context.Programacions
                .Include(p => p.Articulo)
                .Include(p => p.Estado)
                .Include(p => p.Proceso)
                .Include(p => p.SupervisorNavigation)
                .FirstOrDefaultAsync(m => m.IdProgramacion == id);
            if (programacion == null)
            {
                return NotFound();
            }

            return View(programacion);
        }

        // GET: Programaciones/Create
        public IActionResult Create()
        {
            ViewData["ArticuloId"] = new SelectList(_context.Articulos, "IdArticulo", "Nombre");
            ViewData["EstadoId"] = new SelectList(_context.Estados, "IdEstado", "Nombre");
            ViewData["ProcesoId"] = new SelectList(_context.Procesos, "IdProceso", "Nombre");
            ViewData["Supervisor"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Programaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProgramacion,OrdenProduccion,ProcesoId,ArticuloId,CantidadProgramada,EstadoId,Supervisor")] Programacion programacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticuloId"] = new SelectList(_context.Articulos, "IdArticulo", "Nombre", programacion.ArticuloId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "IdEstado", "Nombre", programacion.EstadoId);
            ViewData["ProcesoId"] = new SelectList(_context.Procesos, "IdProceso", "Nombre", programacion.ProcesoId);
            ViewData["Supervisor"] = new SelectList(_context.Usuarios, "Id", "Id", programacion.Supervisor);
            return View(programacion);
        }

        // GET: Programaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Programacions == null)
            {
                return NotFound();
            }

            var programacion = await _context.Programacions.FindAsync(id);
            if (programacion == null)
            {
                return NotFound();
            }
            ViewData["ArticuloId"] = new SelectList(_context.Articulos, "IdArticulo", "Nombre", programacion.ArticuloId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "IdEstado", "Nombre", programacion.EstadoId);
            ViewData["ProcesoId"] = new SelectList(_context.Procesos, "IdProceso", "Nombre", programacion.ProcesoId);
            ViewData["Supervisor"] = new SelectList(_context.Usuarios, "Id", "Id", programacion.Supervisor);
            return View(programacion);
        }

        // POST: Programaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProgramacion,OrdenProduccion,ProcesoId,ArticuloId,CantidadProgramada,EstadoId,Supervisor")] Programacion programacion)
        {
            if (id != programacion.IdProgramacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramacionExists(programacion.IdProgramacion))
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
            ViewData["ArticuloId"] = new SelectList(_context.Articulos, "IdArticulo", "Nombre", programacion.ArticuloId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "IdEstado", "Nombre", programacion.EstadoId);
            ViewData["ProcesoId"] = new SelectList(_context.Procesos, "IdProceso", "Nombre", programacion.ProcesoId);
            ViewData["Supervisor"] = new SelectList(_context.Usuarios, "Id", "Id", programacion.Supervisor);
            return View(programacion);
        }

        // GET: Programaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Programacions == null)
            {
                return NotFound();
            }

            var programacion = await _context.Programacions
                .Include(p => p.Articulo)
                .Include(p => p.Estado)
                .Include(p => p.Proceso)
                .Include(p => p.SupervisorNavigation)
                .FirstOrDefaultAsync(m => m.IdProgramacion == id);
            if (programacion == null)
            {
                return NotFound();
            }

            return View(programacion);
        }

        // POST: Programaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Programacions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Programacions'  is null.");
            }
            var programacion = await _context.Programacions.FindAsync(id);
            if (programacion != null)
            {
                _context.Programacions.Remove(programacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramacionExists(int id)
        {
          return (_context.Programacions?.Any(e => e.IdProgramacion == id)).GetValueOrDefault();
        }
    }
}
