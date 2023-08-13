using Microsoft.AspNetCore.Mvc;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.Controllers
{
    public class MedicoController : Controller
    {
        CitasRepo citasRepo = new CitasRepo();

        //private readonly BaseEFContext _context;

        //public MedicoController(BaseEFContext context)
        //{
        //    _context = context;
        //}

        public ActionResult Index(int idMedico)
        {
            var citas = citasRepo.ObtenerCitasMedico(idMedico);
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
