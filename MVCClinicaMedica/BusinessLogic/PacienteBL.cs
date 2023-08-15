using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository;
using System.Xml;

public class PacienteBL
{
    private readonly BaseEFContext _dbContext;
    IGenericRepository<Paciente> repoPaciente = new GenericRepository<Paciente>();

    public PacienteBL(BaseEFContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Paciente> ObtenerListaPacientePorId(int idPaciente)
    {
        List<Paciente> listarPacientes = repoPaciente.GetAll().ToList();
        foreach (var item in listarPacientes)
        {
            Console.WriteLine("Paciente: |" + item.Nombre + "|");
        }
        return listarPacientes;
    }


    // arreglar try y catch
    public int BuscarPacientePorCedula(string cedula)
    {
        try { 
        var cedulaEncontrada = _dbContext.Set<Paciente>().FirstOrDefault(e => e.Cedula == cedula);
        return cedulaEncontrada.idPaciente;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -1;
        }
    }


}