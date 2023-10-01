using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models {
    public class Paciente {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Cpf { get; set; }

    }
}
