using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCClinicaMedica.Models
{
    [Table("Medicos")]
    public class Medico
    {
        // atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idMedico { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(50)]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido")]
        [StringLength(15)]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Ingrese una dirección de correo válida")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "El horario es requerido")]
        [StringLength(20)]
        public string? Horario { get; set; }

        // FK
        // tabla hijo de Especialidad
        public virtual Especialidad? Especialidades { get; set; }
        [ForeignKey("Especialidad")]
        public int idEspecialidad { get; set; }

        
    }
}