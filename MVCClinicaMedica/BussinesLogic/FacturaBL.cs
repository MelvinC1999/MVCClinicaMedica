using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Utilitario;
using MVCClinicaMedica.Repository;
namespace MVCClinicaMedica.BussinesLogic
{
    public class FacturaBL
    {
        GenericRepository<Factura> facturaRepo = new GenericRepository<Factura>();
        public void GuardarFactura(Factura nuevaFactura)
        {
            facturaRepo.Add(nuevaFactura);
            facturaRepo.SaveChanges();
        }
    }
}
