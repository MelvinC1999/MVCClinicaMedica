using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using static System.Formats.Asn1.AsnWriter;
using System.Transactions;
using MVCClinicaMedica.BusinessLogic;
using MVCClinicaMedica.BussinesLogic;

namespace MVCClinicaMedica.Controllers
{
    public class AdminController : Controller
    {
        BaseEFContext context = new BaseEFContext();
        CitaBL citaBL = new CitaBL();
        MedicoBL medicoBL = new MedicoBL(); 
        PacienteBL pacienteBL = new PacienteBL();
        TipoPagoBL pagoBL = new TipoPagoBL();
        ConsultorioBL cons = new ConsultorioBL();
        TransactionScope scope;
        public IActionResult OpcionesAdmin()
        {
            return View();
        }
     
        public IActionResult Citas()
        {
            ///No olvidadar iniciar el init
            init();
            ///
            return View(listaCitas());
        }
        public List<Cita> listaCitas()
        {
            return citaBL.retornarCitasBL();
        }
        /// <summary>
        /// Metodo para iniciar ciertas lista o obtetos cuando es requerido
        /// </summary>
        public void init()
        {
            ///Para mandar los nombres del medico tocara mandar una lista y filtrar el la vista
            var listadoMedicos = medicoBL.retornarMedicos();
            ViewData["Medicos"] = listadoMedicos;
            ///Para mandar los nombres de los pacientes en una lista y se filtren en la vista con el ID
            var listadoPacientes = pacienteBL.retornarPacientesBL();
            ViewData["Pacientes"] = listadoPacientes;
            ///Para mandar los nombres de los pagos en una lista y se filtren en la vista con el ID
            var listadoPagos = pagoBL.retornarPagosBL();
            ViewData["TipoPagos"] = listadoPagos;
        }
        /// <summary>
        /// Metodo que retorna una vista con el mismo nombre del metodo
        /// es para crear una cita, se inicializan las listas necesarias para los
        /// combos box con el metodo init2();
        /// </summary>
        /// <returns></returns>
        public IActionResult CrearCita()
        {
            init2();
            return View();
        }
        public void init2()
        {
            var medicosVar = medicoBL.retornoMedicosEspecialidad();
            ViewBag.Medicos = medicoBL.retornoMedicosEspecialidad();
            ViewBag.Horarios = medicoBL.retornoHoariosMedico(medicosVar);
            var horarios = medicoBL.retornoHoariosMedico(medicosVar);
            ///
            var pacientsList = pacienteBL.retornarPacientesBL();
            var itemsPacientes = pacientsList.Select(p => new SelectListItem
            {
                Value = p.idPaciente.ToString(),
                Text = p.Nombre + " " + p.Apellido + " Cedula: " + p.Cedula + " Email: " + p.Correo
            }).ToList();
            ViewBag.Pacientes = itemsPacientes;
            ///
            var pagosList = pagoBL.retornarPagosBL();
            var itemsPagos = pagosList.Select(p => new SelectListItem
            {
                Value = p.idTipoPago.ToString(),
                Text = p.Descripcion
            }).ToList();
            ViewBag.TipoPagos = itemsPagos;
        }
        //------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Metodo que es para  guardar 
        /// </summary>
        /// <param name="_cita"></param>
        /// <returns></returns>
        // el metodo nos redirige a una html con el nombre Guardar
        public IActionResult GuardarCita(Cita _cita)
        {
            ///llamamos el metodo para inciciar las listas, falta iniciar lo demas
            init();

            if (ModelState.IsValid)
            {
                Console.WriteLine("Ingresa al model valid"+ _cita.idPaciente);
                var ced = pacienteBL.ObtenerListaPacientePorId(_cita.idPaciente);
                var consu = cons.ObtenerConsultorioPorMed(_cita.idMedico);
                string cedulla=ced.Cedula;
                try
                {
                    using (scope = new TransactionScope())
                    {
                        citaBL.CrearCitaDB(_cita);
                        citaBL.GuadarCambios();
                        scope.Complete();
                    }
                    //usamos redirect para enviar a vistas fuera de este controlador y carpeta
                    //primero accion luego controlador
                    return RedirectToAction("Factura","Facturas",new { idpac=ced.idPaciente, cedula = cedulla, paciente=ced.Nombre, idcit=_cita.idCita, idConsul=consu.idConsultorio, precio=consu.PrecioConsulta });
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
                    return RedirectToAction("CrearCita");
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
                TempData["messageTD"] = "Cita no valida: "+_cita.Fecha.ToString();
                Console.WriteLine("no entra el model");
                return RedirectToAction("CrearCita", _cita);
            }
        }
        /// <summary>
        /// Metodo que devuelve la vista con el mismo nombre del metodo, se inicializan 
        /// las listas con el metodo init2() donde estan los metodos necesarios para que funcionen
        /// los combos box
        /// </summary>
        /// <returns></returns>
        public IActionResult EditarCita(Cita _cita)
        {
            /// para enviar las listas y busque por eager 
            init();
            /// para inicializar los combo box con las listas
            init2();
            return View(_cita);
        }
        public IActionResult ActualizarCita(Cita _cita, int id)
        {
            ///llamamos el metodo para inciciar las listas, falta iniciar lo demas
            init();

            if (ModelState.IsValid)
            {
                Console.WriteLine("Ingresa al model valid: " + _cita.idCita+" id: "+id);
                try
                {
                    using (scope = new TransactionScope())
                    {
                        citaBL.ActualizarCitaDB(_cita);
                        citaBL.GuadarCambios();
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
                    return RedirectToAction("EditarCita");
                }
            }
            else
            {
                //String mess = e.Message;
                TempData["messageTD"] = "Cita no valida: " + _cita.Fecha.ToString();
                Console.WriteLine("no entra el model");
                return RedirectToAction("EditarCita");
            }
        }
        public IActionResult EliminarCita(int id)
        {
            Console.WriteLine("id eliminar: "+ id);
            citaBL.EliminarCitaDB(id);
            citaBL.GuadarCambios();
            return RedirectToAction("Citas");
        }
        ///------------------------------------------------------------------------------------------------
        //NOTIFIACIONES
        public IActionResult Notificaciones()
        {
            return View();
        }
    }
}
