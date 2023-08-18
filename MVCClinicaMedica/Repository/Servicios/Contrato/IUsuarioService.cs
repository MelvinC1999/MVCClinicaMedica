using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.Models;

namespace MVCClinicaMedica.Repository.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo, string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);
        Task<Usuario> GetUsuarioAsync(int idUsuario); // Método para obtener un usuario por su ID
        Task UpdateUsuarioAsync(Usuario usuario); // Método para actualizar un usuario
        Task DeleteUsuarioAsync(int idUsuario); // Método para eliminar un usuario por su ID
    }
}
