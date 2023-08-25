using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.BusinessLogic
{
    public class ConsultorioBL
    {
        GenericRepository<Consultorio> consulRepo = new GenericRepository<Consultorio>();
        public Consultorio ObtenerConsultorioPorMed(int idMed)
        {
            var medico = consulRepo.Get(idMed);
            return medico;
        }
    }
}
