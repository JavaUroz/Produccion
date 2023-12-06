using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Producciones.Data;
using Producciones.Models;

namespace Producciones.Controllers
{
    [Authorize]
    public class ArticulosProduccionsController : Controller
    {
        private readonly UserManager<Usuarios> _userManager;
        private readonly ProduccionContext _context;

        public ArticulosProduccionsController(ProduccionContext context, UserManager<Usuarios> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ArticulosProduccions
        public async Task<IActionResult> Index()
        {
            return _context.ArticulosProduccions != null ?
                        View(await _context.ArticulosProduccions.ToListAsync()) :
                        Problem("Entity set 'ProduccionContext.ArticulosProduccions'  is null.");
        }

        // GET: ArticulosProduccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArticulosProduccions == null)
            {
                return NotFound();
            }

            var articulosProduccion = await _context.ArticulosProduccions
                .FirstOrDefaultAsync(m => m.IdArtProd == id);
            if (articulosProduccion == null)
            {
                return NotFound();
            }

            return View(articulosProduccion);
        }

        // GET: ArticulosProduccions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArticulosProduccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArtProd,CodGenArt,ProduccionId")] ArticulosProduccion articulosProduccion)
        {
            var produccion = await _context.Produccions
                .FindAsync(articulosProduccion.ProduccionId);

            var programacion = await _context.Programacions
                .FindAsync(produccion.ProgramacionId);

            var usuarioLogueado = await _userManager.GetUserAsync(User);

            ViewData["Produccion"] = new SelectList(_context.Produccions
                .Include(p => p.Programacion)                
                .Where(p => p.Programacion.Usuario.Sector == usuarioLogueado.Sector)
                .OrderBy(p => p.Programacion.OrdenProduccion)
                .Select(p => new
                {
                    Value = p.IdProduccion,
                    Text = $"Orden N° {p.Programacion.OrdenProduccion} - {p.Programacion.Proceso.Nombre}, {p.Programacion.ArticuloCodNavigation.ArtDescGen} (Cod. {p.Programacion.ArticuloCodNavigation.ArtCodGen})",
                }).Distinct(), "Value", "Text");

            ViewData["Articulo"] = new SelectList(_context.Articulos
                .OrderBy(a => a.ArtDescGen) // Ordenar por art_CodDesc = "Descripcion"
                .Select(a => new
                {
                    Id = a.ArtCodGen,
                    Nombre = $"{a.ArtDescGen} (Cod. {a.ArtCodGen})"
                }), "Id", "Nombre");
            if (ModelState.IsValid)
            {
                _context.Add(articulosProduccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articulosProduccion);
        }

        // GET: ArticulosProduccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArticulosProduccions == null)
            {
                return NotFound();
            }

            var articulosProduccion = await _context.ArticulosProduccions.FindAsync(id);
            if (articulosProduccion == null)
            {
                return NotFound();
            }
            return View(articulosProduccion);
        }

        // POST: ArticulosProduccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArtProd,CodGenArt,ProduccionId")] ArticulosProduccion articulosProduccion)
        {
            if (id != articulosProduccion.IdArtProd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulosProduccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticulosProduccionExists(articulosProduccion.IdArtProd))
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
            return View(articulosProduccion);
        }

        // GET: ArticulosProduccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArticulosProduccions == null)
            {
                return NotFound();
            }

            var articulosProduccion = await _context.ArticulosProduccions
                .FirstOrDefaultAsync(m => m.IdArtProd == id);
            if (articulosProduccion == null)
            {
                return NotFound();
            }

            return View(articulosProduccion);
        }

        // POST: ArticulosProduccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArticulosProduccions == null)
            {
                return Problem("Entity set 'ProduccionContext.ArticulosProduccions'  is null.");
            }
            var articulosProduccion = await _context.ArticulosProduccions.FindAsync(id);
            if (articulosProduccion != null)
            {
                _context.ArticulosProduccions.Remove(articulosProduccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticulosProduccionExists(int id)
        {
            return (_context.ArticulosProduccions?.Any(e => e.IdArtProd == id)).GetValueOrDefault();
        }
    }
}
