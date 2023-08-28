using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.BusinessLogic;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Servicios.Contrato;
using MVCClinicaMedica.Utilitario;
using System;
using System.Security.Claims;

namespace MVCClinicaMedica.Controllers
{
    public class PacienteController : Controller
    {
        ClienteBL srvPac = new ClienteBL();
        PacienteBL pacienteBL = new PacienteBL();
        CitaBL _citaBL = new CitaBL();
        MedicoBL medicoBL = new MedicoBL();
        EspecialidadBL especialidadBL = new EspecialidadBL();

        public IActionResult Bienvenida()
        {
            return View();
        }
        public IActionResult MostrarCita()
        {
            return View();
        }


        [HttpPost]
        public IActionResult BuscarCedulaPaciente(Paciente ced)
        {
            int idPaciente = pacienteBL.BuscarPacientePorCedula(ced.Cedula);
            var pacientesListas = pacienteBL.RetornarListaPacientePorId(idPaciente);
            var citasLista = _citaBL.ObtenerCitasPorIdPaciente(idPaciente);
            var medicosListas = medicoBL.ObtenerListaMedicos();
            var especialidadesListas = especialidadBL.ObtenerListaEspecialidades();


            ViewBag.Citas = citasLista;
            ViewData["citas"] = citasLista;
            ViewData["pacientes"] = pacientesListas;
            ViewData["medicos"] = medicosListas;
            ViewData["especialidades"] = especialidadesListas;



            return View("Bienvenida");
        }



        //Vista UsuarioPaciente

        public IActionResult UsuarioPaciente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UsuarioPaciente(Paciente paciente)
        {
            if (ModelState.IsValid)
            {

                //Para probar que valga

                BaseEFContext _dbContext  = new BaseEFContext();


                // Guardar los datos del paciente en la base de datos
                _dbContext.Pacientes.Add(paciente);
                _dbContext.SaveChanges();

                // Redirigir a una página de éxito o realizar otras acciones
                return RedirectToAction("RegistroExitoso");
            }

            // Si el modelo no es válido, regresar a la vista con los errores
            return View();
        }







    }



}

