using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.BusinessLogic
{
    public class UsuarioBL
    { 
        private readonly BaseEFContext _dbContext;
        IGenericRepository<Usuario> repoUsuario = new GenericRepository<Usuario>();
        Usuario usuario = new Usuario();

        /// <summary>
        /// Construcctor sin parametros
        /// </summary>
        public UsuarioBL()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        /// <summary>
        /// Constructor con parametro
        /// </summary>
        /// <param name="dbContext"></param>
        public UsuarioBL(BaseEFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Usuario>> ObtenerUsuariosPorId(int idUsuario)
        {
            return await _dbContext.Usuarios.Where(c => c.idUsuario == idUsuario).ToListAsync();
        }


        public async Task<Usuario> ObtenerUsuarioPorId(int idUsuario)
        {
            return await _dbContext.Usuarios.FindAsync(idUsuario);
        }
        ///************************************************************KART LINUX ****************************************

        /// <summary>
        /// Se retorna un lista con las citas que existen en la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Usuario> retornarUsuariosBL()
        {
            List<Usuario> listarUsuarios = repoUsuario.GetAll().ToList();
            foreach (var item in listarUsuarios)
            {
                Console.WriteLine("Id Usuario: |" + item.idUsuario + "|" +
                    " Correo: |" + item.Correo + "|" +
                    " Password |" + item.Password + "|" +
                    " Id Rol: |" + item.idRol + "|");
            }
            return listarUsuarios;
        }
        /// <summary>
        /// Metodo que crea un cita en la base de datos cuando se le pasa
        /// como parametro un Objeto de tipo CITA
        /// </summary>
        /// <param name="_cita"></param>
        public void CrearUsuarioDB(Usuario _usuario)
        {
            //Validaciones
            if (true)
            {
                repoUsuario.Add(_usuario);
                Console.WriteLine("Usuario: |" + _usuario.idUsuario + "| insertado correctamente.");
            }
        }
        /// <summary>
        /// Metodo que actualiza la cita, el id se lo trae en el formulario como tipo hidden 
        /// para que tome el ide de la cita junto con el objeto, porque si no tiene el id se manda 
        /// a crear en vez de actualizar
        /// </summary>
        /// <param name="_cita"></param>
        public void ActualizarUsuarioDB(Usuario _usuario)
        {
            if (true)
            {
                repoUsuario.Update(_usuario);
                Console.WriteLine("Usuario: |" + _usuario.idUsuario + "| actualizado correctamente.");
            }
        }
        public void EliminarUsuarioDB(int id)
        {
            if (true)
            {
                usuario = repoUsuario.Get(id);
                repoUsuario.HardDelete(usuario);
                Console.WriteLine("Usuario: |" + usuario.idUsuario + "| eliminada correctamente.");
            }
        }
        /// <summary>
        /// Metodo para guardar los cambios
        /// </summary>
        public void GuadarCambios()
        {
            repoUsuario.SaveChanges();
            Console.WriteLine("Guardado Positivamente :)");
        }
        ///***************************************************************************************************************


    }
}
