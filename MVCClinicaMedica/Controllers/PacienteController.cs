using Microsoft.AspNetCore.Mvc;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.Controllers
{
    public class PacienteController : Controller
    {
        //private readonly BaseEFContext _context;

        //public PacienteController(BaseEFContext context)
        //{
        //    _context = context;
        //}

        CitasRepo citasRepo = new CitasRepo();

        public ActionResult Detalles()
        {
            int idCita = (int)TempData["idCita"];
            var cita = citasRepo.ObtenerCitaDeep(idCita);

            return View(cita);
        }
    }
}
