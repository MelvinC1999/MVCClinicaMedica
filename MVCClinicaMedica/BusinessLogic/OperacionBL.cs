using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.BusinessLogic
{
    public class OperacionBL
    {

        private readonly BaseEFContext _dbContext;
        IGenericRepository<Operacion> repoOperacion = new GenericRepository<Operacion>();
        Operacion operacion = new Operacion();

        public OperacionBL()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        /// <summary>
        /// Constructor con parametro
        /// </summary>
        /// <param name="dbContext"></param>
        public OperacionBL(BaseEFContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Operacion> retornarOperacionesBL()
        {
            List<Operacion> listarOperaciones = repoOperacion.GetAll().ToList();
            foreach (var item in listarOperaciones)
            {
                Console.WriteLine("Id Operacion: |" + item.idOperacion + "|" +
                    " Nombre Operacion: |" + item.NombreOperacion + "|"); ;
            }
            return listarOperaciones;
        }

    }
}
