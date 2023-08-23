using Microsoft.AspNetCore.Mvc;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.Controllers
{
    public class MedicoController : Controller
    {
        readonly CitasRepo citasRepo = new CitasRepo();
        readonly MedicoBL medicoBL = new MedicoBL();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string correo)
        {
            int idMedico = medicoBL.ObtenerIdMedicoPorCorreo(correo);

            if (idMedico != -1)
            {
                return RedirectToAction("Index", "Medico", new { id = idMedico });
            }
            else
            {
                ModelState.AddModelError("correo", "El correo no existe.");
                return View();
            }
        }

        public ActionResult Index(int id)
        {
            var citas = citasRepo.ObtenerCitasMedico(id);

            return View(citas);
        }

        public ActionResult DetallesCita(int idCita)
        {
            TempData["idCita"] = idCita;
            return RedirectToAction("Detalles", "Paciente");
        }
    }
}

