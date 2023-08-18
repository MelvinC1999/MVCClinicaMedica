using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using static System.Formats.Asn1.AsnWriter;
using System.Transactions;
using MVCClinicaMedica.BusinessLogic;

namespace MVCClinicaMedica.Controllers
{
    public class UsuarioController : Controller
    {
        BaseEFContext context = new BaseEFContext();
        UsuarioBL usuarioBL = new UsuarioBL();
        RolBL rolBL = new RolBL();
        TransactionScope scope;
        public IActionResult OpcionesAdmin()
        {
            return View();
        }
        public IActionResult Usuarios()
        {
            /// No olvidadar iniciar el init
            init();          
            return View(listaUsuarios());
        }
        public List<Usuario> listaUsuarios()
        {
            return usuarioBL.retornarUsuariosBL();
        }
        /// <summary>
        /// Metodo para iniciar ciertas lista o obtetos cuando es requerido
        /// </summary>
        public void init()
        {
            ///Para mandar los nombres del medico tocara mandar una lista y filtrar el la vista
            var listadoUsuarios = usuarioBL.retornarUsuariosBL();
            ViewData["Usuarios"] = listadoUsuarios;

            var listadoRoles = rolBL.retornarRolesBL();
            ViewData["Roles"] = listadoRoles;
        }
        /// <summary>
        /// Metodo que retorna una vista con el mismo nombre del metodo
        /// es para crear una cita, se inicializan las listas necesarias para los
        /// combos box con el metodo init2();
        /// </summary>
        /// <returns></returns>
        public IActionResult CrearUsuario()
        {
            init2();
            return View();
        }
        public void init2()
        {
            var usuarioVar = usuarioBL.retornarUsuariosBL();
            ViewBag.Usuarios = usuarioBL.retornarUsuariosBL();

            ///
            var usuariosList = usuarioBL.retornarUsuariosBL();
            var itemsUsuarios = usuariosList.Select(p => new SelectListItem
            {
                Value = p.idUsuario.ToString(),
                Text = p.Correo + " " + p.Password + "    Rol: " + p.idRol}).ToList();
            ViewBag.Usuarios = itemsUsuarios;
            ///
            var rolesList = rolBL.retornarRolesBL();
            var itemsRoles = rolesList.Select(p => new SelectListItem
            {
                Value = p.idRol.ToString(),
                Text = p.NombreRol}).ToList();
            ViewBag.Usuarios = itemsRoles;
        }
        //------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Metodo que es para  guardar 
        /// </summary>
        /// <param name="_cita"></param>
        /// <returns></returns>
        // el metodo nos redirige a una html con el nombre Guardar
        public IActionResult GuardarUsuario(Usuario _usuario)
        {
            ///llamamos el metodo para inciciar las listas, falta iniciar lo demas
            init();

            if (ModelState.IsValid)
            {
                Console.WriteLine("Ingresa al model valid"+ _usuario.idUsuario);
                try
                {
                    using (scope = new TransactionScope())
                    {
                        usuarioBL.CrearUsuarioDB(_usuario);
                        usuarioBL.GuadarCambios();
                        scope.Complete();
                    }
                    return RedirectToAction("Usuarios");
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    String mess = e.Message;
                    Console.WriteLine(mess);
                    ///para guardar el mensaje en el temdata, es una forma de usar
                    TempData["messageTD"] = mess;
                    /// este mensaje se esta mostrando en el crear.cshtml <div asp-validation-for="new" class="text-danger">
                    /// es una varibaler new
                    ModelState.AddModelError("new", mess);
                    return RedirectToAction("CrearUsuario");
                }
            }
            /// AQUI impoertante, Pongo este else con lo siguiente para volver a cargar los datos
            /// y enviarlos a la vista de nuevo, porque tiene un return, el init no tiene
            /// por eso loa envio aqui, y porque los envio, porque sino no va a tener opciones y saldar error
            /// ya que no habria opciones ni vlaues, en los otros metodos tambien deberian retornarlo si
            /// se se va a utilizar el combo box en cascada o hacer un metodo que sea como el init pero que 
            /// retorne un objeto CLIENTE
            else
            {
                //String mess = e.Message;
                TempData["messageTD"] = "Usuario no valida: "+ _usuario.idRol.ToString();
                Console.WriteLine("no entra el model");
                return RedirectToAction("CrearUsuario", _usuario);
            }
        }
        /// <summary>
        /// Metodo que devuelve la vista con el mismo nombre del metodo, se inicializan 
        /// las listas con el metodo init2() donde estan los metodos necesarios para que funcionen
        /// los combos box
        /// </summary>
        /// <returns></returns>
        public IActionResult EditarUsuario(Usuario _usuario)
        {
            /// para enviar las listas y busque por eager 
            init();
            /// para inicializar los combo box con las listas
            init2();
            return View(_usuario);
        }
        public IActionResult ActualizarUsuario(Usuario _usuario, int id)
        {
            ///llamamos el metodo para inciciar las listas, falta iniciar lo demas
            init();

            if (ModelState.IsValid)
            {
                Console.WriteLine("Ingresa al model valid: " + _usuario.idUsuario+" id: "+id);
                try
                {
                    using (scope = new TransactionScope())
                    {
                        usuarioBL.ActualizarUsuarioDB(_usuario);
                        usuarioBL.GuadarCambios();
                        scope.Complete();
                    }
                    return RedirectToAction("Citas");
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    String mess = e.Message;
                    Console.WriteLine(mess);
                    ///para guardar el mensaje en el temdata, es una forma de usar
                    TempData["messageTD"] = mess;
                    /// este mensaje se esta mostrando en el crear.cshtml <div asp-validation-for="new" class="text-danger">
                    /// es una varibaler new
                    ModelState.AddModelError("new", mess);
                    return RedirectToAction("EditarUsuario");
                }
            }
            else
            {
                //String mess = e.Message;
                TempData["messageTD"] = "Usuario no valido: " + _usuario.idRol.ToString();
                Console.WriteLine("no entra el model");
                return RedirectToAction("EditarUsuario");
            }
        }
        public IActionResult EliminarUsuario(int id)
        {
            Console.WriteLine("id eliminar: "+ id);
            usuarioBL.EliminarUsuarioDB(id);
            usuarioBL.GuadarCambios();
            return RedirectToAction("Usuarios");
        }
    }
}
