using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCClinicaMedica.Models
{
    [Table("Especialidades")]
    public class Especialidad
    {
        // atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEspecialidad { get; set; }

        [Column("Descripcion")]
        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(100)]
        public string? Descripcion { get; set; }
    }

}
