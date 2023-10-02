using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class Receita
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Medicamento { get; set; }
        [Required]
        public string Dosagem { get; set; }
        [Required]
        public string InstrucoesUso { get; set; }
        [Required]
        public DateTime DataEmissao { get; set; }
        [Required]
        public int IdMedico { get; set; }

        public Receita(int id, string medicamento, string dosagem, string instrucoesUso, DateTime dataEmissao, int idMedico)
        { 
            Id= id;
            Medicamento = medicamento;
            Dosagem = dosagem;
            InstrucoesUso = instrucoesUso;
            IdMedico = idMedico;

            // Define o fuso horário de origem (por exemplo, UTC)
            TimeZoneInfo origemTimeZone = TimeZoneInfo.Utc;

            // Define o fuso horário de destino (por exemplo, Brasília)
            TimeZoneInfo destinoTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            // Converte a data e hora da dataHora fornecida (em UTC) para o fuso horário de destino
            DataEmissao = TimeZoneInfo.ConvertTimeFromUtc(dataEmissao, destinoTimeZone);

            DataEmissao.ToString("yyyy-MM-ddTHH:mm:ss"); // Formato ISO 8601
        }

    }


}