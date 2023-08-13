using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCClinicaMedica.Models
{
    [Table("RegistrosMedicos")]
    public class RegistroMedico
    {
        // atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idRegistro { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(200)]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public virtual Paciente? Paciente { get; set; }
        [ForeignKey("Paciente")]
        public int idPaciente { get; set; }
    }
}
