using Microsoft.AspNetCore.Mvc;

using MVCClinicaMedica.Models;
using MVCClinicaMedica.Utilitario;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using MVCClinicaMedica.Repository.Servicios.Contrato;
using System.Diagnostics;
using MVCClinicaMedica.Validador;
using Microsoft.AspNetCore.Authorization;

namespace MVCClinicaMedica.Controllers
{

    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;

        public InicioController(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {
            try
            {
                if (!ValidadorCorreo.EsCorreoValido(modelo.Correo))
                {
                    ViewData["Mensaje"] = "Correo inválido. Por favor, ingresa un correo válido.";
                    return View("Registrarse", modelo);
                }

                if (!ValidadorPassword.EsPasswordValido(modelo.Password))
                {
                    ViewData["Mensaje"] = "Contraseña inválida. La contraseña debe tener al menos 8 caracteres.";
                    return View();
                }
                // Asignar directamente idRol = 1 (Paciente)
                modelo.idRol = 1;

                modelo.Password = Utilidades.EncriptarClave(modelo.Password);

                Usuario usuario_creado = await _usuarioServicio.SaveUsuario(modelo);

                if (usuario_creado.idUsuario > 0)
                    return RedirectToAction("IniciarSesion");

                ViewData["Mensaje"] = "No se pudo crear el usuario";
                return View("Registrarse", modelo); // Devuelve la vista con el mensaje
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = "Error al registrar el usuario: " + ex.Message;
                return View("Registrarse", modelo); // Devuelve la vista con el mensaje
            }
        }


        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            string claveEncriptada = Utilidades.EncriptarClave(clave);

            Debug.WriteLine($"Intentando iniciar sesión con correo: {correo}");

            Usuario usuario_encontrado = await _usuarioServicio.GetUsuario(correo, claveEncriptada);

            if (usuario_encontrado == null)
            {
                Debug.WriteLine("No se encontraron coincidencias");
                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }

            Debug.WriteLine($"Usuario encontrado con idRol: {usuario_encontrado.idRol}");

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.Correo)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
            );

            return RedirectToAction("Index", "Home");
        }
    }
}
