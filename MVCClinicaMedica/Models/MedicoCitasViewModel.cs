using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCClinicaMedica.Models
{
    [NotMapped]
    public class MedicoCitasViewModel
    {
        [NotMapped]
        public List<Cita> Citas { get; set; }
        [NotMapped]
        public Medico Medico { get; set; }
    }
}
