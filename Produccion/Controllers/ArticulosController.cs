using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Producciones.Data;
using Producciones.Models;

namespace Producciones.Controllers
{
    [Authorize]
    public class ArticulosController : Controller
    {
        private readonly SecondaryDbContext _secondaryContext;
        private readonly ApplicationDbContext _context;

        public ArticulosController(SecondaryDbContext secondaryContext, ApplicationDbContext context)
        {
            _secondaryContext = secondaryContext;
            _context = context;
        }

        // GET: Articulos
        public async Task<IActionResult> Index()
        {
            var productos = await _context.Articulos
                //.Where(a => a.art_Tipo != "3")
                .ToListAsync();

            return View(productos);
        }

        public async Task<IActionResult> CopyData()
        {
            // Obtener datos de SecondaryDbContext
            var datosSecundarios = await _secondaryContext.Articulos.ToListAsync();

            foreach (var datoSecundario in datosSecundarios)
            {
                // Verificar si ya existe en ApplicationDbContext
                var existente = await _context.Articulos
                    .FirstOrDefaultAsync(a => a.art_CodGen == datoSecundario.art_CodGen);

                if (existente == null)
                {
                    // Si no existe, insertar nuevo Articulo
                    var nuevoArticulo = new Articulo
                    {
                        art_CodGen = datoSecundario.art_CodGen,
                        art_DescGen = datoSecundario.art_DescGen,
                        artcla_Cod = datoSecundario.artcla_Cod
                    };

                    _context.Articulos.Add(nuevoArticulo);
                }
                else
                {
                    // Si ya existe, actualizar propiedades
                    existente.art_DescGen = datoSecundario.art_DescGen;
                    existente.artcla_Cod = datoSecundario.artcla_Cod;
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
