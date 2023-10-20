using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Producciones.Models;
using Producciones.Data;

namespace Producciones.Controllers
{
    public class SectoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SectoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sectores
        public async Task<IActionResult> Index()
        {
              return _context.Sectores != null ? 
                          View(await _context.Sectores.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Sectores'  is null.");
        }

        // GET: Sectores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sectores == null)
            {
                return NotFound();
            }

            var sectores = await _context.Sectores
                .FirstOrDefaultAsync(m => m.IdSector == id);
            if (sectores == null)
            {
                return NotFound();
            }

            return View(sectores);
        }

        // GET: Sectores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sectores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSector,Descripcion")] Sectores sectores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sectores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sectores);
        }

        // GET: Sectores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sectores == null)
            {
                return NotFound();
            }

            var sectores = await _context.Sectores.FindAsync(id);
            if (sectores == null)
            {
                return NotFound();
            }
            return View(sectores);
        }

        // POST: Sectores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSector,Descripcion")] Sectores sectores)
        {
            if (id != sectores.IdSector)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sectores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectoresExists(sectores.IdSector))
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
            return View(sectores);
        }

        // GET: Sectores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sectores == null)
            {
                return NotFound();
            }

            var sectores = await _context.Sectores
                .FirstOrDefaultAsync(m => m.IdSector == id);
            if (sectores == null)
            {
                return NotFound();
            }

            return View(sectores);
        }

        // POST: Sectores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sectores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sectores'  is null.");
            }
            var sectores = await _context.Sectores.FindAsync(id);
            if (sectores != null)
            {
                _context.Sectores.Remove(sectores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectoresExists(int id)
        {
          return (_context.Sectores?.Any(e => e.IdSector == id)).GetValueOrDefault();
        }
    }
}
