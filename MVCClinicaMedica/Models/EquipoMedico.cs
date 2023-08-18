using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCClinicaMedica.Models
{
    [Table("EquiposMedicos")]
    public class EquipoMedico
    {
        // atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEquipo { get; set; }

        [Column("NombreEquipo")]
        [Required(ErrorMessage = "El nombre de equipo es requerido")]
        [StringLength(50)]
        public string? NombreEquipo { get; set; }

        [Column("DescripcionEquipo")]
        [StringLength(200)]
        public string? DescripcionEquipo { get; set; }


        // padre de uno a muchos con la tabla de rompimiento "EquipoMedicoConsultorio"
        public virtual ICollection<EquipoMedicoConsultorio> EquiposMedicosConsultorios { get; set; } = new List<EquipoMedicoConsultorio>();
    }
}