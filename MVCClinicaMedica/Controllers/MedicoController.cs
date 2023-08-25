using Microsoft.AspNetCore.Mvc;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.Repository;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using MVCClinicaMedica.Session;

namespace MVCClinicaMedica.Controllers
{
    public class MedicoController : Controller
    {
        readonly CitasRepo citasRepo = new CitasRepo();
        readonly MedicoBL medicoBL = new MedicoBL();
        [HttpGet]
        public ActionResult Login()
        {
            var loginViewModel = new LoginViewModel();
            loginViewModel.IdMedico = HttpContext.Session.GetInt32("idMedico");
            loginViewModel.CitasMedico = HttpContext.Session.Get<List<Cita>>("citasMedico");

            return View(loginViewModel);
        }

        [HttpPost]
        public ActionResult Login(string correo)
        {
            try
            {
                int idMedico = medicoBL.ObtenerIdMedicoPorCorreo(correo);
                var citas = citasRepo.ObtenerCitasMedico(idMedico);

                HttpContext.Session.SetInt32("idMedico", idMedico);
                HttpContext.Session.SetObjectAsJson("citasMedico", citas);

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                var loginViewModel = new LoginViewModel
                {
                    ErrorMessage = ex.Message
                };

                return View("Login", loginViewModel);
            }
        }


        public ActionResult Detalles(int idCita)
        {
            var cita = citasRepo.ObtenerCitaDeep(idCita);

            return View(cita);
        }
    }
}

