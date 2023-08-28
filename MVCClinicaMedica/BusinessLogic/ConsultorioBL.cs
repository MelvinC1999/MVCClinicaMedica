using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.BusinessLogic
{
    public class ConsultorioBL
    {
        GenericRepository<Consultorio> consulRepo = new GenericRepository<Consultorio>();
        public Consultorio ObtenerConsultorioPorMed(int idMed)
        {
            Console.WriteLine("idMed: "+idMed);
            CrearConsultorio(idMed);
            var ConsultorioMedico = ObtenerConsultorioPorIdMedico(idMed);
            Console.WriteLine("medico.Cosultorio: "+ ConsultorioMedico.idMedico);
            return ConsultorioMedico;
        }
        public void CrearConsultorio(int idMedico)
        {
            Consultorio cosultorio = new Consultorio();
            cosultorio.PrecioConsulta = 20;
            cosultorio.idMedico = idMedico;
            consulRepo.Add(cosultorio);
            consulRepo.SaveChanges();
            //return cosultorio;
        }
        public Consultorio ObtenerConsultorioPorIdMedico(int id)
        {
            Consultorio consultorioEncontrado = null;
            List<Consultorio> listaConsultorio = new List<Consultorio>();
            listaConsultorio = consulRepo.GetAll().ToList();

            for (int i = 0; i < listaConsultorio.Count; i++)
            {
                if (listaConsultorio[i].idMedico == id)
                {
                    consultorioEncontrado = listaConsultorio[i];
                    break;
                }
            }

            return consultorioEncontrado;
        }
    }
}
