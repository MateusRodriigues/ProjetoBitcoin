using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjetoBitcoin.Controllers;
using ProjetoBitcoin.Models;
using ProjetoBitcoin.Repositories;
using ProjetoBitcoin.Services;

namespace ProjetoBitcoin
{
    public partial class Form1 : Form
    {
        private readonly BitcoinController _controller;

        public Form1()
        {
            InitializeComponent();

            // Definindo a string de conexão com o banco de dados e a URL da API do CoinGecko
            var connectionString = "Server=MATEUS;Database=CoinGeckoDb;Integrated Security=True";
            var apiUrl = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd&include_24hr_change=true";

            // Inicializando o serviço, repositório e controlador para trabalhar com os dados do Bitcoin
            var service = new BitcoinService(apiUrl);
            var repository = new BitcoinRepository(connectionString);
            _controller = new BitcoinController(service, repository);

            // Adicionando a coluna 'Status Preço BTC' no DataGridView para mostrar o status do preço do Bitcoin
            dataGridView1.Columns.Add("ColunaStatus", "Status Preço BTC");
        }

        // Evento para consultar os dados da API quando o botão "Consultar Dados" for clicado
        private async void buttonConsultarDados_Click(object sender, EventArgs e)
        {
            try
            {
                // Consultando os dados da API
                var dados = await _controller.ConsultarDadosAsync();

                // Atualizando o DataGridView com os dados recebidos
                AtualizarGrid(dados);
            }
            catch (Exception ex)
            {
                // Caso ocorra um erro, exibe uma mensagem de erro
                MessageBox.Show($"Erro ao consultar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para gravar os dados no banco de dados quando o botão "Gravar Dados" for clicado
        private void buttonGravarDados_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificando se o DataGridView contém dados
                if (dataGridView1.Rows.Count > 0)
                {
                    var dados = new List<BitcoinData>();

                    // Percorrendo as linhas do DataGridView e coletando os dados
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null) // Verificando se a célula contém dados
                        {
                            // Removendo o caractere '%' da variação e convertendo o valor para double
                            var variacaoString = row.Cells[3].Value.ToString();
                            var variacaoSemPercentual = variacaoString.Replace("%", "").Trim(); // Remover o '%' da variação

                            // Adicionando os dados na lista de dados
                            dados.Add(new BitcoinData
                            {
                                DataAtual = Convert.ToDateTime(row.Cells[0].Value),
                                PrecoAtual = Convert.ToDouble(row.Cells[1].Value),
                                PrecoAnterior = Convert.ToDouble(row.Cells[2].Value),
                                Variacao = Convert.ToDouble(variacaoSemPercentual) // Converte a variação sem o símbolo '%'
                            });
                        }
                    }

                    // Verificando se há dados para gravar
                    if (dados.Count > 0)
                    {
                        // Salvando os dados no banco de dados
                        _controller.SalvarDados(dados);
                        MessageBox.Show("Dados salvos com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Caso não haja dados para gravar
                        MessageBox.Show("Não há dados para gravar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Caso o DataGridView esteja vazio
                    MessageBox.Show("O DataGridView está vazio. Não há dados para gravar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Caso ocorra um erro ao gravar os dados
                MessageBox.Show($"Erro ao gravar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Função para atualizar o DataGridView com os dados do Bitcoin
        private void AtualizarGrid(List<BitcoinData> dados)
        {
            // Adicionando uma nova linha no DataGridView para cada dado recebido
            foreach (var dado in dados)
            {
                // Calculando a variação em porcentagem e formatando com 2 casas decimais
                var variacao = dado.Variacao.ToString("0.00") + "%";

                // Verificando se o preço atual aumentou ou diminuiu em relação ao preço anterior
                var statusPreco = dado.PrecoAtual > dado.PrecoAnterior ? "BTC Aumentou" : "BTC Diminuiu";

                // Adicionando os dados na linha do DataGridView
                dataGridView1.Rows.Add(dado.DataAtual, dado.PrecoAtual.ToString("0.00"), dado.PrecoAnterior.ToString("0.00"), variacao, statusPreco);
            }
        }
    }
}
