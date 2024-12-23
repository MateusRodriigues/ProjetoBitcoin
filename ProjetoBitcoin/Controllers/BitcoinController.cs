using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoBitcoin.Models;
using ProjetoBitcoin.Repositories;
using ProjetoBitcoin.Services;

namespace ProjetoBitcoin.Controllers
{
    public class BitcoinController
    {
        private readonly BitcoinService _bitcoinService;
        private readonly BitcoinRepository _bitcoinRepository;

        // Construtor que recebe a instância do BitcoinService e BitcoinRepository
        public BitcoinController(BitcoinService bitcoinService, BitcoinRepository bitcoinRepository)
        {
            _bitcoinService = bitcoinService;
            _bitcoinRepository = bitcoinRepository;
        }

        // Método assíncrono para consultar dados do Bitcoin da API
        public async Task<List<BitcoinData>> ConsultarDadosAsync()
        {
            try
            {
                // Consultando dados da API
                var dadosBitcoin = await _bitcoinService.ObterDadosAsync();

                // Armazenando os dados no banco de dados
                _bitcoinRepository.SalvarDados(new List<BitcoinData> { dadosBitcoin });

                return new List<BitcoinData> { dadosBitcoin };
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar dados do Bitcoin: {ex.Message}", ex);
            }
        }

        // Método para salvar os dados no banco de dados
        public void SalvarDados(List<BitcoinData> dados)
        {
            try
            {
                _bitcoinRepository.SalvarDados(dados);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar dados no banco: {ex.Message}", ex);
            }
        }
    }
}
