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
using System.Security.Claims;

namespace Producciones.Controllers
{
    public class ProgramacionesController : Controller
    {
        private readonly UserManager<Usuarios> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ProduccionContext _context;

        public ProgramacionesController(ProduccionContext context, UserManager<Usuarios> userManager, RoleManager<IdentityRole> roleManager, SecondaryDbContext secondaryContext)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        // GET: Programaciones
        public async Task<IActionResult> Index()
        {
            var programaciones = await _context.Programacions
                .Include(p => p.ArticuloCodNavigation)
                .Include(p => p.Proceso)
                .Include(p => p.Usuario)
                .ToListAsync();

            return View(programaciones);
        }

        // GET: Programaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Programacions == null)
            {
                return NotFound();
            }

            var programacion = await _context.Programacions
                .Include(p => p.ArticuloCodNavigation)
                .Include(p => p.Proceso)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.IdProgramacion == id);
            if (programacion == null)
            {
                return NotFound();
            }

            return View(programacion);
        }
        [Authorize(Roles = "Supervisor, Admin")]
        // GET: Programaciones/Create
        public IActionResult Create()
        {
            ViewData["Articulo"] = new SelectList(_context.Articulos
                .OrderBy(a => a.ArtDescGen) // Ordenar por art_CodDesc = "Descripcion"
                .Select(a => new
                {
                    Id = a.ArtCodGen,
                    Nombre = $"{a.ArtDescGen} (Cod. {a.ArtCodGen})"
                }), "Id", "Nombre");
            
            ViewData["Proceso"] = new SelectList(_context.Procesos, "IdProceso", "Nombre");
            return View();
        }

        // POST: Programaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Supervisor, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProgramacion,OrdenProduccion,ProcesoId,ArticuloCod,CantidadProgramada,Estado,UsuarioId")] Programacion programacion)
        {
            programacion.UsuarioId = _userManager.GetUserId(User);
            ViewData["Articulo"] = new SelectList(_context.Articulos
                .OrderBy(a => a.ArtDescGen)
                .Select(a => new
                {
                    Id = a.ArtCodGen,
                    Nombre = $"{a.ArtDescGen} (Cod. {a.ArtCodGen})"
                }), "Id", "Nombre", programacion.ArticuloCod);

            ViewData["Proceso"] = new SelectList(_context.Procesos, "IdProceso", "Nombre", programacion.ProcesoId);

            if (ModelState.IsValid)
            {
                programacion.Estado = "Pendiente";
                _context.Add(programacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(programacion);
        }
        [Authorize(Roles = "Supervisor, Admin")]
        // GET: Programaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Programacions == null)
            {
                return NotFound();
            }

            var programacion = await _context.Programacions
                .FindAsync(id);
            if (programacion == null)
            {
                return NotFound();
            }
            
            ViewData["Articulo"] = new SelectList(_context.Articulos
                 .OrderBy(a => a.ArtDescGen) // Ordenar por art_CodDesc = "Descripcion"
                 .Select(a => new
                 {
                     Id = a.ArtCodGen,
                     Nombre = $"{a.ArtDescGen} (Cod. {a.ArtCodGen})"
                 }), "Id", "Nombre", programacion.ArticuloCod);
            ViewData["Estado"] = new SelectList(new[]
            {
                new { Value = "Pendiente", Text = "Pendiente" },
                new { Value = "En proceso", Text = "En proceso" },                
                new { Value = "Finalizado", Text = "Finalizado" }
            }, "Value", "Text");
                       
            ViewData["Proceso"] = new SelectList(_context.Procesos, "IdProceso", "Nombre", programacion.ProcesoId);
            
            return View(programacion);
        }
        [Authorize(Roles = "Supervisor, Admin")]
        // POST: Programaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProgramacion,OrdenProduccion,ProcesoId,ArticuloCod,CantidadProgramada,Estado,Supervisor")] Programacion programacion)
        {
            programacion.UsuarioId = _userManager.GetUserId(User);

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
            
            ViewData["Articulo"] = new SelectList(_context.Articulos
                 .OrderBy(a => a.ArtDescGen) // Ordenar por art_CodDesc = "Descripcion"
                 .Select(a => new
                 {
                     Id = a.ArtCodGen,
                     Nombre = $"{a.ArtDescGen} (Cod. {a.ArtCodGen})"
                 }), "Id", "Nombre", programacion.ArticuloCod);
            ViewData["Estado"] = new SelectList(new[]
            {
                new { Value = "En proceso", Text = "En proceso" },
                new { Value = "Pendiente", Text = "Pendiente" },
                new { Value = "Finalizado", Text = "Finalizado" }
            }, "Value", "Text");

            ViewData["ProcesoId"] = new SelectList(_context.Procesos, "IdProceso", "Nombre", programacion.ProcesoId);
            //ViewData["Supervisor"] = new SelectList(_userManager.Users, "Id", "Apellido");//deberia ser rol Supervidor o Admin (No Responsable o User)
            return View(programacion);
        }
        [Authorize(Roles = "Supervisor, Admin")]
        // GET: Programaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Programacions == null)
            {
                return NotFound();
            }

            var programacion = await _context.Programacions
                .Include(p => p.ArticuloCodNavigation)                
                .Include(p => p.Proceso)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.IdProgramacion == id);
            if (programacion == null)
            {
                return NotFound();
            }

            return View(programacion);
        }
        [Authorize(Roles = "Supervisor, Admin")]
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
