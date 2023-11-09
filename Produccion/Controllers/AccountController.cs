//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Producciones.Models;
//namespace Producciones.Controllers
//{
//    [Authorize]
//    public class AccountController : Controller
//    {
//        private UserManager<Usuarios> userManager;
//        private SignInManager<Usuarios> signInManager;
//        public AccountController(UserManager<Usuarios> userMgr, SignInManager<Usuarios> signinMgr)
//        {
//            userManager = userMgr;
//            signInManager = signinMgr;
//        }
//        [AllowAnonymous]
//        public IActionResult Login(string returnUrl)
//        {
//            Login login = new Login();
//            login.ReturnUrl = returnUrl;
//            return View(login);
//        }
//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Login(Login login)
//        {
//            if (ModelState.IsValid)
//            {
//                Usuarios appUser = await
//                userManager.FindByEmailAsync(login.Email);
//                if (appUser != null)
//                {
//                    await signInManager.SignOutAsync();

//                    Microsoft.AspNetCore.Identity.SignInResult result
//                    = await signInManager.PasswordSignInAsync(appUser, login.Password,
//                    false, false);
//                    if (result.Succeeded)
//                        return Redirect(login.ReturnUrl ?? "/");
//                }
//                ModelState.AddModelError(nameof(login.Email), "Login Failed: Invalid Email or password");
//            }
//            return View(login);
//        }
//        public async Task<IActionResult> Logout()
//        {
//            await signInManager.SignOutAsync();
//            return RedirectToAction("Index", "Home");
//        }
//    }
//}