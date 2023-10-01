using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models {
    public class Medico {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Crm { get; set; }

    }
}
