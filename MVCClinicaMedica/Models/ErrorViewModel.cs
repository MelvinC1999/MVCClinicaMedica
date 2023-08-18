using System.ComponentModel.DataAnnotations.Schema;

namespace MVCClinicaMedica.Models
{
    [NotMapped]
    public class ErrorViewModel
    {
        [NotMapped]
        public string? RequestId { get; set; }
        [NotMapped]
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}