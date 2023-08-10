using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCClinicaMedica.Models
{
    [Table("TiposPagos")]
    public class TipoPago
    {
        // atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTipoPago { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(50)]
        public string? Descripcion { get; set; }
    }
}
