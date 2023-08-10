using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCClinicaMedica.Models
{
    [Table("EquiposMedicosConsultorios")]
    public class EquipoMedicoConsultorio
    {
        // la clave principal es una combinacion de esta tabla es una combinacion entre EquipoMedico y Consultorio
        [Key]
        [Column(Order = 0)]
        [ForeignKey("idEquipoMedico")]
        public int idEquipo { get; set; }
        public virtual EquipoMedico? EquiposMedicos { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("idConsultorio")]
        public int idConsultorio { get; set; }
        public virtual Consultorio? Consultorios { get; set; }
    }
}