using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Producciones.Models;

public class UserRolesManagerController : Controller
{
    private readonly UserManager<Usuarios> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    public UserRolesManagerController(UserManager<Usuarios> _userManager,
    RoleManager<IdentityRole> _roleManager)
    {
        roleManager = _roleManager;
        userManager = _userManager;
    }
    public async Task<IActionResult> Index()
    {
        var users = await userManager.Users.ToListAsync();        
        var userRoles = new List<UserRoles>();
        foreach (Usuarios user in users)
        {
            var thisViewModel = new UserRoles();
            thisViewModel.UserId = user.Id;
            thisViewModel.Email = user.Email;
            thisViewModel.Nombre = user.Nombre;
            thisViewModel.Apellido = user.Apellido;
            thisViewModel.Roles = await GetUserRoles(user);
            userRoles.Add(thisViewModel);
        }
        return View(userRoles);
    }
    private async Task<List<string>> GetUserRoles(Usuarios user)
    {
        return new List<string>(await userManager.GetRolesAsync(user));
    }
    public async Task<IActionResult> Manage(string userId)
    {
        try
        {
            ViewBag.userId = userId;
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;
            var model = new List<ManagerUserRoles>();
            foreach (var role in roleManager.Roles)
            {
                var userRolesViewModel = new ManagerUserRoles
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (user == null || role.Name == null)
                    return View(userRolesViewModel);

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }
        catch (Exception ex)
        {
            // Aquí puedes registrar o imprimir detalles del error exacto para depuración.
            Console.WriteLine("Error: " + ex.Message);
            // Puedes manejar la excepción de otra manera si lo necesitas.
            return View("Error");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Manage(List<ManagerUserRoles> model, string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return View();
        }
        var roles = await userManager.GetRolesAsync(user);
        var result = await userManager.RemoveFromRolesAsync(user, roles);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Cannot remove user existing roles");
            return View(model);
        }
        result = await userManager.AddToRolesAsync(user, model.Where(x =>
        x.Selected).Select(y => y.RoleName));
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Cannot add selected roles to user");
            return View(model);
        }
        return RedirectToAction("Index");
    }
}