using MVCClinicaMedica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCClinicaMedica.DBContext
{
    public partial class BaseEFContext : DbContext
    {
        public BaseEFContext()
        {
        }


        public BaseEFContext(DbContextOptions<BaseEFContext> options)
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

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json")  // Ruta al archivo de configuración
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);  // O el proveedor de base de datos que estés utilizando
        }*/

        public virtual DbSet<Cita> Citas { get; set; }
        public virtual DbSet<TipoPago> TipoPagos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Consultorio> Consultorios { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<RegistroMedico> RegistrosMedicos { get; set; }
        //public virtual DbSet<HistoriaClinica> HistoriasClinicas { get; set; }
        public virtual DbSet<EquipoMedico> EquiposMedicos { get; set; }
        public virtual DbSet<EquipoMedicoConsultorio> EquiposMedicosConsultorios { get; set; }
        public virtual DbSet<Especialidad> Especialidades { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<RolOperacion> RolOperaciones { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Operacion> Operaciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClinicaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");


        // Para la tabla de rompimiento 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipoMedicoConsultorio>()
                .HasKey(emc => new { emc.idEquipo, emc.idConsultorio });

        }


    }
}
