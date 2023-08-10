using ClinicaMedica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaMedica.DBContext
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }


        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string basePath = "C:\\Users\\Rick\\source\\repos\\EntityFrameworkCódigoPrimero2\\EntityFrameworkCódigoPrimero2\\Config";
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(basePath)
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    string connectionString = configuration.GetConnectionString("DefaultConnection");

        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json")  // Ruta al archivo de configuración
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);  // O el proveedor de base de datos que estés utilizando
        }

        public virtual DbSet<Cita> Citas { get; set; }
        public virtual DbSet<TipoPago> TipoPagos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Consultorio> Consultorios { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<RegistroMedico> RegistrosMedicos { get; set; }
        public virtual DbSet<HistoriaClinica> HistoriasClinicas { get; set; }
        public virtual DbSet<EquipoMedico> EquiposMedicos { get; set; }
        public virtual DbSet<EquipoMedicoConsultorio> EquiposMedicosConsultorios { get; set; }
        public virtual DbSet<Especialidad> Especialidades { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Perfil> Perfiles { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }


        // Para la tabla de rompimiento 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipoMedicoConsultorio>()
                .HasKey(emc => new { emc.idEquipo, emc.idConsultorio });

        }


    }
}
