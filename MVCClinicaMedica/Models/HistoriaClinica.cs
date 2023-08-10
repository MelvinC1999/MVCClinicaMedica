using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCClinicaMedica.Models
{
    [Table("HistoriasClinicas")]
    public class HistoriaClinica
    {
        // atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idHistoria { get; set; }

        [Required(ErrorMessage = "El historial es requerido")]
        [StringLength(200)]
        public string? Historial { get; set; }

        // FK
        // tabla hijo de Paciente
        public virtual Paciente? Pacientes { get; set; }
        [ForeignKey("idPaciente")]
        public int idPaciente { get; set; }

    }
}

