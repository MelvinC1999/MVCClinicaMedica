using Microsoft.AspNetCore.Mvc; // Espacio de nombres para las clases de MVC
using Microsoft.AspNetCore.Mvc.Rendering; // Espacio de nombres para las clases de renderizado de vistas
using MVCClinicaMedica.DBContext; // Espacio de nombres para el contexto de la base de datos
using MVCClinicaMedica.Models; // Espacio de nombres para las clases de modelos
using System.Transactions; // Espacio de nombres para las transacciones
using MVCClinicaMedica.BusinessLogic; // Espacio de nombres para la lógica de negocio
using MVCClinicaMedica.Utilitario; // Espacio de nombres para utilidades
using MVCClinicaMedica.Validador; // Espacio de nombres para validadores
using MVCClinicaMedica.Repository.Servicios.Contrato; // Espacio de nombres para servicios de repositorio
using System.Diagnostics; // Espacio de nombres para diagnósticos
using Microsoft.EntityFrameworkCore; // Espacio de nombres para Entity Framework
using Microsoft.AspNetCore.Authorization;
using MVCClinicaMedica.Filtros;

namespace MVCClinicaMedica.Controllers
{
    [Authorize] //solo accede si el usuario esta autorizado
    public class UsuarioController : Controller
    {
        private readonly BaseEFContext _dbContext; // Contexto de la base de datos
        UsuarioBL usuarioBL = new UsuarioBL(); // Instancia de UsuarioBL
        OperacionBL operacionBL = new OperacionBL(); // Instancia de OperacionBL
        RolBL rolBL = new RolBL(); // Instancia de RolBL
        RolOperacionBL rolOperacionBL = new RolOperacionBL(); // Instancia de RolOperacionBL
        TransactionScope scope; // Transacción
        readonly MedicoBL medicoBL = new MedicoBL();
        readonly EspecialidadBL especialidadBL = new EspecialidadBL();

        private readonly IUsuarioService _usuarioServicio; // Servicio de usuario

        public UsuarioController(IUsuarioService usuarioServicio, BaseEFContext dbContext)
        {
            _usuarioServicio = usuarioServicio;
            _dbContext = dbContext;
            usuarioBL = new UsuarioBL(_dbContext); // Crear la instancia de UsuarioBL con el contexto
        }

        // Acción para la vista de opciones de administrador
        public IActionResult OpcionesAdmin()
        {
            return View();
        }

        // Acción para la vista de registro
        public IActionResult Registrarse()
        {
            ViewBag.Especialidades = especialidadBL.ObtenerListaEspecialidades();
            ViewBag.Horarios = medicoBL.ObtenerHorariosMedicos();
            return View();
        }

        // Acción para la vista de usuarios
        [AutorizarUsuario(3)] // Permitir idOperacion 1, 2 y 3
        public IActionResult Usuarios()
        {
            init(); // Inicializar datos necesarios
            return View(listaUsuarios());
        }

        // Obtener lista de usuarios
        public List<Usuario> listaUsuarios()
        {
            return usuarioBL.retornarUsuariosBL();
        }

        // Método para iniciar datos necesarios
        public void init()
        {
            // Obtener listas de usuarios, roles, operaciones y roles-operaciones
            var listadoUsuarios = usuarioBL.retornarUsuariosBL();
            ViewData["Usuarios"] = listadoUsuarios;

            var listadoRoles = rolBL.retornarRolesBL();
            ViewData["Roles"] = listadoRoles;

            var listadoOperaciones = operacionBL.retornarOperacionesBL();
            ViewData["Operaciones"] = listadoOperaciones;

            var listadoRolOperaciones = rolOperacionBL.retornarRolOperacionesBL();
            ViewData["RolOperaciones"] = listadoRolOperaciones;

        }

        // Acción para la vista de creación de usuarios
        public IActionResult CrearUsuario()
        {
            init2(); // Inicializar datos necesarios
            return View();
        }

        // Inicializar datos necesarios para combos
        public void init2()
        {
            // Obtener listas de usuarios, roles, operaciones y roles-operaciones
            var usuarioVar = usuarioBL.retornarUsuariosBL();
            ViewBag.Usuarios = usuarioBL.retornarUsuariosBL();

            var usuariosList = usuarioBL.retornarUsuariosBL();
            var itemsUsuarios = usuariosList.Select(p => new SelectListItem
            {
                Value = p.idUsuario.ToString(),
                Text = p.Correo + " " + p.Password + "    Rol: " + p.idRol
            }).ToList();
            ViewBag.ItemsUsuarios = itemsUsuarios;

            var rolesList = rolBL.retornarRolesBL();
            var itemsRoles = rolesList.Select(p => new SelectListItem
            {
                Value = p.idRol.ToString(),
                Text = p.NombreRol
            }).ToList();
            ViewBag.ItemsRoles = itemsRoles;

            var OperacionesList = operacionBL.retornarOperacionesBL();
            var itemsOperaciones = OperacionesList.Select(p => new SelectListItem
            {
                Value = p.idOperacion.ToString(),
                Text = p.NombreOperacion
            }).ToList();
            ViewBag.ItemsOperaciones = itemsOperaciones;

            var rolOperacionesList = rolOperacionBL.retornarRolOperacionesBL();
            var itemsRolOperaciones = rolOperacionesList.Select(p => new SelectListItem
            {
                Value = p.idRolOperacion.ToString(),
                Text = p.idRol + " " + p.idOperacion
            }).ToList();
            ViewBag.ItemsRolOperaciones = itemsRolOperaciones;
            ViewBag.Especialidades = especialidadBL.ObtenerListaEspecialidades();
        }

        // Acción para registrar un doctor
        public async Task<IActionResult> RegistrarDoctor(UsuarioMedicoViewModel modeloUM)
        {
            try
            {
                modeloUM.Usuario.Correo = modeloUM.Medico.Correo;
                // Validar el formato del correo
                if (!ValidadorCorreo.EsCorreoValido(modeloUM.Usuario.Correo))
                {
                    ViewData["Mensaje"] = "Correo inválido. Por favor, ingresa un correo válido.";
                    return View("Registrarse", modeloUM);
                }

                // Validar la contraseña
                if (!ValidadorPassword.EsPasswordValido(modeloUM.Usuario.Password))
                {
                    ViewData["Mensaje"] = "Contraseña inválida. La contraseña debe tener al menos 8 caracteres.";
                    return View();
                }

                // Asignar directamente idRol = 2 (Doctor)
                modeloUM.Usuario.idRol = 2;

                modeloUM.Usuario.Password = Utilidades.EncriptarClave(modeloUM.Usuario.Password);

                Usuario usuario_creado = await _usuarioServicio.SaveUsuario(modeloUM.Usuario);
                medicoBL.CrearMedico(modeloUM.Medico);

                if (usuario_creado.idUsuario > 0)
                    return RedirectToAction("Usuarios");

                ViewData["Mensaje"] = "No se pudo crear el usuario";
                
                return View("Usuarios", modeloUM); // Devuelve la vista con el mensaje
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = "Error al registrar el usuario: " + ex.Message;
                return View("Usuarios", modeloUM); // Devuelve la vista con el mensaje
            }
        }

        // Acción para mostrar la vista de edición de usuario
        public async Task<IActionResult> EditarUsuario(int idUsuario)
        {
            init(); // Inicializar datos necesarios
            Usuario usuario = await usuarioBL.ObtenerUsuarioPorIdAsync(idUsuario);

            if (usuario == null)
            {
                // Manejar el caso donde el usuario no se encontró
                return RedirectToAction("Usuarios");
            }

            return View(usuario);
        }

        // Acción para actualizar un usuario
        [HttpPost]
        public async Task<IActionResult> ActualizarUsuario(Usuario usuario)
        {
            // Inicializar datos necesarios
            init();

            if (ModelState.IsValid)
            {
                try
                {
                    // Verificar si el correo se ha modificado
                    var usuarioActual = await usuarioBL.ObtenerUsuarioPorIdAsync(usuario.idUsuario);
                    if (usuarioActual != null)
                    {
                        if (usuario.Correo != usuarioActual.Correo)
                        {
                            usuarioActual.Correo = usuario.Correo;
                        }

                        // Verificar si la contraseña se ha modificado
                        if (usuario.Password != usuarioActual.Password)
                        {
                            usuarioActual.Password = Utilidades.EncriptarClave(usuario.Password);
                        }

                        usuarioBL.ActualizarUsuarioDB(usuarioActual);
                        usuarioBL.GuadarCambios();
                    }
                    return RedirectToAction("Usuarios");
                }
                catch (Exception e)
                {
                    TempData["messageTD"] = e.Message;
                    ModelState.AddModelError("new", e.Message);
                    return RedirectToAction("EditarUsuario", new { id = usuario.idUsuario });
                }
            }
            else
            {
                TempData["messageTD"] = "Usuario no válido: " + usuario.idRol.ToString();
                return RedirectToAction("EditarUsuario", new { id = usuario.idUsuario });
            }
        }

        // Acción para eliminar un usuario
        public IActionResult Eliminar(int id)
        {
            Console.WriteLine("id eliminar: " + id);
            usuarioBL.EliminarUsuarioDB(id);
            usuarioBL.GuadarCambios();
            return RedirectToAction("Usuarios");
        }
    }
}
