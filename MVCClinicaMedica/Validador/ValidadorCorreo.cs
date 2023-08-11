using System.Text.RegularExpressions;

namespace MVCClinicaMedica.Validador
{
    public static class ValidadorCorreo
    {
        public static bool EsCorreoValido(string correo)
        {
            if (string.IsNullOrEmpty(correo))
                return false;

            // Utiliza una expresión regular para validar el formato del correo
            // Puedes ajustar esta expresión regular según tus necesidades
            string patron = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(correo, patron);
        }
    }
}
