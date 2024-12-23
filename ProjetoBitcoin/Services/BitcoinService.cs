using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjetoBitcoin.Models;

namespace ProjetoBitcoin.Services
{
    public class BitcoinService
    {
        private readonly string _apiUrl;

        public BitcoinService(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        // Método para obter os dados do Bitcoin da API
        public async Task<BitcoinData> ObterDadosAsync()
        {
            using (var client = new HttpClient())
            {
                // Enviando a requisição para a API
                var response = await client.GetStringAsync(_apiUrl);

                // Desserializando o JSON recebido da API
                var dados = JsonConvert.DeserializeObject<ApiResponse>(response);

                // Calculando o preço anterior com base na variação percentual
                var precoAnterior = dados.Bitcoin.Usd / (1 + (dados.Bitcoin.Usd24hChange / 100));
                var variacao = dados.Bitcoin.Usd24hChange;

                // Criando o objeto de resposta
                return new BitcoinData
                {
                    DataAtual = DateTime.Now,
                    PrecoAtual = Math.Round(dados.Bitcoin.Usd, 2),
                    PrecoAnterior = Math.Round(precoAnterior, 2),
                    Variacao = Math.Round(variacao, 2)
                };
            }
        }
    }

    // Classe para mapear a resposta da API
    public class ApiResponse
    {
        [JsonProperty("bitcoin")]
        public BitcoinInfo Bitcoin { get; set; }
    }

    // Classe para mapear os dados do Bitcoin
    public class BitcoinInfo
    {
        [JsonProperty("usd")]
        public double Usd { get; set; }

        [JsonProperty("usd_24h_change")]
        public double Usd24hChange { get; set; }
    }
}
