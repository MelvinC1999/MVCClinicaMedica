﻿using Microsoft.AspNetCore.Mvc;
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