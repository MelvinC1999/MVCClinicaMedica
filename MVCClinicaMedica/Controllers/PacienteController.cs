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






    }



}

