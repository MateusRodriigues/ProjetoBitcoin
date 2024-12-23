using ProjetoBitcoin.Controllers; // Importa o controlador do projeto.
using ProjetoBitcoin.Models; // Importa os modelos de dados utilizados.
using ProjetoBitcoin.Repositories; // Importa os reposit�rios para manipula��o de dados.
using ProjetoBitcoin.Services; // Importa os servi�os para consumir a API e tratar os dados.

namespace ProjetoBitcoin
{
    public partial class Form1 : Form
    {
        private readonly BitcoinController _controller; // Controlador que lida com a l�gica de intera��o com os dados.

        // Construtor do formul�rio
        public Form1()
        {
            InitializeComponent(); // Inicializa os componentes do formul�rio (interface gr�fica).

            // Definindo a string de conex�o com o banco de dados e a URL da API do CoinGecko
            var connectionString = "Server=MATEUS;Database=CoinGeckoDb;Integrated Security=True";
            var apiUrl = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd&include_24hr_change=true";

            // Inicializando o servi�o, reposit�rio e controlador para trabalhar com os dados do Bitcoin
            var service = new BitcoinService(apiUrl); // Servi�o que se comunica com a API.
            var repository = new BitcoinRepository(connectionString); // Reposit�rio para salvar os dados no banco.
            _controller = new BitcoinController(service, repository); // Controlador que coordena os servi�os e reposit�rios.

            // Adicionando a coluna 'Status Pre�o BTC' no DataGridView para mostrar o status do pre�o do Bitcoin
            dataGridView1.Columns.Add("ColunaStatus", "Status Pre�o BTC"); // Adiciona coluna extra para o status do pre�o.
        }

        // Evento para consultar os dados da API quando o bot�o "Consultar Dados" for clicado
        private async void buttonConsultarDados_Click(object sender, EventArgs e)
        {
            try
            {
                // Consultando os dados da API atrav�s do controlador
                var dados = await _controller.ConsultarDadosAsync();

                // Atualizando o DataGridView com os dados recebidos
                AtualizarGrid(dados); // Atualiza a interface gr�fica com os dados.
            }
            catch (Exception ex)
            {
                // Caso ocorra um erro durante a consulta, exibe uma mensagem de erro
                MessageBox.Show($"Erro ao consultar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para gravar os dados no banco de dados quando o bot�o "Gravar Dados" for clicado
        private void buttonGravarDados_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificando se o DataGridView cont�m dados
                if (dataGridView1.Rows.Count > 0)
                {
                    var dados = new List<BitcoinData>(); // Lista para armazenar os dados que ser�o salvos no banco.

                    // Percorrendo as linhas do DataGridView e coletando os dados
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null) // Verifica se a c�lula cont�m dados
                        {
                            // Removendo o caractere '%' da varia��o e convertendo o valor para double
                            var variacaoString = row.Cells[3].Value.ToString(); // A varia��o � armazenada na quarta coluna.
                            var variacaoSemPercentual = variacaoString.Replace("%", "").Trim(); // Remove o '%' da string.

                            // Adicionando os dados extra�dos na lista de dados
                            dados.Add(new BitcoinData
                            {
                                DataAtual = Convert.ToDateTime(row.Cells[0].Value), // Data de captura dos dados.
                                PrecoAtual = Convert.ToDouble(row.Cells[1].Value), // Pre�o atual do Bitcoin.
                                PrecoAnterior = Convert.ToDouble(row.Cells[2].Value), // Pre�o anterior do Bitcoin.
                                Variacao = Convert.ToDouble(variacaoSemPercentual) // A varia��o (j� sem o '%').
                            });
                        }
                    }

                    // Verificando se h� dados para gravar no banco de dados
                    if (dados.Count > 0)
                    {
                        // Chamando o controlador para salvar os dados no banco
                        _controller.SalvarDados(dados);
                        MessageBox.Show("Dados salvos com sucesso!", "Informa��o", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Caso n�o haja dados para salvar, exibe um alerta
                        MessageBox.Show("N�o h� dados para gravar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Caso o DataGridView esteja vazio
                    MessageBox.Show("O DataGridView est� vazio. N�o h� dados para gravar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Caso ocorra um erro ao gravar os dados, exibe uma mensagem de erro
                MessageBox.Show($"Erro ao gravar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Fun��o para atualizar o DataGridView com os dados do Bitcoin
        private void AtualizarGrid(List<BitcoinData> dados)
        {
            // Adicionando uma nova linha no DataGridView para cada dado recebido
            foreach (var dado in dados)
            {
                // Calculando a varia��o em porcentagem e formatando com 2 casas decimais
                var variacao = dado.Variacao.ToString("0.00") + "%";

                // Verificando se o pre�o atual aumentou ou diminuiu em rela��o ao pre�o anterior
                var statusPreco = dado.PrecoAtual > dado.PrecoAnterior ? "BTC Aumentou" : "BTC Diminuiu";

                // Adicionando os dados na linha do DataGridView
                dataGridView1.Rows.Add(dado.DataAtual, dado.PrecoAtual.ToString("0.00"), dado.PrecoAnterior.ToString("0.00"), variacao, statusPreco);
            }
        }
    }
}
