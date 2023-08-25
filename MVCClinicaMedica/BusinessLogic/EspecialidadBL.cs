using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;

public class EspecialidadBL
{
    private readonly BaseEFContext _dbContext;
    IGenericRepository<Especialidad> repoEspecialidad = new GenericRepository<Especialidad>();
    //BaseEFContext context = new BaseEFContext();

    /// Retorno la lsita de los especialidad para enviarselo a la vista por ViewBag

    public List<Especialidad> ObtenerListaEspecialidades()
    {
        List<Especialidad> listarEspecialidad = repoEspecialidad.GetAll().ToList();
        foreach (var item in listarEspecialidad)
        {
            Console.WriteLine("Id Especialidad: |" + item.idEspecialidad + "|");
        }
        return listarEspecialidad;
    }

    public EspecialidadBL(BaseEFContext dbContext)
    {
        _dbContext = dbContext;
    }

    public EspecialidadBL()
    {

    }

}