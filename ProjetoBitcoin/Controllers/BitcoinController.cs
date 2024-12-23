using ProjetoBitcoin.Models; // Importa o modelo de dados do Bitcoin.
using ProjetoBitcoin.Repositories; // Importa o repositório para salvar os dados no banco de dados.
using ProjetoBitcoin.Services; // Importa o serviço que busca os dados da API CoinGecko.

namespace ProjetoBitcoin.Controllers
{
    // O BitcoinController gerencia a consulta dos dados do Bitcoin da API e o salvamento desses dados no banco de dados.
    public class BitcoinController
    {
        private readonly BitcoinService _bitcoinService; // Serviço para buscar os dados na API.
        private readonly BitcoinRepository _bitcoinRepository; // Repositório para salvar os dados no banco.

        // Construtor que recebe o serviço e o repositório para inicializar as dependências.
        public BitcoinController(BitcoinService bitcoinService, BitcoinRepository bitcoinRepository)
        {
            _bitcoinService = bitcoinService;
            _bitcoinRepository = bitcoinRepository;
        }

        // Método assíncrono para consultar os dados do Bitcoin.
        public async Task<List<BitcoinData>> ConsultarDadosAsync()
        {
            try
            {
                // Chama o serviço para pegar os dados do Bitcoin da API.
                var dadosBitcoin = await _bitcoinService.ObterDadosAsync();

                // Salva os dados no banco de dados.
                _bitcoinRepository.SalvarDados(new List<BitcoinData> { dadosBitcoin });

                // Retorna os dados obtidos.
                return new List<BitcoinData> { dadosBitcoin };
            }
            catch (Exception ex)
            {
                // Caso algo dê errado, lança um erro explicando o que aconteceu.
                throw new Exception($"Erro ao consultar dados do Bitcoin: {ex.Message}", ex);
            }
        }

        // Método para salvar os dados no banco de dados.
        public void SalvarDados(List<BitcoinData> dados)
        {
            try
            {
                // Chama o repositório para salvar os dados no banco.
                _bitcoinRepository.SalvarDados(dados);
            }
            catch (Exception ex)
            {
                // Caso ocorra um erro ao salvar, lança um erro explicando o problema.
                throw new Exception($"Erro ao salvar dados no banco: {ex.Message}", ex);
            }
        }
    }
}
