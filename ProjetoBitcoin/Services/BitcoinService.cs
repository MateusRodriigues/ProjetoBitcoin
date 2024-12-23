using Newtonsoft.Json; // Biblioteca para deserializar o JSON recebido da API.
using ProjetoBitcoin.Models; // Importa os modelos de dados necessários.

namespace ProjetoBitcoin.Services
{
    // A classe BitcoinService é responsável por consultar a API e obter os dados atualizados do Bitcoin.
    public class BitcoinService
    {
        private readonly string _apiUrl; // Armazena a URL da API que será consumida.

        // Construtor que recebe a URL da API e inicializa a variável _apiUrl.
        public BitcoinService(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        // Método assíncrono para obter os dados do Bitcoin a partir da API.
        public async Task<BitcoinData> ObterDadosAsync()
        {
            using (var client = new HttpClient()) // Cria o cliente HTTP para fazer a requisição.
            {
                // Envia a requisição GET para a API e aguarda a resposta como string.
                var response = await client.GetStringAsync(_apiUrl);

                // Desserializa a resposta JSON da API para o objeto ApiResponse.
                var dados = JsonConvert.DeserializeObject<ApiResponse>(response);

                // Calcula o preço anterior com base na variação percentual do preço.
                var precoAnterior = dados.Bitcoin.Usd / (1 + (dados.Bitcoin.Usd24hChange / 100));
                var variacao = dados.Bitcoin.Usd24hChange;

                // Retorna um objeto BitcoinData com os dados necessários (data atual, preço atual, preço anterior e variação).
                return new BitcoinData
                {
                    DataAtual = DateTime.Now, // Define a data e hora atual.
                    PrecoAtual = Math.Round(dados.Bitcoin.Usd, 2), // Arredonda o preço atual para 2 casas decimais.
                    PrecoAnterior = Math.Round(precoAnterior, 2), // Arredonda o preço anterior para 2 casas decimais.
                    Variacao = Math.Round(variacao, 2) // Arredonda a variação para 2 casas decimais.
                };
            }
        }
    }

    // Classe para mapear a resposta da API. Ela contém o objeto Bitcoin.
    public class ApiResponse
    {
        [JsonProperty("bitcoin")] // A propriedade 'bitcoin' do JSON será mapeada para o objeto Bitcoin.
        public BitcoinInfo Bitcoin { get; set; }
    }

    // Classe para mapear as informações do Bitcoin que são retornadas pela API.
    public class BitcoinInfo
    {
        [JsonProperty("usd")] // Mapeia o preço atual do Bitcoin em USD.
        public double Usd { get; set; }

        [JsonProperty("usd_24h_change")] // Mapeia a variação percentual do preço do Bitcoin nas últimas 24 horas.
        public double Usd24hChange { get; set; }
    }
}
