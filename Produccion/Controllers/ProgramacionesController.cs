﻿using System;
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
    [Authorize()]
    public class ProgramacionesController : Controller
    {
        private readonly UserManager<Usuarios> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public ProgramacionesController(ApplicationDbContext context, UserManager<Usuarios> userManager, RoleManager<IdentityRole> roleManager, SecondaryDbContext secondaryContext)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;            
        }

        // GET: Programaciones
        public async Task<IActionResult> Index()
        {
            var programaciones = await _context.Programacions
                .Include(p => p.Articulo)
                .Include(p => p.Proceso)
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
                .Include(p => p.Articulo)
                .Include(p => p.Proceso)
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
            ViewData["Articulo"] = new SelectList(_context.Articulos
                .Select(a => new
                {
                    Id = a.art_CodGen,
                    Nombre = $"{a.art_CodGen} - {a.art_DescGen}"
                }), "Id", "Nombre");

            ViewData["Estado"] = new SelectList(new[]
            {
                new { Value = "En proceso", Text = "En proceso" },
                new { Value = "Pendiente", Text = "Pendiente" },
                new { Value = "Finalizado", Text = "Finalizado" }
            }, "Value", "Text");
            ViewData["ProcesoId"] = new SelectList(_context.Proceso, "IdProceso", "Nombre");
            ViewData["Supervisor"] = new SelectList(_userManager.Users, "Id", "Apellido");//deberia ser rol Supervidor o Admin (No Responsable o User)
            return View();
        }

        // POST: Programaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProgramacion,OrdenProduccion,ProcesoId,art_CodGen,CantidadProgramada,EstadoId,Supervisor")] Programacion programacion)
        {
            programacion.Supervisor = _userManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                _context.Add(programacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticuloId"] = new SelectList(_context.Articulos, "IdArticulo", "art_DescGen", programacion.Articulo);
            ViewData["Estado"] = new SelectList(new[]
            {
                new { Value = "En proceso", Text = "En proceso" },
                new { Value = "Pendiente", Text = "Pendiente" },
                new { Value = "Finalizado", Text = "Finalizado" }
            }, "Value", "Text");
            ViewData["ProcesoId"] = new SelectList(_context.Proceso, "IdProceso", "Nombre", programacion.ProcesoId);
            ViewData["Supervisor"] = new SelectList(_userManager.Users, "Id", "Apellido");//deberia ser rol Supervidor o Admin (No Responsable o User)
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
            ViewData["Articulo"] = new SelectList(_context.Articulos, "art_CodGen", "art_DescGen", programacion.Articulo);
            ViewData["Estado"] = new SelectList(new[]
            {
                new { Value = "En proceso", Text = "En proceso" },
                new { Value = "Pendiente", Text = "Pendiente" },
                new { Value = "Finalizado", Text = "Finalizado" }
            }, "Value", "Text");
            ViewData["ProcesoId"] = new SelectList(_context.Proceso, "IdProceso", "Nombre", programacion.ProcesoId);
            ViewData["Supervisor"] = new SelectList(_userManager.Users, "Id", "Apellido");//deberia ser rol Supervidor o Admin (No Responsable o User)
            return View(programacion);
        }

        // POST: Programaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProgramacion,OrdenProduccion,ProcesoId,art_CodGen,CantidadProgramada,Estado,Supervisor")] Programacion programacion)
        {
            programacion.Supervisor = _userManager.GetUserId(User);

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
            ViewData["ArticuloId"] = new SelectList(_context.Articulos, "IdArticulo", "art_DescGen", programacion.Articulo);
            ViewData["Estado"] = new SelectList(new[]
            {
                new { Value = "En proceso", Text = "En proceso" },
                new { Value = "Pendiente", Text = "Pendiente" },
                new { Value = "Finalizado", Text = "Finalizado" }
            }, "Value", "Text");
            ViewData["ProcesoId"] = new SelectList(_context.Proceso, "IdProceso", "Nombre", programacion.ProcesoId);
            ViewData["Supervisor"] = new SelectList(_userManager.Users, "Id", "Apellido");//deberia ser rol Supervidor o Admin (No Responsable o User)
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
