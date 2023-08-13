using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.Models;

namespace MVCClinicaMedica.Servicios.Contrato
{
    public interface ICitaService
    {
        Task<Factura> ObtenerCitasPorPaciente(int id);
        Task<Factura> GuardarFactura(Factura factura);

    }

}
