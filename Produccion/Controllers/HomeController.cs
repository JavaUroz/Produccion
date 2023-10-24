using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Producciones.Models;
using System.Diagnostics;

namespace Producciones.Controllers
{
    [Authorize(Roles = "Super Admin, Admin") ]
    public class HomeController : Controller
    {
        private UserManager<Usuarios> userManager;
        public HomeController(UserManager<Usuarios> _userManager)
        {
            userManager = _userManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            Usuarios user = await
            userManager.GetUserAsync(HttpContext.User);
            string message = "Bienvenido " + user.UserName;
            return View((object)message);
        }
    }


    //public class HomeController : Controller
    //{
    //    private readonly ILogger<HomeController> _logger;

    //    public HomeController(ILogger<HomeController> logger)
    //    {
    //        _logger = logger;
    //    }
    //    [Authorize]
    //    public IActionResult Index()
    //    {
    //        AppUser user = await userManager.GetUserAsync(HttpContext.User);
    //        string message = "Hello " + user.UserName;
    //        return View((object)message);
    //    }

    //    public IActionResult Privacy()
    //    {
    //        return View();
    //    }

    //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //    public IActionResult Error()
    //    {
    //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //    }
    //}


}


    