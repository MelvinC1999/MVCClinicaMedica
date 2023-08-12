using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCClinicaMedica.Models
{
    [Table("Consultorios")]
    public class Consultorio
    {
        // atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idConsultorio { get; set; }



        [Required(ErrorMessage = "El precio de consulta es requerido")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioConsulta { get; set; }


        // FK

        // tabla hijo de Medico
        public virtual Medico? Medicos { get; set; }
        [ForeignKey("Medico")]
        public int idMedico { get; set; }



        // padre de uno a muchos con la tabla de rompimiento "EquipoMedicoConsultorio"
        public virtual ICollection<EquipoMedicoConsultorio> EquiposMedicosConsultorios { get; set; } = new List<EquipoMedicoConsultorio>();
    }
}