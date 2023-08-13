using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;
using System.Xml;

public class MedicoBL
{
    private readonly BaseEFContext _dbContext;
    IGenericRepository<Medico> repoMedico = new GenericRepository<Medico>();

    /// <summary>
    /// Retorno la lsita de los medicos para enviarselo a la vista por ViewBag
    /// </summary>
    /// <returns></returns>
    /// 
    public List<Medico> ObtenerListaMedicos()
    {
        List<Medico> listarMedicos = repoMedico.GetAll().ToList();
        foreach (var item in listarMedicos)
        {
            Console.WriteLine("Id Medico: |" + item.Nombre + "|");
        }
        return listarMedicos;
    }

    public MedicoBL(BaseEFContext dbContext)
    {
        _dbContext = dbContext;
    }



}
}
