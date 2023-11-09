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
using Microsoft.AspNetCore.Identity;

namespace Producciones.Controllers
{
    [Authorize]
    public class ProduccionesController : Controller
    {
        private readonly UserManager<Usuarios> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ProduccionesController(ApplicationDbContext context, UserManager<Usuarios> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Producciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Produccions.Include(p => p.Programacion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Producciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produccions == null)
            {
                return NotFound();
            }

            var produccion = await _context.Produccions
                .Include(p => p.Programacion)
                .FirstOrDefaultAsync(m => m.IdProduccion == id);
            if (produccion == null)
            {
                return NotFound();
            }

            return View(produccion);
        }

        // GET: Producciones/Create
        public IActionResult Create()
        {
            ViewData["ProgramacionId"] = new SelectList(_context.Programacions, "IdProgramacion", "Supervisor");
            ViewData["Responsable"] = new SelectList(_userManager.Users, "Id", "Apellido");
            return View();
        }

        // POST: Producciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduccion,ProgramacionId,CantidadProducida,Inicio,Fin,Responsable,Foto")] Produccion produccion)
        {
            var roles = await _roleManager.Roles.ToListAsync();
            if (ModelState.IsValid)
            {
                _context.Add(produccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProgramacionId"] = new SelectList(_context.Programacions, "IdProgramacion", "Supervisor", produccion.ProgramacionId);
            ViewData["Responsable"] = new SelectList(_userManager.Users, "Id", "Apellido");//deberia ser rol Responsable o User (No Supervisor o admin)
            return View(produccion);
        }

        // GET: Producciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produccions == null)
            {
                return NotFound();
            }

            var produccion = await _context.Produccions.FindAsync(id);
            if (produccion == null)
            {
                return NotFound();
            }
            ViewData["ProgramacionId"] = new SelectList(_context.Programacions, "IdProgramacion", "Supervisor", produccion.ProgramacionId);
            ViewData["Responsable"] = new SelectList(_userManager.Users, "Id", "Apellido");//deberia ser rol Responsable o User (No Supervisor o admin)
            return View(produccion);
        }

        // POST: Producciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduccion,ProgramacionId,CantidadProducida,Inicio,Fin,Responsable,Foto")] Produccion produccion)
        {
            if (id != produccion.IdProduccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduccionExists(produccion.IdProduccion))
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
            ViewData["ProgramacionId"] = new SelectList(_context.Programacions, "IdProgramacion", "Supervisor", produccion.ProgramacionId);
            ViewData["Responsable"] = new SelectList(_userManager.Users, "Id", "Apellido");//deberia ser rol Responsable o User (No Supervisor o admin)
            return View(produccion);
        }

        // GET: Producciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produccions == null)
            {
                return NotFound();
            }

            var produccion = await _context.Produccions
                .Include(p => p.Programacion)
                .FirstOrDefaultAsync(m => m.IdProduccion == id);
            if (produccion == null)
            {
                return NotFound();
            }

            return View(produccion);
        }

        // POST: Producciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produccions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Produccions'  is null.");
            }
            var produccion = await _context.Produccions.FindAsync(id);
            if (produccion != null)
            {
                _context.Produccions.Remove(produccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduccionExists(int id)
        {
            return (_context.Produccions?.Any(e => e.IdProduccion == id)).GetValueOrDefault();
        }
    }
}
