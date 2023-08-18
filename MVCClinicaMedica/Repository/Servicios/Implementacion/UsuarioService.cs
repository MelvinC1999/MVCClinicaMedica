using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Repository.Servicios.Contrato;

namespace MVCClinicaMedica.Repository.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly BaseEFContext _dbContext;

        public UsuarioService(BaseEFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios
                .Where(u => u.Correo == correo && u.Password == clave)
                .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<Usuario> GetUsuarioAsync(int idUsuario)
        {
            return await _dbContext.Usuarios.FindAsync(idUsuario);
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            _dbContext.Entry(usuario).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUsuarioAsync(int idUsuario)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(idUsuario);
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
