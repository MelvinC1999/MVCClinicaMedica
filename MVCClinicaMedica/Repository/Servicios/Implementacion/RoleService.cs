using MVCClinicaMedica.DBContext;
using System;
using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using MVCClinicaMedica.Repository.Servicios.Contrato;

namespace MVCClinicaMedica.Repository.Servicios.Implementacion
{
    public class RoleService : IRoleService
    {
        private readonly BaseEFContext _dbContext;

        public RoleService(BaseEFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool EsPaciente(string usuario)
        {
            var rolesUsuario = _dbContext.Usuarios
                .Where(u => u.Correo == usuario)
                .Select(u => u.Roles.NombreRol)
                .ToList();

            return rolesUsuario.Contains("Paciente");
        }

        public bool EsMedico(string usuario)
        {
            var rolesUsuario = _dbContext.Usuarios
                .Where(u => u.Correo == usuario)
                .Select(u => u.Roles.NombreRol)
                .ToList();

            return rolesUsuario.Contains("Doctor");
        }

        public bool EsAdministrador(string usuario)
        {
            var rolesUsuario = _dbContext.Usuarios
                .Where(u => u.Correo == usuario)
                .Select(u => u.Roles.NombreRol)
                .ToList();

            return rolesUsuario.Contains("Administrador");
        }
    }

}


