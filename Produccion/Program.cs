using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Producciones.Data;
using Producciones.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<Usuarios>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();



builder.Services.AddIdentity<Usuarios, IdentityRole>(options =>
{
    // Opciones de configuraci�n de Identity
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders()
.AddDefaultUI();


//builder.Services.AddDefaultIdentity<Usuarios>()
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders()
//    .AddDefaultUI();


// Agregar RoleManager
builder.Services.AddScoped<RoleManager<IdentityRole>>();

builder.Services.AddControllersWithViews();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
    options.Password.RequiredUniqueChars = 1;
    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
});

// Configura servicios de autenticaci�n y autorizaci�n
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

// Agrega servicios Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.Run();

//------------------------------------------------------------ORIGINAL------------------------------------------------------------------
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Options;
//using Producciones.Data;
//using Producciones.Models;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<Usuarios>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

////builder.Services.AddIdentity<Usuarios, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true) // Agregar RoleManager
////        .AddEntityFrameworkStores<ApplicationDbContext>()
////        .AddDefaultTokenProviders();


//builder.Services.AddControllersWithViews();

//builder.Services.Configure<IdentityOptions>(options =>
//{
//    // Password settings.
//    options.Password.RequireDigit = false;
//    options.Password.RequireLowercase = false;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireUppercase = false;
//    options.Password.RequiredLength = 4;
//    options.Password.RequiredUniqueChars = 1;
//    // Lockout settings.
//    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
//    options.Lockout.MaxFailedAccessAttempts = 5;
//    options.Lockout.AllowedForNewUsers = true;
//    // User settings.
//    options.User.AllowedUserNameCharacters =
//    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
//    //options.User.RequireUniqueEmail = false;
//});

////builder.Services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Account/Login"); no es necesario

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseMigrationsEndPoint();
//}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

//app.Run();
//---------------------------------------------------------------ORIGINAL-----------------------------------------------------------------------