using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCClinicaMedica.Models
{
    [Table("Roles")]
    public class Rol
    {
        // atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idRol { get; set; }

        [Required(ErrorMessage = "El nombre de rol es requerido")]
        [StringLength(50)]
        public string? NombreRol { get; set; }

        //Relacion uno a muchos
        public virtual ICollection<RolOperacion> RolOperaciones { get; set; } = new List<RolOperacion>();

        //Relacion uno a muchos
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
