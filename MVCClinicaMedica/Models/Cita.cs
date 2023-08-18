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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCita { get; set; }

        [Column("Fecha")]
        [Required(ErrorMessage = "La fecha es requerida")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        //  FK

        // tabla hijo de Medico
        [Column("idMedico")]
        public int idMedico { get; set; }
        [ForeignKey("idMedico")]
        public virtual Medico? Medicos { get; set; }
        
        // tabla hijo de TipoPago
        [Column("idTipoPago")]
        public int idTipoPago { get; set; }
        [ForeignKey("idTipoPago")]
        public virtual TipoPago? TiposPagos { get; set; }

        // tabla hijo de Paciente
        [Column("idPaciente")]
        public int idPaciente { get; set; }
        [ForeignKey("idPaciente")]
        public virtual Paciente? Pacientes { get; set; }
             
    }
}