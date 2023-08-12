using Microsoft.AspNetCore.Mvc;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCClinicaMedica.Controllers
{
    public class MedicoController : Controller
    {
        private readonly BaseEFContext _context;

        public MedicoController(BaseEFContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var citas = _context.Citas
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .ToList();

            return View(citas);
        }

        public ActionResult DetallesCita(int idCita)
        {
            TempData["idCita"] = idCita;
            return RedirectToAction("Detalles", "Paciente");
        }
    }
}
