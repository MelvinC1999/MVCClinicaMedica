using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.BusinessLogic
{
    internal class MedicoBL
    {
        MedicoRepo medicoRepo = new MedicoRepo();
        CitasRepo citasRepo = new CitasRepo();
        PacienteRepo pacienteRepo = new PacienteRepo();
        HistoriaClinicaRepo historiaClinicaRepo = new HistoriaClinicaRepo();
        BaseEFContext context = new BaseEFContext();
        public List<Cita> ObtenerCitas()
        {
            return citasRepo.GetAll().ToList();
        }
        
    }
}
