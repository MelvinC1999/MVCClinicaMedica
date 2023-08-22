using System;

namespace MVCClinicaMedica.Utilitario
{
    public class UsuarioException : Exception
    {
        public UsuarioException(string message) : base(message)
        {
        }
    }
}
