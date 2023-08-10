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
        public virtual Medico? Medicos { get; set; }
        [ForeignKey("idMedico")]
        public int idMedico { get; set; }

        // tabla hijo de TipoPago
        public virtual TipoPago? TiposPagos { get; set; }
        [ForeignKey("idTipoPago")]
        public int idTipoPago { get; set; }


        // tabla hijo de Paciente
        public virtual Paciente? Pacientes { get; set; }
        [ForeignKey("idPaciente")]
        public int idPaciente { get; set; }
    }
}