using MVCClinicaMedica.Controllers;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.BusinessLogic
{
    internal class MedicoBL
    {

        MedicoRepo medicoRepo = new MedicoRepo();
        PacienteRepo pacienteRepo = new PacienteRepo();


        public List<Cita> ObtenerCitasMedico(int idMedico)
        {
            var medico = medicoRepo.Get(idMedico);

            return medico.Citas.ToList();
        }
        public List<RegistroMedico> ObtenerRegistros(int idPaciente)
        {
            var paciente = pacienteRepo.Get(idPaciente);
            return paciente.RegistrosMedicos.ToList();
        }
        public void ImprimirRegistrosDePaciente(int idPaciente)
        {
            var paciente = pacienteRepo.Get(idPaciente);
            var registros = paciente.RegistrosMedicos.ToList();
            foreach (var registro in registros)
            {
                Console.WriteLine($"id : {registro.idRegistro} descripcion: {registro.Descripcion}");
            }
        }
        public void ImprimirCitasDeMedico(int idMedico)
        {
            var medico = medicoRepo.Get(idMedico);
            var citas = medico.Citas.ToList();
            foreach (var cita in citas)
            {
                Console.WriteLine($"id : {cita.idCita} Fecha: {cita.Fecha} Medico: {cita.idMedico} Paciente: {cita.idPaciente}");
            }
        }


    }
}
