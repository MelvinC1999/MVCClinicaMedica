using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;

public class CitaBL
{
    private readonly BaseEFContext _dbContext;

    public CitaBL(BaseEFContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Cita>> ObtenerCitasPorIdPaciente(int idPaciente)
    {
        Console.WriteLine("HOLAAAAAAAAAAA");
        return await _dbContext.Citas.Where(c => c.idPaciente == idPaciente).ToListAsync();
    }


    public async Task<Medico> ObtenerMedicoPorId(int idMedico)
    {
        return await _dbContext.Medicos.FindAsync(idMedico);
    }



}