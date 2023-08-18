using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.BusinessLogic
{
    public class RolBL
    {
        private readonly BaseEFContext _dbContext;
        IGenericRepository<Rol> repoRol = new GenericRepository<Rol>();
        Rol rol = new Rol();

        public RolBL()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        /// <summary>
        /// Constructor con parametro
        /// </summary>
        /// <param name="dbContext"></param>
        public RolBL(BaseEFContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Rol> retornarRolesBL()
        {
            List<Rol> listarRoles = repoRol.GetAll().ToList();    
            foreach (var item in listarRoles)
            {
                Console.WriteLine("Id Rol: |" + item.idRol + "|" +
                    " Nombre: |" + item.NombreRol + "|"); ;
            }
            return listarRoles;
        }

    }
}
