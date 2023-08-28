using Microsoft.AspNetCore.Mvc.Rendering;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.BusinessLogic
{
    public class ClienteBL
    {
        GenericRepository<Paciente> pacienteRepo = new GenericRepository<Paciente>();
        public IQueryable<Paciente> todos()
        {
            IQueryable<Paciente> list = pacienteRepo.GetAll();
            return list;
        }
        public ICollection<Paciente> BuscarporCedula(Paciente ced)
        {
            ICollection<Paciente> list = pacienteRepo.ConsultarPorCampo<Paciente>(c => c.Cedula.Equals(ced.Cedula));
            return list;
        }
        //public Paciente BuscarporCedulaCliente(Paciente ced)
        //{
        //    Paciente list = pacienteRepo.ConsultarPorCampo<Paciente>(c => c.Cedula.Equals(ced.Cedula));
        //    return list;
        //}
    }
}
