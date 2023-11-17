using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Net.Mail;
using System.Net;

namespace Producciones.Services;

public class EmailSender : IEmailSender
{
    private readonly ILogger _logger; 
    private readonly SmtpSettings _smtpSettings;

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    public EmailSender(IOptions<SmtpSettings> smtpSettings, ILogger<EmailSender> logger)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    {
        _smtpSettings = smtpSettings.Value;
        _logger = logger;
    }

    public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        try
        {
            using (var client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password);
                client.EnableSsl = _smtpSettings.EnableSsl;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.UserName, "sistemas@imcestari.com"),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
            }
            _logger.LogInformation($"Correo electrónico enviado correctamente a {toEmail}!");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Fallo el envio del correo electrónico a {toEmail}: {ex.Message}");
            throw;
        }
        //if (string.IsNullOrEmpty(Options.SendGridKey))
        //{
        //    throw new Exception("Null SendGridKey");
        //}
        //await Execute(Options.SendGridKey, subject, message, toEmail);
    }
    //public async Task Execute(string apiKey, string subject, string message, string toEmail)
    //{
    //    var client = new SendGridClient(apiKey);
    //    var msg = new SendGridMessage()
    //    {
    //        From = new EmailAddress("sistemas@imcestari.com", "Password Recovery"),
    //        Subject = subject,
    //        PlainTextContent = message,
    //        HtmlContent = message
    //    };
    //    msg.AddTo(new EmailAddress(toEmail));

    //    // Disable click tracking.
    //    // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
    //    msg.SetClickTracking(false, false);
    //    var response = await client.SendEmailAsync(msg);
    //    _logger.LogInformation(response.IsSuccessStatusCode
    //                           ? $"Email to {toEmail} queued successfully!"
    //                           : $"Failure Email to {toEmail}");
    //}
}