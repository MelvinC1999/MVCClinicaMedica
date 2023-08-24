using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.BussinesLogic;
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



        // Ver citas-----------------------------

        public async Task<IActionResult> VerCitas(int idPaciente, Paciente paciente)
        {
            var dbContext = new BaseEFContext();

            var pacienteBL = new PacienteBL(dbContext);
            var citaBL = new CitaBL(dbContext);
            var medicoBL = new MedicoBL(dbContext);
            var especialidadBL = new EspecialidadBL(dbContext);

            var idpacienteCedula = pacienteBL.BuscarPacientePorCedula(paciente.Cedula);
            var pacientesListas = pacienteBL.ObtenerListaPacientePorId(idpacienteCedula);
            var medicosListas = medicoBL.ObtenerListaMedicos();
            var especialidadesListas = especialidadBL.ObtenerListaEspecialidades();

            foreach (var item in medicosListas)
            {
                Console.WriteLine(" hola nombre " + item.idMedico);
            }

            Console.WriteLine(paciente.Cedula);

            //cambio

            if (!pacienteBL.CedulaEsValida(paciente.Cedula))
            {
                ViewBag.Advertencia = "Ingresa una cédula válida.";
            }

            if (pacientesListas == null)
            {
                ViewBag.Mensaje = "Ingresar una cédula válida"; // Establecer mensaje de advertencia
            }

            var citas =  citaBL.ObtenerCitasPorIdPaciente(idpacienteCedula);
            ViewData["citas"] = citas;
            ViewData["pacientes"] = pacientesListas;
            ViewData["medicos"] = medicosListas;
            ViewData["especialidades"] = especialidadesListas;
            ViewBag.Citas = citas;
            return View(citas);
        }

        [HttpPost]
        public IActionResult BuscarCedulaPaciente(Paciente ced)
        {
            int idPaciente = pacienteBL.BuscarPacientePorCedula(ced.Cedula);
            var pacientesListas = pacienteBL.ObtenerListaPacientePorId(idPaciente);
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






    }



}

