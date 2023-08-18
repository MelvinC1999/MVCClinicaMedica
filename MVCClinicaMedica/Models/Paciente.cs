using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCClinicaMedica.BussinesLogic;

namespace MVCClinicaMedica.Models
{
    [Table("Pacientes")]
    public class Paciente
    {
        // atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPaciente { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(50)]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "La cédula es requerida")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "La cédula debe tener entre 10 y 13 caracteres")]
        public string? Cedula { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Range(1, 110, ErrorMessage = "La edad debe estar entre 1 y 110")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El estado civil es requerido")]
        [StringLength(20)]
        public string? EstadoCivil { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        [StringLength(50)]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido")]
        [StringLength(15)]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Ingrese una dirección de correo válida")]
        public string? Correo { get; set; }
        
        [StringLength(1000)]
        public string? HistoriaClinica { get; set; }

        // Propiedad de navegación para los registros médicos
        public virtual ICollection<RegistroMedico> RegistrosMedicos { get; set; } = new List<RegistroMedico>();
        public virtual ICollection<Cita> Citas { get; set; } = new List<Cita>();
        public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    }
}