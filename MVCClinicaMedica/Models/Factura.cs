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
    [Table("Facturas")]
    public class Factura
    {
        // atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idFactura { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El monto total es requerido")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal MontoTotal { get; set; }

        [Required(ErrorMessage = "El estado de pago es requerido")]
        [StringLength(20)]
        public string? EstadoPago { get; set; }


        // FK
        // tabla hijo de Paciente
        public virtual Paciente? Pacientes { get; set; }
        [ForeignKey("Paciente")]
        public int idPaciente { get; set; }


        // tabla hijo de Consultorio
        public virtual Consultorio? Consultorios { get; set; }
        [ForeignKey("Consultorio")]
        public int idConsultorio { get; set; }


        // tabla hijo de Cita
        public virtual Cita? Citas { get; set; }
        [ForeignKey("Cita")]
        public int idCita { get; set; }


    }
}
