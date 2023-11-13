using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Producciones.Data;
using Producciones.Models;

namespace Producciones.Controllers
{    
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<Usuarios> _userManager;
        private readonly ApplicationDbContext _context;
        public UserController(UserManager<Usuarios> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            var usuarios = await _context.Users.ToListAsync();

            return View(usuarios);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulos/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Users.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }            
            ViewData["Sector"] = new SelectList(new[]
            {
                new { Value = "Conformado", Text = "Conformado" },
                new { Value = "Producción", Text = "Producción" }
            }, "Value", "Text");
            return View(usuarios);
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id, Nombre, Apellido, Sector")] Usuarios usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Obtener el usuario desde el contexto
                    var userToUpdate = await _context.Users.FindAsync(id);

                    if (userToUpdate == null)
                    {
                        return NotFound();
                    }

                    // Actualizar las propiedades
                    userToUpdate.Nombre = usuario.Nombre;
                    userToUpdate.Apellido = usuario.Apellido;
                    userToUpdate.Sector = usuario.Sector;

                    // Marcar el usuario como modificado en el contexto
                    _context.Entry(userToUpdate).State = EntityState.Modified;

                    // Guardar los cambios en el contexto
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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

            ViewData["Sector"] = new SelectList(new[]
            {
                new { Value = "Conformado", Text = "Conformado" },
                new { Value = "Producción", Text = "Producción" }
            }, "Value", "Text");

            return View(usuario);
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private bool UsuarioExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
