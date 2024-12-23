using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProjetoBitcoin.Models;

namespace ProjetoBitcoin.Repositories
{
    public class BitcoinRepository
    {
        private readonly string _connectionString;

        public BitcoinRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SalvarDados(List<BitcoinData> dados)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                foreach (var dado in dados)
                {
                    var command = new SqlCommand("INSERT INTO dbo.BitcoinData (Data, PrecoAtual, PrecoAnterior, Variacao) VALUES (@Data, @PrecoAtual, @PrecoAnterior, @Variacao)", connection);
                    command.Parameters.AddWithValue("@Data", dado.DataAtual);
                    command.Parameters.AddWithValue("@PrecoAtual", dado.PrecoAtual);
                    command.Parameters.AddWithValue("@PrecoAnterior", dado.PrecoAnterior);
                    command.Parameters.AddWithValue("@Variacao", dado.Variacao);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
