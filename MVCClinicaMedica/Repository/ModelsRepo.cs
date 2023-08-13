using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using System.Drawing;

namespace MVCClinicaMedica.Repository
{
    internal class MedicoRepo : GenericRepository<Medico> { }
    internal class CitasRepo : GenericRepository<Cita> {
        public List<Cita> ObtenerCitasMedico(int idMedico) 
        {
            using (var context = new BaseEFContext())
            {
                return context.Citas
                    .Include(c => c.Medico)
                    .Include(c => c.Paciente)
                    .Where(c => c.idMedico == 3)
                    .ToList();
            }
        }
        public Cita ObtenerCitaDeep(int idCita)
        {
            using (var context = new BaseEFContext())
            {
                return context.Citas
                .Include(c => c.Paciente)
                .ThenInclude(p => p.RegistrosMedicos)
                .FirstOrDefault(c => c.idCita == idCita);
            }
        }

    }
    //internal class HistoriaClinicaRepo : GenericRepository<HistoriaClinica> { }
    internal class PacienteRepo : GenericRepository<Paciente> { }
    internal class RegistroRepo : GenericRepository<RegistroMedico> { }
}
