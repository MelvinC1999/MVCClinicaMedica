using Microsoft.EntityFrameworkCore; // Importa las clases para Entity Framework
using MVCClinicaMedica.DBContext; // Importa el contexto de la base de datos
using MVCClinicaMedica.Models; // Importa las clases de modelos
using MVCClinicaMedica.Repository; // Importa el repositorio genérico

namespace MVCClinicaMedica.BusinessLogic
{
    public class UsuarioBL
    {
        private readonly BaseEFContext _dbContext; // Contexto de la base de datos
        IGenericRepository<Usuario> repoUsuario = new GenericRepository<Usuario>(); // Repositorio genérico para la entidad Usuario
        Usuario usuario = new Usuario(); // Instancia de Usuario

        /// <summary>
        /// Constructor sin parámetros
        /// </summary>
        public UsuarioBL()
        {
            Console.ForegroundColor = ConsoleColor.Green; // Configura el color de la consola en verde
        }

        /// <summary>
        /// Constructor con parámetro
        /// </summary>
        /// <param name="dbContext">El contexto de la base de datos</param>
        public UsuarioBL(BaseEFContext dbContext)
        {
            _dbContext = dbContext; // Asigna el contexto de la base de datos al campo _dbContext
        }

        // Método para obtener una lista de usuarios por su ID
        public async Task<List<Usuario>> ObtenerUsuariosPorId(int idUsuario)
        {
            return await _dbContext.Usuarios.Where(c => c.idUsuario == idUsuario).ToListAsync();
        }

        // Método para obtener un usuario por su ID de forma asíncrona
        public async Task<Usuario> ObtenerUsuarioPorIdAsync(int idUsuario)
        {
            Usuario usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(c => c.idUsuario == idUsuario);
            return usuario;
        }

        // Retorna una lista de usuarios
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

        // Método para crear un nuevo usuario en la base de datos
        public void CrearUsuarioDB(Usuario _usuario)
        {
            //Validaciones
            if (true) // ¡Nota! Aquí debería haber una validación real
            {
                repoUsuario.Add(_usuario);
                Console.WriteLine("Usuario: |" + _usuario.idUsuario + "| insertado correctamente.");
            }
        }

        // Método para actualizar un usuario en la base de datos
        public void ActualizarUsuarioDB(Usuario _usuario)
        {
            var existingUsuario = _dbContext.Usuarios.Local.FirstOrDefault(u => u.idUsuario == _usuario.idUsuario);

            if (existingUsuario == null)
            {
                _dbContext.Usuarios.Attach(_usuario);
            }
            else
            {
                existingUsuario.Correo = _usuario.Correo;
                if (!string.IsNullOrEmpty(_usuario.Password))
                {
                    existingUsuario.Password = _usuario.Password;
                }
            }

            _dbContext.Entry(existingUsuario).State = EntityState.Modified;
            _dbContext.SaveChanges();
            Console.WriteLine("Usuario: |" + _usuario.idUsuario + "| actualizado correctamente.");
        }

        // Método para eliminar un usuario de la base de datos
        public void EliminarUsuarioDB(int id)
        {
                usuario = repoUsuario.Get(id);
                repoUsuario.HardDelete(usuario);
                Console.WriteLine("Usuario: |" + usuario.idUsuario + "| eliminado correctamente.");
        }

        // Método para guardar los cambios en la base de datos
        public void GuadarCambios()
        {
            repoUsuario.SaveChanges();
            Console.WriteLine("Guardado Correctamente :)");
        }
    }
}
