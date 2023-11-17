using Microsoft.AspNetCore.Identity.UI.Services;
using Producciones.Models;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

#nullable disable
namespace Producciones.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<Usuarios> _userManager;
        private readonly IEmailSender _sender;

        public RegisterConfirmationModel(UserManager<Usuarios> userManager, IEmailSender sender)
        {
            _userManager = userManager;
            _sender = sender;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public bool DisplayConfirmAccountLink { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string EmailConfirmationUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }
            returnUrl = returnUrl ?? Url.Content("~/");

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            Email = email;
            // Once you add a real email sender, you should remove this code that lets you confirm the account
            DisplayConfirmAccountLink = false;
            if (DisplayConfirmAccountLink)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                EmailConfirmationUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    protocol: Request.Scheme);
            }

            return Page();
        }
    }
}


//namespace Producciones.Areas.Identity.Pages.Account
//{
//    public class RegisterConfirmationModel : PageModel
//    {
//        private readonly UserManager<Usuarios> _userManager;
//        private readonly IEmailSender _sender;
//        private readonly IOptions<SmtpSettings> _smtpSettings;

//        public RegisterConfirmationModel(UserManager<Usuarios> userManager, IEmailSender sender, IOptions<SmtpSettings> smtpSettings)
//        {
//            _userManager = userManager;
//            _sender = sender;
//            _smtpSettings = smtpSettings;
//        }

//        public string Email { get; set; }
//        public bool DisplayConfirmAccountLink { get; set; }
//        public string EmailConfirmationUrl { get; set; }

//        public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
//        {
//            if (email == null)
//            {
//                return RedirectToPage("/Index");
//            }
//            returnUrl = returnUrl ?? Url.Content("~/");

//            var user = await _userManager.FindByEmailAsync(email);
//            if (user == null)
//            {
//                return NotFound($"No se puede cargar el usuario con el correo electrónico '{email}'.");
//            }

//            Email = email;
//            DisplayConfirmAccountLink = true;

//            if (DisplayConfirmAccountLink)
//            {
//                var userId = await _userManager.GetUserIdAsync(user);
//                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
//                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

//                // Utilizar la configuración SMTP para enviar el correo electrónico
//                var smtpHost = _smtpSettings.Value.Host;
//                var smtpPort = _smtpSettings.Value.Port;
//                var smtpUserName = _smtpSettings.Value.UserName;
//                var smtpPassword = _smtpSettings.Value.Password;

//                // Construir la URL de confirmación de correo electrónico
//                EmailConfirmationUrl = $"smtp://{smtpUserName}:{smtpPassword}@{smtpHost}:{smtpPort}" +
//                    $"/Account/ConfirmEmail?userId={userId}&code={code}&returnUrl={returnUrl}";

//                // Aquí deberías enviar el correo electrónico utilizando el objeto _sender
//                // (código para enviar el correo electrónico omitido por brevedad)
//                await _sender.SendEmailAsync(email, "Confirma tu cuenta", $"Por favor confirma tu cuenta haciendo clic <a href='{EmailConfirmationUrl}'>aquí</a>.");

//            }

//            return Page();
//        }
//    }
//}