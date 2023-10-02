using System.ComponentModel.DataAnnotations;


namespace ClinicaAPI.Models
{
public class Prontuario
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int PacienteId { get; set; }
    [Required]
    public DateTime DataCriacao { get; set; }
    [Required]
    public string Diagnostico { get; set; }
    [Required]
    public string Tratamento { get; set; }

    public Prontuario(int id, int pacienteId, DateTime dataCriacao, string diagnostico, string tratamento)
        {
            Id = id;
            PacienteId = pacienteId;
            Diagnostico = diagnostico;
            Tratamento = tratamento;

            // Define o fuso horário de origem (por exemplo, UTC)
            TimeZoneInfo origemTimeZone = TimeZoneInfo.Utc;

            // Define o fuso horário de destino (por exemplo, Brasília)
            TimeZoneInfo destinoTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            // Converte a data e hora da dataHora fornecida (em UTC) para o fuso horário de destino
            DataCriacao = TimeZoneInfo.ConvertTimeFromUtc(dataCriacao, destinoTimeZone);

            DataCriacao.ToString("yyyy-MM-ddTHH:mm:ss"); // Formato ISO 8601
        }

}

}