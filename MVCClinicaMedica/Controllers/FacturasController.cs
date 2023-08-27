using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MVCClinicaMedica.BussinesLogic;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Filtros;
using MVCClinicaMedica.Models;

namespace MVCClinicaMedica.Controllers
{
    [Authorize] //solo accede si el usuario esta autorizado
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
        [AutorizarUsuario(3)] // Permitir idOperacion 1, 2 y 3
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
            return RedirectToAction("CFacturas");//cambiar luego la vista

        }  
        [HttpPost]
        public IActionResult BuscarCed(Paciente ced)
        {
            ICollection<Paciente> pacientes = srvPac.BuscarporCedula(ced);
            ViewBag.Pacientes = pacientes;
            return View("Factura");
        }

        [AutorizarUsuario(3)] // Permitir idOperacion 1, 2 y 3
        public IActionResult CFacturas(Factura factura)
        {
            List<Factura> factu = srvFac.FacturaEager().ToList();
            return View("CFacturas", factu);
        }
        [HttpPost]
        public IActionResult eliminarFactura(int idfac)
        {
            Console.WriteLine("yo soy el idfact a eliminar" + idfac);
            srvFac.EliminarID(idfac);
            return RedirectToAction("CFacturas");
        }
    }
}
