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
    ///******************************************************KART LINUX ***********************************************
    
    ///****************************************************************************************************************
    /// <summary>
    /// Constructor con parametro
    /// </summary>
    /// <param name="dbContext"></param>
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

    // cambio return 0 cuando la cedula no existe en la bdd
    public bool CedulaEsValida(string cedula)
    {
        var dbContext = new BaseEFContext();
        return dbContext.Set<Paciente>().Any(e => e.Cedula == cedula);
    }

    public int BuscarPacientePorCedula(string cedula)
    {
        try
        {
            var cedulaEncontrada = _dbContext.Set<Paciente>().FirstOrDefault(e => e.Cedula == cedula);



            if (cedulaEncontrada != null)
            {
                return cedulaEncontrada.idPaciente;
            }
            else
            {
                return 0; // Cédula no encontrada
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -1;
        }
    }
    ///******************************************************KART LINUX **********************************************
    public PacienteBL()
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }
    public List<Paciente> retornarPacientesBL()
    {
        List<Paciente> listarPacientes = repoPaciente.GetAll().ToList();
        foreach (var item in listarPacientes)
        {
            Console.WriteLine("Id Paciente: |" + item.idPaciente + "|" +
                " Nombre: |" + item.Nombre + "|" +
                " Apellido: |" + item.Apellido + "|" +
                " Cedula: |" + item.Cedula + "|");
        }
        return listarPacientes;
    }
    ///****************************************************************************************************************
}