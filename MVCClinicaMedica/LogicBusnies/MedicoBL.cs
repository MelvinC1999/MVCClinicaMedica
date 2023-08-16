using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.LogicBusnies
{
    public class MedicoBL
    {
        public MedicoBL() 
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        IGenericRepository<Medico> repoMedico = new GenericRepository<Medico>();
        Medico medico = new Medico();
        BaseEFContext context = new BaseEFContext();
        /// <summary>
        /// Metodo que recupera todos los medicos de la base de datos y los retorna en una LIST
        /// </summary>
        /// <returns></returns>
        public List<Medico> retornarMedicos()
        {
            List<Medico> listarMedicos = repoMedico.GetAll().ToList();
            foreach (var item in listarMedicos)
            {
                Console.WriteLine("Id Medico: |" + item.idMedico + "|" +
                    " Nombre Medico: |" + item.Nombre + "|" +
                    " Apellido Medico: |" + item.Apellido + "|" +
                    " Id Especialidad: |" + item.idEspecialidad + "|");
            }
            return listarMedicos;
        }
        public List<Medico> retornoMedicosEspecialidad()
        {
            // Obtener los datos de los médicos y sus horarios de la base de datos
            var medicos = context.Medicos.Include(m => m.Especialidades).ToList();
            retornoHoariosMedico(medicos);
            //foreach (var item in medicos)
            //{
            //    Console.WriteLine(">Nombre medico()>: " + item.Nombre+"" +
            //        "id: "+ item.idMedico+"" +
            //        "id especialidad: "+item.idEspecialidad+"" +
            //        "espec: "+item.Especialidades);
            //}
            ///
            return medicos;
        }
        public List<string> retornoHoariosMedico(List<Medico> medicosLista)
        {
            var horarios = medicosLista.Select(m => m.Horario).Distinct().ToList();
            foreach (var horario in horarios)
            {
                Console.WriteLine("Horario: " + horario);
            }
            return horarios;
        }
    }
}
