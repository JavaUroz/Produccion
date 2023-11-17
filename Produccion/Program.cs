using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Producciones.Data;
using Producciones.Models;
using System;
using Producciones.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la cadena de conexión para la base de datos principal
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configuración de la cadena de conexión para la base de datos secundaria
var secondaryConnectionString = builder.Configuration.GetConnectionString("SecondaryConnection");
builder.Services.AddDbContext<SecondaryDbContext>(options =>
    options.UseSqlServer(secondaryConnectionString));

// Filtro de excepciones para páginas de desarrollador
builder.Services.AddDatabaseDeveloperPageExceptionFilter();



//var produccionesApiKey = builder.Configuration["Producciones:ServiceApiKey"];

//// Agrega el servicio de envío de correos electrónicos (IEmailSender)
//builder.Services.AddTransient<IEmailSender, CustomEmailSender>();

// Configuración de SmtpSettings
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

// Agrega el servicio de envío de correos electrónicos (IEmailSender)
builder.Services.AddTransient<IEmailSender, EmailSender>();


//builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("AuthMessageSenderOptions"));

// Configuración de Identity
builder.Services.AddDefaultIdentity<Usuarios>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Opciones de contraseña
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
    options.Password.RequiredUniqueChars = 1;

    // Opciones de bloqueo de cuenta
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // Opciones de usuario
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
});

// Configuración de controladores y vistas
builder.Services.AddControllersWithViews();

// Configuración de Razor Pages
builder.Services.AddRazorPages();

builder.Services.ConfigureApplicationCookie(o => {
    o.ExpireTimeSpan = TimeSpan.FromDays(5);
    o.SlidingExpiration = true;
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
       o.TokenLifespan = TimeSpan.FromHours(3));

var app = builder.Build();

// Configuración del pipeline de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

//app.MapGet("/", () => produccionesApiKey);

app.Run();
