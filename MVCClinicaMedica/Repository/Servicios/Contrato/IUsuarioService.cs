using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.Models;

namespace MVCClinicaMedica.Repository.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo, string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);

    }
}
