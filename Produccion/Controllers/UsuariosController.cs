using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Producciones.Models;
using Producciones.Data;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Producciones.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Authorize]
    public class UsuariosController : Controller
    {
        private UserManager<Usuarios> userManager;
        private IPasswordHasher<Usuarios> passwordHasher;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UsuariosController(UserManager<Usuarios> _userManager, IPasswordHasher<Usuarios> passwordHash, ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            userManager = _userManager;
            passwordHasher = passwordHash;
            _context = context;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(userManager.Users);
        }
        //[HttpPost]
        //public async Task<IActionResult> Create(Usuarios user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Usuarios appUser = new Usuarios
        //        {
        //            UserName = user.UserName,
        //            Email = user.Email,
        //            Categoria = user.Categoria,
        //            Sector = user.Sector,
        //        };
        //        IdentityResult result = await userManager.CreateAsync(appUser, user.PasswordHash);

        //        if (result.Succeeded)
        //            return RedirectToAction("Index");
        //        else
        //        {
        //            foreach (IdentityError error in result.Errors)
        //                ModelState.AddModelError("", error.Description);
        //        }
        //    }
        //    return View(user);
        //}
        public async Task<IActionResult> Update(string id)
        {
            var roles = _roleManager.Roles.ToList(); // roleManager debe estar configurado en tu controlador
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewBag.Roles = new SelectList(roles, "Name", "Name");
            ViewData["Categorias"] = new SelectList(_context.Categorias, "IdCategoria", "Denominacion");
            ViewData["Sectores"] = new SelectList(_context.Sectores, "IdSector", "Descripcion");
            return View(usuario);


            //var usuario = await _context.Usuarios
            //    .Include(u => u.Categoria)
            //    .Include(u => u.Sector)
            //    .FirstOrDefaultAsync(m => m.Id == id);

            //Usuarios user = await userManager.FindByIdAsync(id);

            
            //ViewData["Categoria"] = new SelectList(_context.Categorias, "CategoriaId", "Denominacion");
            //ViewData["Sector"] = new SelectList(_context.Sectores, "SectorId", "Descripcion");
            //if (user != null)
            //    return View(user);
            //else
            //    return RedirectToAction("Index");
        }



        //--------------------------------------------------------------------------------------------------------------------------------
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("IdArticulo,Codigo,Nombre,SectorId")] Articulo articulo)
        //{
        //    if (id != articulo.IdArticulo)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(articulo);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ArticuloExists(articulo.IdArticulo))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["SectorId"] = new SelectList(_context.Sectores, "IdSector", "Descripcion", articulo.SectorId);
        //    return View(articulo);
        //}
        //--------------------------------------------------------------------------------------------------------------------------------




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, string roleName, [Bind("Id,Nombre,Apellido,SectorId,CategoriaId,Autorizado,Email,UserName")] Usuarios usuario)
        {
            var roles = _roleManager.Roles.ToList(); // roleManager debe estar configurado en tu controlador
            if (id != usuario.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                     userManager?.AddToRoleAsync(usuario, roleName);
                        _context.Update(usuario);
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
            ViewBag.Roles = new SelectList(roles, "Name", "Name");
            ViewData["Categorias"] = new SelectList(_context.Categorias, "IdCategoria", "Denominacion", usuario.CategoriaId);
            ViewData["Sectores"] = new SelectList(_context.Sectores, "IdSector", "Descripcion", usuario.SectorId);            
            return View(usuario);            
        }



        //--------------------------------------------------------------------------------------------------------------------------------
        //[HttpPost]
        //public async Task<IActionResult> Update(string id, string email, string password, string nombre)
        //{
        //    Usuarios user = await userManager.FindByIdAsync(id);
        //    if (user != null)
        //    {
        //        if (!string.IsNullOrEmpty(email))
        //            user.Email = email;
        //        else
        //            ModelState.AddModelError("", "Email cannot be empty");
        //    if (!string.IsNullOrEmpty(password))
        //            user.PasswordHash =
        //            passwordHasher.HashPassword(user, password);
        //        else
        //            ModelState.AddModelError("", "Password cannot be empty");
        //    if (!string.IsNullOrEmpty(email) &&
        //    !string.IsNullOrEmpty(password))
        //        {
        //            IdentityResult result = await
        //            userManager.UpdateAsync(user);
        //            if (result.Succeeded)
        //                return RedirectToAction("Index");
        //            else
        //                Errors(result);
        //        }
        //    }
        //    else
        //        ModelState.AddModelError("", "User Not Found");
        //    return View(user);
        //}
        //private void Errors(IdentityResult result)
        //{
        //    foreach (IdentityError error in result.Errors)
        //        ModelState.AddModelError("", error.Description);
        //}
        //--------------------------------------------------------------------------------------------------------------------------------









        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            Usuarios user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await
                userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }

        private bool UsuarioExists(string id)
        {
            return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
