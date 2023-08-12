using System.Collections.Generic;

namespace MVCClinicaMedica.Models
{
    public class MedicoCitasViewModel
    {
        public List<Cita> Citas { get; set; }
        public Medico Medico { get; set; }
    }
}
