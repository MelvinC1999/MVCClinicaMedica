using Microsoft.AspNetCore.Mvc;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Utilitario;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using MVCClinicaMedica.Repository.Servicios.Contrato;
using System.Diagnostics;
using MVCClinicaMedica.Validador;
using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.BusinessLogic;
using MVCClinicaMedica.DBContext;

namespace MVCClinicaMedica.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;
        PacienteBL pacienteBL = new PacienteBL();


        public InicioController(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        public IActionResult Registrarse(Usuario modelo)
        {
            //ViewData["pass"] = modelo.Password;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo, Paciente paciente)
        {
            try
            {
                 //El correo que entra es para Paciente, hay que replicar la info a Usuarios
                if (!ValidadorCorreo.EsCorreoValido(paciente.Correo))
                {
                    ViewData["Mensaje"] = "Correo inválido. Por favor, ingresa un correo válido.";
                    return View("Registrarse", paciente);
                }

                modelo.Correo = paciente.Correo;
                // hasta correo esta bien xd

                Console.ForegroundColor = ConsoleColor.Yellow;
                //esta password que entra es para Usuarios
                Console.WriteLine(modelo.Correo);
                var pass = ViewData["contrasena"];
                Console.WriteLine(pass);



                if (!ValidadorPassword.EsPasswordValido(modelo.Password))
                {
                    ViewData["Mensaje"] = "Contraseña inválida. La contraseña debe tener al menos 8 caracteres.";
                    return View();
                }
                // Asignar directamente idRol = 1 (Paciente)
                modelo.idRol = 1;

                modelo.Password = Utilidades.EncriptarClave(modelo.Password);
                
                var password = modelo.Password;

                Usuario usuario_creado = await _usuarioServicio.SaveUsuario(modelo);
                pacienteBL.CrearGuardarPaciente(paciente);

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
    