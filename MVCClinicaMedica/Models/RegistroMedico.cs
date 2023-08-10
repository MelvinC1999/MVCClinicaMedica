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
        [StringLength(1000)]
        public string? Descripcion { get; set; }


        // FK
        // Tabla hija de HistoriaClinica
        public virtual HistoriaClinica? HistoriasClinicas { get; set; }
        [ForeignKey("idHistoriaClinica")]
        public int idHistoria { get; set; }
    }
}
