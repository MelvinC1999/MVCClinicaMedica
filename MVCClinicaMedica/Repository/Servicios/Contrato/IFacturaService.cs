using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.Models;

namespace MVCClinicaMedica.Servicios.Contrato
{
    public interface IFacturaService
    {
        Task<Factura> ObtenerFacturaPorId(int id);
        Task<Factura> GuardarFactura(Factura factura);
        Task ObtenerUltimaFacturaPorPaciente(object idPaciente);
    }

}
