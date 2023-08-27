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
        public List<Factura> FacturaEager() 
        {
            IQueryable<Factura> list = facturaRepo.todosEager<Factura>(c => c.Consultorios, c => c.Citas, c => c.Citas.Medicos, c => c.Pacientes);
            foreach (var item in list)
            {
                Console.WriteLine("IdFactura: " + " " + item.idCita + " fecha: " + "" + item.Fecha + " " + " nombreCliente:" + item.Pacientes.Nombre + " " + " medico:" + item.Citas.Medicos.Nombre + " " + " consultorio:" + item.Consultorios.idConsultorio);

            }
            return list.ToList();
        }
        public void EliminarID(int idfac)
        {
            Console.WriteLine("eliminado correctamente el" + idfac);
            var factu = facturaRepo.Get(idfac);
            facturaRepo.HardDelete(factu);
            facturaRepo.SaveChanges();
        }
    }
}
