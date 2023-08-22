using Microsoft.AspNetCore.Mvc;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.Controllers
{
    internal class MedicoController : Controller
    {
        readonly CitasRepo _citasRepo;

        //private readonly BaseEFContext _context;

        public MedicoController(CitasRepo citasRepo)
        {
            _citasRepo = citasRepo;
        }

        public ActionResult Index(int idMedico)
        {
            var citas = _citasRepo.ObtenerCitasMedico(idMedico);
            //var citas = _context.Citas
            //    .Include(c => c.Medico)
            //    .Include(c => c.Paciente)
            //    .Where(c => c.idMedico == 3)
            //    .ToList();

            return View(citas);
        }

        public ActionResult DetallesCita(int idCita)
        {
            TempData["idCita"] = idCita;
            return RedirectToAction("Detalles", "Paciente");
        }
    }
}
