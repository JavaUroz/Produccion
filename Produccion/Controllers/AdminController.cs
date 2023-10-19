using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Producciones.Models;

namespace Producciones.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<Usuario> userManager;
        private IPasswordHasher<Usuario> passwordHasher;
        public AdminController(UserManager<Usuario> _userManager, IPasswordHasher<Usuario> passwordHash)
        {
            userManager = _userManager;
            passwordHasher = passwordHash;
        }
        public IActionResult Index()
        {
            return View(userManager.Users);
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                Usuario appUser = new Usuario
                {
                    UserName = user.Name,
                    Email = user.Email
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);

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
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id, string email, string password)
        {
            Usuario user = await userManager.FindByIdAsync(id);
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
            Usuario user = await userManager.FindByIdAsync(id);
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
