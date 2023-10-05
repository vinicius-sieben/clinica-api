namespace ClinicaAPI.Negocios
{
    public class Fusohorario
    {
        public static DateTime Corrigir(DateTime data) 
        {
            // Define o fuso horário de origem (por exemplo, UTC)
            TimeZoneInfo origemTimeZone = TimeZoneInfo.Utc;

            // Define o fuso horário de destino (por exemplo, Brasília)
            TimeZoneInfo destinoTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            // Converte a data e hora da dataHora fornecida (em UTC) para o fuso horário de destino
            data = TimeZoneInfo.ConvertTimeFromUtc(data, destinoTimeZone);

            return data;
        }
    }
}
