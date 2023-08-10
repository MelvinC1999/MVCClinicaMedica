using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCClinicaMedica.Models
{
    [Table("Perfiles")]
    public class Perfil
    {
        // atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPerfil { get; set; }

        // FK
        // tabla hijo de Usuario
        public virtual Usuario? Usuarios { get; set; }
        [ForeignKey("idUsuario")]
        public int idUsuario { get; set; }

        // tabla hijo de Rol
        public virtual Rol? Roles { get; set; }
        [ForeignKey("idRol")]
        public int idRol { get; set; }
    }
}