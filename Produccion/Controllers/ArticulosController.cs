//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Producciones.Data;
//using Producciones.Models;

//namespace Producciones.Controllers
//{
//    [Authorize]
//    public class ArticulosController : Controller
//    {
//        private readonly SecondaryDbContext _secondaryContext;
//        private readonly ApplicationDbContext _context;

//        public ArticulosController(SecondaryDbContext secondaryContext, ApplicationDbContext context)
//        {
//            _secondaryContext = secondaryContext;
//            _context = context;
//        }

//        // GET: Articulos
//        public async Task<IActionResult> Index()
//        {
//            var productos = await _context.Articulos
//                .ToListAsync();

//            return View(productos);
//        }

//        public async Task<IActionResult> CopyData()
//        {
//            var fechaLimite = DateTime.ParseExact("2015-01-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
//            // Obtener datos de SecondaryDbContext con el filtrado aplicado
//            var datosSecundarios = await _secondaryContext.Articulos
//                .Where(a => a.Artda1Cod != "10" &&
//                            a.ArtFecMod > fechaLimite &&
//                            a.Artda1Cod != "6" &&
//                            a.Artda1Cod != "9" &&
//                            a.ArtCtrlStock == true &&
//                            a.ArtCircProd == true &&
//                            a.Artda2Cod != "36")
//                .ToListAsync();

//            foreach (var datoSecundario in datosSecundarios)
//            {
//                // Verificar si ya existe en ApplicationDbContext
//                var existente = await _context.Articulos
//                    .FirstOrDefaultAsync(a => a.ArtCodGen == datoSecundario.ArtCodGen);

//                if (existente == null)
//                {
//                    // Si no existe, insertar nuevo Articulo
//                    var nuevoArticulo = new Articulo
//                    {
//                        ArtCodGen = datoSecundario.ArtCodGen,
//                        ArtDescGen = datoSecundario.ArtDescGen,
//                        ArtclaCod = datoSecundario.ArtclaCod
//                        // Agrega las demás propiedades según sea necesario
//                    };

//                    _context.Articulos.Add(nuevoArticulo);
//                }
//                else
//                {
//                    // Si ya existe, actualizar propiedades
//                    existente.ArtDescGen = datoSecundario.ArtDescGen;
//                    existente.ArtclaCod = datoSecundario.ArtclaCod;
//                    // Actualiza las demás propiedades según sea necesario
//                }
//            }

//            await _context.SaveChangesAsync();

//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
