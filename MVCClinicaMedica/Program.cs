using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Repository.Servicios.Contrato;
using MVCClinicaMedica.Repository.Servicios.Implementacion;
using MVCClinicaMedica.Filtros; // Asegúrate de importar el namespace de los filtros
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MVCClinicaMedica.BussinesLogic;
using MVCClinicaMedica.Repository;
using MVCClinicaMedica.Services;

var builder = WebApplication.CreateBuilder(args);

// Conexión base de datos.
builder.Services.AddDbContext<BaseEFContext>(options =>
    options.UseSqlServer("name=ConnectionStrings:Connection"));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Inicio/IniciarSesion";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddScoped<FacturaBL>();
builder.Services.AddScoped<ClienteBL>();
builder.Services.AddScoped<CitasRepo>();
//Para que no puedas regresar al poner Cerrar Sesion
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(
        new ResponseCacheAttribute
        {
            NoStore = true,
            Location = ResponseCacheLocation.None,
        }
    );
});
///************************************************************KALI LINUX /*******************************
builder.Services.AddScoped<IEmailService, EmailService>();
///*******************************************************************************************************
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Index"); // Cambia "Index" por la acción adecuada en tu controlador Error
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");


app.Run();