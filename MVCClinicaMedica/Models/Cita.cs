using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCClinicaMedica.Models
{
    [Table("Citas")]
    public class Cita
    {
        //  atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCita { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        //  FK

        // tabla hijo de Medico
        public virtual Medico? Medico { get; set; }
        [ForeignKey("Medico")]
        public int idMedico { get; set; }

        // tabla hijo de TipoPago
        public virtual TipoPago? TipoPago { get; set; }
        [ForeignKey("TipoPago")]
        public int idTipoPago { get; set; }


        // tabla hijo de Paciente
        public virtual Paciente? Paciente { get; set; }
        [ForeignKey("Paciente")]
        public int idPaciente { get; set; }
    }
}