using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using System.Drawing;

namespace MVCClinicaMedica.Repository
{
    internal class MedicoRepo : GenericRepository<Medico> { }
    internal class CitasRepo : GenericRepository<Cita>
    {
        private readonly BaseEFContext _context;

        public CitasRepo()
        {
            _context = new BaseEFContext();
        }

        public List<Cita> ObtenerCitasMedico(int idMedico)
        {
            return _context.Citas
                .Include(c => c.Medicos)
                .Include(c => c.Pacientes)
                .Where(c => c.idMedico == idMedico)  // Usar el parámetro en lugar de un valor fijo
                .ToList();
        }

        public Cita? ObtenerCitaDeep(int idCita)
        {
            return _context.Citas
                .Include(c => c.Pacientes)
                .ThenInclude(p => p.RegistrosMedicos)
                .FirstOrDefault(c => c.idCita == idCita);
        }
    }
    //internal class HistoriaClinicaRepo : GenericRepository<HistoriaClinica> { }
    internal class PacienteRepo : GenericRepository<Paciente> { }
    internal class RegistroRepo : GenericRepository<RegistroMedico> { }
    internal class EspecialidadesRepo : GenericRepository<Especialidad>{ }
}