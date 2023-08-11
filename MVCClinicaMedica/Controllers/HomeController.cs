using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Filtros;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace MVCClinicaMedica.Controllers
{
    [Authorize] // Solo accede si el usuario está autorizado
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceProvider _serviceProvider;

        public HomeController(ILogger<HomeController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AutorizarUsuario(1)] // Permitir idOperacion 1 
        public IActionResult Privacy()
        {
            return View();
        }

        [AutorizarUsuario(2)] // Permitir idOperacion 1 y 2
        public IActionResult Estadisticas()
        {
            return View();
        }

        [AutorizarUsuario(3)] // Permitir idOperacion 1, 2 y 3
        public IActionResult Citas()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("IniciarSesion", "Inicio");
        }

    }
}