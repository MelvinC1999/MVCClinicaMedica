namespace MVCClinicaMedica.Utilitario
{
    public class InvalidClientException : Exception
    {
        public InvalidClientException() { }

        public InvalidClientException(string message)
            : base(string.Format("Cliente: {0}", message))
        {

        }
    }
}
