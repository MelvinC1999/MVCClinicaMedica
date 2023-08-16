using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;
using MVCClinicaMedica.Validador;

namespace MVCClinicaMedica.LogicBusnies
{
    public class PacienteBL
    {
        public PacienteBL() 
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        IGenericRepository<Paciente> repoPaciente = new GenericRepository<Paciente>();
        Paciente paciente = new Paciente();
        BaseEFContext context = new BaseEFContext();
        public List<Paciente> retornarPacientesBL()
        {
            List<Paciente> listarPacientes = repoPaciente.GetAll().ToList();
            foreach (var item in listarPacientes)
            {
                Console.WriteLine("Id Paciente: |" + item.idPaciente + "|" +
                    " Nombre: |" + item.Nombre + "|" +
                    " Apellido: |" + item.Apellido + "|" +
                    " Cedula: |" + item.Cedula + "|");
            }
            return listarPacientes;
        }
    }
}
