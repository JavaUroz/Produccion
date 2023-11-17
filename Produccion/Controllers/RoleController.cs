using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System.ComponentModel.DataAnnotations;

namespace Producciones.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(roles);
        }
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
        public ActionResult Create()

        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new
                IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }
        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IdentityRole rol)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = await roleManager.FindByIdAsync(rol.Id);
                if (role != null)
                {
                    role.Name = rol.Name;
                    IdentityResult result = await roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                }
            }
            return View(rol);
        }

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || roleManager.Roles == null)
            {
                return NotFound();
            }

            var rol = await roleManager.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // POST: Procesos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var rol = await roleManager.FindByIdAsync(id);

                if (rol == null)
                {
                    return NotFound(); // El rol no se encontró
                }

                var result = await roleManager.DeleteAsync(rol);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Manejar errores de eliminación
                    // Puedes acceder a los errores a través de result.Errors
                    return Problem("Error al eliminar el rol.");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones generales
                return Problem($"Error inesperado: {ex.Message}");
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    IdentityRole role = await roleManager.FindByIdAsync(id);
        //    if (role != null)
        //    {
        //        IdentityResult result = await roleManager.DeleteAsync(role);
        //        if (result.Succeeded)
        //            return RedirectToAction("Index");
        //    }
        //    else
        //        ModelState.AddModelError("", "Error en encontrar el rol");
        //    return View("Index", roleManager.Roles);
        //}
    }
}
