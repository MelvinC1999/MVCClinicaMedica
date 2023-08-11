using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCClinicaMedica.Models;

namespace MVCClinicaMedica.Controllers
{
    [Route("Error/UnauthorizedOperation")]
    public class ErrorController : Controller
    {
        // GET: Error
        [HttpGet]
        public ActionResult UnauthorizedOperation(String operacion, String msjeErrorExcepcion)
        {
            ViewData["Operacion"] = operacion;
            ViewBag.operacion = operacion;
            ViewBag.msjeErrorExcepcion = msjeErrorExcepcion;
            return View();
        }
        
    }
    
}
