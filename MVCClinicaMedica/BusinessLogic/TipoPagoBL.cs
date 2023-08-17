using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;

namespace MVCClinicaMedica.BusinessLogic
{
    public class TipoPagoBL
    {
        public TipoPagoBL()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        IGenericRepository<TipoPago> repoPago = new GenericRepository<TipoPago>();
        TipoPago tipoPago = new TipoPago();
        BaseEFContext context = new BaseEFContext();
        public List<TipoPago> retornarPagosBL()
        {
            List<TipoPago> listarPagos = repoPago.GetAll().ToList();
            foreach (var item in listarPagos)
            {
                Console.WriteLine("Id Pago: |" + item.idTipoPago + "|" +
                    " Descripcion: |" + item.Descripcion);
            }
            return listarPagos;
        }
    }
}
