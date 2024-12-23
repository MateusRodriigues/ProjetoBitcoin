using System.Data.SqlClient; // Importa a biblioteca para trabalhar com o banco de dados SQL Server.
using ProjetoBitcoin.Models; // Importa o modelo de dados do Bitcoin.

namespace ProjetoBitcoin.Repositories
{
    // O BitcoinRepository é responsável por salvar os dados do Bitcoin no banco de dados.
    public class BitcoinRepository
    {
        private readonly string _connectionString; // Armazena a string de conexão com o banco de dados.

        // Construtor que recebe a string de conexão e inicializa o repositório.
        public BitcoinRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para salvar os dados de uma lista no banco de dados.
        public void SalvarDados(List<BitcoinData> dados)
        {
            // Abre a conexão com o banco de dados.
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open(); // Abre a conexão com o banco de dados.

                // Itera sobre cada dado da lista e insere no banco.
                foreach (var dado in dados)
                {
                    // Cria o comando SQL para inserir os dados na tabela BitcoinData.
                    var command = new SqlCommand("INSERT INTO dbo.BitcoinData (Data, PrecoAtual, PrecoAnterior, Variacao) VALUES (@Data, @PrecoAtual, @PrecoAnterior, @Variacao)", connection);

                    // Adiciona os parâmetros ao comando SQL para evitar SQL Injection.
                    command.Parameters.AddWithValue("@Data", dado.DataAtual);
                    command.Parameters.AddWithValue("@PrecoAtual", dado.PrecoAtual);
                    command.Parameters.AddWithValue("@PrecoAnterior", dado.PrecoAnterior);
                    command.Parameters.AddWithValue("@Variacao", dado.Variacao);

                    // Executa o comando para salvar os dados no banco de dados.
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
