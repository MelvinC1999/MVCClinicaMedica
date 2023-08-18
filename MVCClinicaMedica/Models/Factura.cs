using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;

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
        [Column("idPaciente")]
        public int idPaciente { get; set; }
        [ForeignKey("idPaciente")]
        public virtual Paciente? Pacientes { get; set; }

        // tabla hijo de Consultorio
        [Column("idConsultorio")]
        public int idConsultorio { get; set; }
        [ForeignKey("idConsultorio")]
        public virtual Consultorio? Consultorios { get; set; }

        // tabla hijo de Cita
        [Column("idCita")]
        public int idCita { get; set; }
        [ForeignKey("idCita")]
        public virtual Cita? Citas { get; set; }

    }
}
