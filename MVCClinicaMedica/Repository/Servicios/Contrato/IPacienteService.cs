using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.Models;

namespace MVCClinicaMedica.Servicios.Contrato
{
    public interface IPacienteService
    {
        Task<Factura> ObtenerUltimaFacturaPorPaciente(int idPaciente);
        Task<List<Cita>> ObtenerCitasPorPaciente(int idPaciente);
    }

}
