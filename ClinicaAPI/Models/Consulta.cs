using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class Consulta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdPaciente { get; set; }
        [Required]
        public int IdMedico { get; set; }
        [Required]
        public string Razao { get; set; }
        [Required]
        public DateTime DataHora { get; set; }

        public Consulta(int id, int idPaciente, int idMedico, string razao, DateTime dataHora)
        {
            Id = id;
            IdPaciente = idPaciente;
            IdMedico = idMedico;
            Razao = razao;

            // Define o fuso horário de origem (por exemplo, UTC)
            TimeZoneInfo origemTimeZone = TimeZoneInfo.Utc;

            // Define o fuso horário de destino (por exemplo, Brasília)
            TimeZoneInfo destinoTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            // Converte a data e hora da dataHora fornecida (em UTC) para o fuso horário de destino
            DataHora = TimeZoneInfo.ConvertTimeFromUtc(dataHora, destinoTimeZone);

            DataHora.ToString("yyyy-MM-ddTHH:mm:ss"); // Formato ISO 8601
        }

    }

}
