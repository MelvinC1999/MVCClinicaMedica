using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.BusinessLogic
{
    public class RolOperacionBL
    {

        private readonly BaseEFContext _dbContext;
        IGenericRepository<RolOperacion> repoRolOperaciones = new GenericRepository<RolOperacion>();
        Rol rol = new Rol();

        public RolOperacionBL()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        /// <summary>
        /// Constructor con parametro
        /// </summary>
        /// <param name="dbContext"></param>
        public RolOperacionBL(BaseEFContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<RolOperacion> retornarRolOperacionesBL()
        {
            List<RolOperacion> listarRolOperaciones = repoRolOperaciones.GetAll().ToList();
            foreach (var item in listarRolOperaciones)
            {
                Console.WriteLine("Id Rol Operacion: |" + item.idRolOperacion + "|" +
                    " Id Rol: |" + item.idRol + "|" + 
                    " Id Operacion: |" + item.idOperacion + "|"); ;
            }
            return listarRolOperaciones;
        }

    }
}
