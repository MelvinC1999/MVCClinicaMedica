using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;
using MVCClinicaMedica.Validador;

public class CitaBL
{
    private readonly BaseEFContext _dbContext;
    BaseEFContext _baseEFContext = new BaseEFContext();   
    ValidadorCita valeCita = new ValidadorCita();
    IGenericRepository<Cita> repoCita = new GenericRepository<Cita>();
    Cita cita = new Cita();
    /// <summary>
    /// Construcctor sin parametros
    /// </summary>
    public CitaBL()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }
    /// <summary>
    /// Constructor con parametro
    /// </summary>
    /// <param name="dbContext"></param>
    public CitaBL(BaseEFContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Cita> ObtenerCitasPorIdPaciente(int idPaciente)
    {
        Console.WriteLine("HOLAAAAAAAAAAA");
        return _baseEFContext.Citas.Where(c => c.idPaciente == idPaciente).ToList();
    }


    public async Task<Medico> ObtenerMedicoPorId(int idMedico)
    {
        return await _dbContext.Medicos.FindAsync(idMedico);
    }
    ///************************************************************KART LINUX ****************************************
    
    /// <summary>
    /// Se retorna un lista con las citas que existen en la base de datos
    /// </summary>
    /// <returns></returns>
    public List<Cita> retornarCitasBL()
    {
        List<Cita> listarCitas = repoCita.GetAll().ToList();
        foreach (var item in listarCitas)
        {
            Console.WriteLine("Id Cita: |" + item.idCita + "|" +
                " Fecha Cita: |" + item.Fecha + "|" +
                " Id Medico: |" + item.idMedico + "|" +
                " Id Paciente: |" + item.idPaciente + "|");
        }
        return listarCitas;
    }
    /// <summary>
    /// Metodo que crea un cita en la base de datos cuando se le pasa
    /// como parametro un Objeto de tipo CITA
    /// </summary>
    /// <param name="_cita"></param>
    public void CrearCitaDB(Cita _cita)
    {
        //Validaciones
        if (true)
        {
            repoCita.Add(_cita);
            Console.WriteLine("Cita: |" + _cita.idCita + "| insertada correctamente.");
        }
    }
    /// <summary>
    /// Metodo que actualiza la cita, el id se lo trae en el formulario como tipo hidden 
    /// para que tome el ide de la cita junto con el objeto, porque si no tiene el id se manda 
    /// a crear en vez de actualizar
    /// </summary>
    /// <param name="_cita"></param>
    public void ActualizarCitaDB(Cita _cita)
    {
        if (true)
        {
            repoCita.Update(_cita);
            Console.WriteLine("Cita: |" + _cita.idCita + "| actualizada correctamente.");
        }
    }
    public void EliminarCitaDB(int id)
    {
        if (true)
        {
            cita = repoCita.Get(id);
            repoCita.HardDelete(cita);
            Console.WriteLine("Cita: |" + cita.idCita + "| eliminada correctamente.");
        }
    }
    /// <summary>
    /// Metodo para guardar los cambios
    /// </summary>
    public void GuadarCambios()
    {
        repoCita.SaveChanges();
        Console.WriteLine("Guardado Positivamente :)");
    }
    ///***************************************************************************************************************


}