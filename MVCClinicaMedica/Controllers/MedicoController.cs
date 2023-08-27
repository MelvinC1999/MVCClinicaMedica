﻿using Microsoft.AspNetCore.Mvc;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.Repository;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using MVCClinicaMedica.Session;
using Microsoft.AspNetCore.Authorization;
using MVCClinicaMedica.Filtros;

namespace MVCClinicaMedica.Controllers

{
    [Authorize]
    public class MedicoController : Controller
    {
        readonly CitasRepo citasRepo = new CitasRepo();
        readonly MedicoBL medicoBL = new MedicoBL();
        readonly EspecialidadBL especialidadBL = new EspecialidadBL();

        [HttpGet]
        [AutorizarUsuario(2)]
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

        [HttpGet]
        public IActionResult RegistrarMedico()
        {
            ViewBag.Especialidades = especialidadBL.ObtenerListaEspecialidades(); // Obtén la lista de especialidades desde donde sea que las tengas
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarMedico(Medico medico)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    medicoBL.CrearMedico(medico);
                    // Agregar mensaje de éxito si es necesario
                    return RedirectToAction("Login");
                }
                catch (Exception ex)
                {
                    ViewData["Mensaje"] = ex.Message;
                }
            }

            ViewBag.Especialidades = especialidadBL.ObtenerListaEspecialidades(); // Obtén la lista de especialidades nuevamente
            return View(medico);
        }


        [HttpPost]
        public IActionResult AgregarRegistro(int idCita, string descripcion)
        {
            try
            {
                var cita = citasRepo.Get(idCita); // Obtén la cita utilizando el idCita

                if (cita != null)
                {
                    var nuevoRegistro = new RegistroMedico
                    {
                        Descripcion = descripcion,
                        Fecha = DateTime.Now,
                        idPaciente = cita.idPaciente
                    };

                    medicoBL.CrearRegistroMedico(nuevoRegistro);

                    // Puedes agregar un mensaje de éxito si es necesario
                }
                else
                {
                    // Manejar caso si la cita no existe
                }

                return RedirectToAction("Detalles", new { idCita });
            }
            catch (Exception ex)
            {
                // Manejar el error si ocurre
                ViewData["Mensaje"] = ex.Message;
                var cita = citasRepo.Get(idCita);
                return View("Detalles", cita);
            }
        }


    }


}

