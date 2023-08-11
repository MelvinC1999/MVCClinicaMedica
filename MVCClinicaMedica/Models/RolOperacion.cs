using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCClinicaMedica.Models
{
    [Table("Rol_Operaciones")]
    public class RolOperacion
    {
        // atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idRolOperacion { get; set; }

        [Column("idRol")]
        public int idRol { get; set; }
        //Relacion muchos a uno 
        [ForeignKey("idRol")]
        public virtual Rol? Roles { get; set; }

        [Column("idOperacion")]
        public int idOperacion { get; set; }
        //Relacion muchos a uno 
        [ForeignKey("idOperacion")]
        public virtual Operacion? Operaciones { get; set; }

    }
}