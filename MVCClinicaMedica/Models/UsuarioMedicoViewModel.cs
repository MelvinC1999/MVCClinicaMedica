using System.ComponentModel.DataAnnotations.Schema;

namespace MVCClinicaMedica.Models
{
    [NotMapped]
    public class UsuarioMedicoViewModel
    {
        [NotMapped]
        public Usuario Usuario { get; set; }
        [NotMapped]
        public Medico Medico { get; set; }
    }
}
