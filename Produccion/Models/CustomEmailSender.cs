using Microsoft.AspNetCore.Identity.UI.Services;

namespace Producciones.Models
{
    public class CustomEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Implementa aquí la lógica de envío de correos electrónicos según tus necesidades
            // Puedes utilizar la configuración SMTP aquí
            return Task.CompletedTask;
        }
    }
}