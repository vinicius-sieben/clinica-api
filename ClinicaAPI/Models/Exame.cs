using System.ComponentModel.DataAnnotations;
namespace ClinicaAPI.Models
{
    public class Exame
{
   [Key]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    public string Resultado { get; set; }
    [Required]
    public int PacienteId { get; set; }

    public Exame(int id, string nome, DateTime data, string resultado, int pacienteId)
    {
Id= id;
            Id = id;
            Nome = nome;
            Resultado= resultado;
            PacienteId = pacienteId;

            // Define o fuso horário de origem (por exemplo, UTC)
            TimeZoneInfo origemTimeZone = TimeZoneInfo.Utc;

            // Define o fuso horário de destino (por exemplo, Brasília)
            TimeZoneInfo destinoTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            // Converte a data e hora da dataHora fornecida (em UTC) para o fuso horário de destino
            Data = TimeZoneInfo.ConvertTimeFromUtc(data, destinoTimeZone);

            Data.ToString("yyyy-MM-ddTHH:mm:ss"); // Formato ISO 8601
    }
}

}