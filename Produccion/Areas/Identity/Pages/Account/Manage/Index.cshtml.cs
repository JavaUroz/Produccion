// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Producciones.Data;
using Producciones.Models;

namespace Producciones.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<Usuarios> _userManager;
        private readonly SignInManager<Usuarios> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IndexModel(
            UserManager<Usuarios> userManager,
            SignInManager<Usuarios> signInManager,
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [DisplayName("Teléfono")]
            public string PhoneNumber { get; set; }

            [DisplayName("Nombre")]
            public string? Nombre { get; set; }
            [DisplayName("Apellido")]
            public string? Apellido { get; set; }

            [DisplayName("Sector")]
            public int? SectorId { get; set; } = 1;
            [DisplayName("Categoría")]
            public int? CategoriaId { get; set; } = 1;
            [DisplayName("Autorizado")]
            public bool Autorizado { get; set; } = false;

            public virtual Categoria Categoria { get; set; }
            public virtual Sectores Sector { get; set; } = null!;
            public virtual ICollection<Produccion> Produccions { get; set; }
            public virtual ICollection<Programacion> Programacions { get; set; }

        }

        private async Task LoadAsync(Usuarios user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);


            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Sector = user.Sector,
                Categoria = user.Categoria,
                Autorizado = user.Autorizado
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var roles = _roleManager.Roles.ToList(); // roleManager debe estar configurado en tu controlador
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            ViewData["Roles"] = new SelectList(roles, "Name", "Name");
            ViewData["Categorias"] = new SelectList(_context.Categorias, "IdCategoria", "Denominacion", user.CategoriaId);
            ViewData["Sectores"] = new SelectList(_context.Sectores, "IdSector", "Descripcion", user.SectorId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var roles = _roleManager.Roles.ToList(); // roleManager debe estar configurado en tu controlador
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            //Aquí nuestros campos
            if (Input.Nombre != user.Nombre)
            {
                user.Nombre = Input.Nombre;
            }
            if (Input.Apellido != user.Apellido)
            {
                user.Apellido = Input.Apellido;
            }
            if (Input.Sector != user.Sector)
            {
                user.Sector = Input.Sector;
            }
            if (Input.Categoria != user.Categoria)
            {
                user.Categoria = Input.Categoria;
            }
            if (Input.Autorizado != user.Autorizado)
            {
                user.Autorizado = Input.Autorizado;
            }

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";

            ViewData["Roles"] = new SelectList(roles, "Name", "Name");
            ViewData["Categorias"] = new SelectList(_context.Categorias, "IdCategoria", "Denominacion", user.CategoriaId);
            ViewData["Sectores"] = new SelectList(_context.Sectores, "IdSector", "Descripcion", user.SectorId);
            return RedirectToPage();
        }
    }
}
