using Microsoft.AspNetCore.Mvc;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCClinicaMedica.Controllers
{
    public class PacienteController : Controller
    {
        private readonly BaseEFContext _context;

        public PacienteController(BaseEFContext context)
        {
            _context = context;
        }

        public ActionResult Detalles()
        {
            int idCita = (int)TempData["idCita"];
            var cita = _context.Citas
                .Include(c => c.Paciente)
                .ThenInclude(p => p.RegistrosMedicos)
                .FirstOrDefault(c => c.idCita == idCita);

            return View(cita);
        }
    }
}
