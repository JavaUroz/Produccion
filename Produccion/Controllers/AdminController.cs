using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Producciones.Models;

namespace Producciones.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<Usuarios> userManager;
        private IPasswordHasher<Usuarios> passwordHasher;
        public AdminController(UserManager<Usuarios> _userManager, IPasswordHasher<Usuarios> passwordHash)
        {
            userManager = _userManager;
            passwordHasher = passwordHash;
        }
        public IActionResult Index()
        {
            return View(userManager.Users);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Usuarios user)
        {
            if (ModelState.IsValid)
            {
                Usuarios appUser = new Usuarios
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Categoria = user.Categoria,
                    Sector = user.Sector,
                };
                IdentityResult result = await userManager.CreateAsync(appUser, user.PasswordHash);

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }
        public async Task<IActionResult> Update(string id)
        {
            Usuarios user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id, string email, string password)
        {
            Usuarios user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("", "Email cannot be empty");
            if (!string.IsNullOrEmpty(password))
                    user.PasswordHash =
                    passwordHasher.HashPassword(user, password);
                else
                    ModelState.AddModelError("", "Password cannot be empty");
            if (!string.IsNullOrEmpty(email) &&
            !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await
                    userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View(user);
        }
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
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
    }
}
