namespace MVCClinicaMedica.Validador
{
    public static class ValidadorPassword
    {
        public static bool EsPasswordValido(string password)
        {
            // Aquí puedes agregar tus propias reglas de validación para la contraseña
            // Por ejemplo, longitud mínima, mayúsculas, minúsculas, caracteres especiales, etc.
            return !string.IsNullOrEmpty(password) && password.Length >= 8;
        }
    }
}
