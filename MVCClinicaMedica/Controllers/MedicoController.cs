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
            ViewBag.idMedico = idMedico;

            var citas = citasRepo.ObtenerCitasMedico(idMedico);
            ViewBag.citasMedico = citas;
            return View();
        }

        public ActionResult Detalles(int idCita)
        {
            ViewBag.idCita = idCita;
            var cita = citasRepo.ObtenerCitaDeep(idCita);
            return View(cita);
        }
        //public ActionResult Index()
        //{
        //    var idMedico = (int)ViewBag.idMedico;
        //    var citas = citasRepo.ObtenerCitasMedico(idMedico);

        //    return PartialView("_IndexPartial", citas);
        //}

        //public ActionResult DetallesCita(int idCita)
        //{
        //    TempData["idCita"] = idCita;
        //    return RedirectToAction("Detalles");
        //}
    }
}

