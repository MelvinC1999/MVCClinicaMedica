using MVCClinicaMedica.Models;
using System.Drawing;

namespace MVCClinicaMedica.Repository
{
    internal class MedicoRepo : GenericRepository<Medico> { }
    internal class CitasRepo : GenericRepository<Cita> { }
    //internal class HistoriaClinicaRepo : GenericRepository<HistoriaClinica> { }
    internal class PacienteRepo : GenericRepository<Paciente> { }
    internal class RegistroRepo : GenericRepository<RegistroMedico> { }
}
