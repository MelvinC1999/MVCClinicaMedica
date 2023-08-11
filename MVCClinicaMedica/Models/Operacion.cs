using Azure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCClinicaMedica.Models
{
    [Table("Operaciones")]
    public class Operacion
    {
        // atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idOperacion { get; set; }

        [Required(ErrorMessage = "El nombre de la operacion es requerido")]
        [StringLength(50)]
        public string? NombreOperacion { get; set; }

        //Relacion uno a muchos
        public virtual ICollection<RolOperacion> RolOperaciones { get; set; } = new List<RolOperacion>();
    }
}
