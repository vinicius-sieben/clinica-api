using System.Text.RegularExpressions;

namespace ClinicaAPI.Negocios
{
    public class Validar
    {
        public bool Cpf(string cpf)
        {
            // Remove caracteres não numéricos do CPF
            cpf = Regex.Replace(cpf, "[^0-9]", "");

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11)
            {
                return false;
            }

            // Calcula os dígitos verificadores
            int[] cpfArray = new int[11];
            for (int i = 0; i < 11; i++)
            {
                if (!int.TryParse(cpf[i].ToString(), out cpfArray[i]))
                {
                    return false;
                }
            }

            int soma1 = 0;
            int soma2 = 0;

            for (int i = 0; i < 9; i++)
            {
                soma1 += cpfArray[i] * (10 - i);
                soma2 += cpfArray[i] * (11 - i);
            }

            int resto1 = soma1 % 11;
            int digito1 = (resto1 < 2) ? 0 : 11 - resto1;

            soma2 += digito1 * 2;

            int resto2 = soma2 % 11;
            int digito2 = (resto2 < 2) ? 0 : 11 - resto2;

            return (cpfArray[9] == digito1) && (cpfArray[10] == digito2);
        }
    }
}
