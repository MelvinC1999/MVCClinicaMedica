using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Bienvenida()
        {
            return View();
        }
        public IActionResult MostrarCita()
        {
            return View();
        }


        // Ver citas-----------------------------


        // solo indica la fecha // idPaciente = 3

        public async Task<IActionResult> VerCitas(int idPaciente, Paciente paciente)
        {
            var dbContext = new BaseEFContext();

            var pacienteBL = new PacienteBL(dbContext);
            var citaBL = new CitaBL(dbContext);
            var medicoBL = new MedicoBL(dbContext);

            var idpacienteCedula = pacienteBL.BuscarPacientePorCedula(paciente.Cedula);

            var pacientesListas = pacienteBL.ObtenerListaPacientePorId(idpacienteCedula);

            var medicosListas = medicoBL.ObtenerListaMedicos();

            foreach ( var item in medicosListas)
            {
                Console.WriteLine(" hola nombre "+item.idMedico);
            }

            Console.WriteLine(paciente.Cedula);

            if (pacientesListas == null)
            {
                return View("PacienteNoEncontrado");
            }

            var citas = await citaBL.ObtenerCitasPorIdPaciente(idpacienteCedula);

            //if (idpacienteCedula == -1)
            //{
            //    Console.WriteLine("Cedula incorrecta. La cedula se tuvo que llenar con -1");

            //}
            //else
            //{
            //    var citas = await citaBL.ObtenerCitasPorIdPaciente(idpacienteCedula);
            //}

        CitasRepo citasRepo = new CitasRepo();

        public ActionResult Detalles()
        {
            int idCita = (int)TempData["idCita"];
            var cita = citasRepo.ObtenerCitaDeep(idCita);
            ViewData["citas"] = citas;
            ViewData["pacientes"] = pacientesListas;
            ViewData["medicos"] = medicosListas;

            return View(citas);
            return View(cita);
        }



    }

}

