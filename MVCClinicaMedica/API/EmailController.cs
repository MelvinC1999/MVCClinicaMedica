using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Services;

namespace MVCClinicaMedica.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        ///Metodo para enviar el correo
        [HttpPost]
        public IActionResult SendEmail(EmailDTO request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }
        // GET: api/<ApiController>
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<EmailDTO> GetEmails()
        {
            /// aqui se puede obtener la lista de los pacientes con un objeto BUSNIESLOGIC
            /// y con ese metodo obtener la lista y con un foreach ir llenando sus porpiedades
            /// para retornar la lista de correos, pero ya deberian estar quemados los asusntos?
            var emails = new List<EmailDTO>
           {
                new EmailDTO{Para="edyykart@gmail.com", Asunto="hola viejo", Contenido="es contenido quemado"},
                new EmailDTO{Para="edyykart@gmail.com", Asunto="Parce", Contenido="que hay viejo."}
           };

            return emails;
        }
        /// <summary>
        /// Enviamos un correo electronico por la vista de usuario
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[controller]/enviarEmail/")]
        [Consumes("application/json")]
        public EmailDTO Post([FromBody] EmailDTO email)
        {
            Console.WriteLine("Post Method EMAIL Controller:");
            Console.WriteLine("Para: " + email.Para);
            Console.WriteLine("Asunto: " + email.Asunto);
            Console.WriteLine("Contenido: " + email.Contenido);
            ///con esto mando a enviar el correo electronico
            _emailService.SendEmail(email);
            //return Ok();
            ///
            return email;
        }
    }
}
