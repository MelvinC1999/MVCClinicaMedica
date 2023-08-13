using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.BussinesLogic;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;

namespace MVCClinicaMedica.Controllers
{
    public class FacturasController : Controller
    {
        FacturaBL srvFac;
        ClienteBL srvPac;
        public FacturasController(FacturaBL srvFac, ClienteBL srvPac)
        {
            this.srvFac = srvFac;
            this.srvPac = srvPac;
            Console.WriteLine("Factura controller Constructor Inyection Dependence");
        }
        //private readonly BaseEFContext _dbContext;
        /* public FacturasController(BaseEFContext dbContext)
         {
             _dbContext = dbContext;
         }*/
        public IActionResult Factura()
        {
            //init();
            return View();
        }
        /*public IActionResult Facturass()
        {
            List<Factura> fac = _dbContext.Facturas.ToList();
            return View(fac);
        }*/
        public void init()
        {
            List<Paciente> pacientes = srvPac.todos().ToList();
            ViewBag.Pacientes = pacientes;
        }
        public IActionResult Guardar(Factura factura)
        {
            init();
            srvFac.GuardarFactura(factura);
            return RedirectToAction("Factura");//cambiar luego la vista

        }  
        [HttpPost]
        public IActionResult BuscarCed(Paciente ced)
        {
            ICollection<Paciente> pacientes = srvPac.BuscarporCedula(ced);
            ViewBag.Pacientes = pacientes;
            return View("Factura");
        }
    }
}
