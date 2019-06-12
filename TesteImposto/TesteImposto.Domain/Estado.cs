using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TesteImposto.Domain
{
    public static class Estado
    {
        /// <summary>
        /// Verifica se a UF faz parte da região sudeste
        /// </summary>
        /// <param name="uf">UF</param>
        /// <returns>Retorna se a UF faz parte da região sudeste</returns>
        public static bool IsSudeste(string uf)
        {
            List<string> ufSudeste = new List<string>()
            {
                "SP"
                ,"RJ"
                ,"MG"
                ,"ES"
            };

            return ufSudeste.Any(x => x == uf.Trim());
        }

        /// <summary>
        /// Lista de estados
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<KeyValuePair<string, string>> GetEstados()
        {
            return new ObservableCollection<KeyValuePair<string, string>>()
            {
            new KeyValuePair<string, string>( "AC", "Acre" ),
            new KeyValuePair<string, string>( "AL", "Alagoas" ),
            new KeyValuePair<string, string>( "AP", "Amapá" ),
            new KeyValuePair<string, string>( "AM", "Amazonas" ),
            new KeyValuePair<string, string>( "BA", "Bahia" ),
            new KeyValuePair<string, string>( "CE", "Ceará" ),
            new KeyValuePair<string, string>( "DF", "Distrito Federal" ),
            new KeyValuePair<string, string>( "ES", "Espírito Santo" ),
            new KeyValuePair<string, string>( "GO", "Goiás" ),
            new KeyValuePair<string, string>( "MA", "Maranhão" ),
            new KeyValuePair<string, string>( "MT", "Mato Grosso" ),
            new KeyValuePair<string, string>( "MS", "Mato Grosso do Sul" ),
            new KeyValuePair<string, string>( "MG", "Minas Gerais" ),
            new KeyValuePair<string, string>( "PA", "Pará" ),
            new KeyValuePair<string, string>( "PB", "Paraíba" ),
            new KeyValuePair<string, string>( "PR", "Paraná" ),
            new KeyValuePair<string, string>( "PE", "Pernambuco" ),
            new KeyValuePair<string, string>( "PI", "Piauí" ),
            new KeyValuePair<string, string>( "RJ", "Rio de Janeiro" ),
            new KeyValuePair<string, string>( "RN", "Rio Grande do Norte" ),
            new KeyValuePair<string, string>( "RS", "Rio Grande do Sul" ),
            new KeyValuePair<string, string>( "RO", "Rondônia" ),
            new KeyValuePair<string, string>( "RR", "Roraima" ),
            new KeyValuePair<string, string>( "SC", "Santa Catarina" ),
            new KeyValuePair<string, string>( "SP", "São Paulo" ),
            new KeyValuePair<string, string>( "SE", "Sergipe" ),
            new KeyValuePair<string, string>( "TO", "Tocantins" )
            };
        }
    }
}
