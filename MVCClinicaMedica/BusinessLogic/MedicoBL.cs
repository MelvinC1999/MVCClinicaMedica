using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;
using System.Xml;

public class MedicoBL
{
    private readonly BaseEFContext _dbContext;
    IGenericRepository<Medico> repoMedico = new GenericRepository<Medico>();
    IGenericRepository<RegistroMedico> repoRegistro = new GenericRepository<RegistroMedico>();
    BaseEFContext context = new BaseEFContext();

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
    public List<String> ObtenerHorariosMedicos()
    {
        return new List<String> {"7:00-9:00", "9:00-11:00", "11:00-13:00", "14:00-16:00", "16:00-18:00" };
    }
    /// <summary>
    /// Construcctor con parametro
    /// </summary>
    /// <param name="dbContext"></param>
    public MedicoBL(BaseEFContext dbContext)
    {
        _dbContext = dbContext;
    }
    public MedicoBL()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }
    /// <summary>
    /// Metodo que recupera todos los medicos de la base de datos y los retorna en una LIST
    /// </summary>
    /// <returns></returns>
    public List<Medico> retornarMedicos()
    {
        List<Medico> listarMedicos = repoMedico.GetAll().ToList();
        foreach (var item in listarMedicos)
        {
            Console.WriteLine("Id Medico: |" + item.idMedico + "|" +
                " Nombre Medico: |" + item.Nombre + "|" +
                " Apellido Medico: |" + item.Apellido + "|" +
                " Id Especialidad: |" + item.idEspecialidad + "|");
        }
        return listarMedicos;
    }
    public List<Medico> retornoMedicosEspecialidad()
    {
        // Obtener los datos de los médicos y sus horarios de la base de datos
        var medicos = context.Medicos.Include(m => m.Especialidades).ToList();
        retornoHoariosMedico(medicos);
        //foreach (var item in medicos)
        //{
        //    Console.WriteLine(">Nombre medico()>: " + item.Nombre+"" +
        //        "id: "+ item.idMedico+"" +
        //        "id especialidad: "+item.idEspecialidad+"" +
        //        "espec: "+item.Especialidades);
        //}
        ///
        return medicos;
    }
    public List<string> retornoHoariosMedico(List<Medico> medicosLista)
    {
        var horarios = medicosLista.Select(m => m.Horario).Distinct().ToList();
        foreach (var horario in horarios)
        {
            Console.WriteLine("Horario: " + horario);
        }
        return horarios;
    }

    public int ObtenerIdMedicoPorCorreo(string correo)
    {
        var medico = repoMedico.FindFirstBy(m => m.Correo == correo);
        if (medico == null)
        {
            throw new Exception("El medico no ha sido encontrado");
        }
        return medico.idMedico;
    }

    public Medico CrearMedico(Medico medico)
    {
        repoMedico.Add(medico);
        repoMedico.SaveChanges();
        return medico;
    }

    public RegistroMedico CrearRegistroMedico(RegistroMedico registroMedico)
    {
        repoRegistro.Add(registroMedico);
        repoRegistro.SaveChanges();
        return registroMedico;
    }

    public void EliminarMedico(Medico medico)
    {
        repoMedico.HardDelete(medico);
    }


}

