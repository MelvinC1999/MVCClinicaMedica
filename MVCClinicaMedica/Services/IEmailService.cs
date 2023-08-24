using MVCClinicaMedica.Models;

namespace MVCClinicaMedica.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}
