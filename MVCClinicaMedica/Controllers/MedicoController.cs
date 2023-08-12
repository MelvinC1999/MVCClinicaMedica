using Microsoft.AspNetCore.Mvc;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using System.Linq;

namespace MVCClinicaMedica.Controllers
{
    public class MedicoController : Controller
    {
        private readonly BaseEFContext _context;

        public MedicoController(BaseEFContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Supongamos que tienes el ID del médico actual (ajusta esto según tu lógica)
            int idMedico = 1;

            var viewModel = new MedicoCitasViewModel
            {
                Citas = _context.Citas.Where(c => c.idMedico == idMedico).ToList(),
                Medico = _context.Medicos.FirstOrDefault(m => m.idMedico == idMedico)
            };

            return View(viewModel);
        }
    }
}
