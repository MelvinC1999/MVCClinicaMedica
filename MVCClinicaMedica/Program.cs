using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Repository.Servicios.Contrato;
using MVCClinicaMedica.Repository.Servicios.Implementacion;
using MVCClinicaMedica.Filtros; // Asegúrate de importar el namespace de los filtros
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

// Conexión base de datos.
builder.Services.AddDbContext<BaseEFContext>(options =>
    options.UseSqlServer("name=ConnectionStrings:Connection"));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Inicio/IniciarSesion";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

builder.Services.AddControllersWithViews(options => {
    options.Filters.Add(
        new ResponseCacheAttribute
        {
            NoStore = true,
            Location = ResponseCacheLocation.None,
        }
    );
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Index"); // Cambia "Index" por la acción adecuada en tu controlador Error
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

app.Run();
