using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using MVCClinicaMedica.Models;
using MailKit.Net.Smtp;

namespace MVCClinicaMedica.Services
{
    /// <summary>
    /// Clase que implements la interfaz que hicimos recuerdas mijo
    /// tiene que tener todos los metodos de la interfaz.
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Metodo para configurar el envio de un correo electronico
        /// </summary>
        /// <param name="request"></param>
        public void SendEmail(EmailDTO request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Email:UserName").Value));
            email.To.Add(MailboxAddress.Parse(request.Para));
            email.Subject = request.Asunto;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Contenido
            };
            using var smtp = new SmtpClient();
            smtp.Connect(
                _configuration.GetSection("Email:Host").Value,
                Convert.ToInt32(_configuration.GetSection("Email:Port").Value),
                SecureSocketOptions.StartTls
                );
            ///el usuario y contrasena
            smtp.Authenticate(_configuration.GetSection("Email:UserName").Value, _configuration.GetSection("Email:PassWord").Value);
            ///enviamos el correro
            smtp.Send(email);
            ///desconectamos del servicio
            smtp.Disconnect(true);
        }
    }
}
