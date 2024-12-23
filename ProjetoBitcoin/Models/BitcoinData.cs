namespace ProjetoBitcoin.Models
{
    public class BitcoinData  // Classe que representa os dados do Bitcoin. Cada instância dessa classe vai armazenar as informações de um dado de consulta.
    {
        public DateTime DataAtual { get; set; }  // A data e hora da consulta dos dados do Bitcoin.
        public double PrecoAtual { get; set; }  // O preço atual do Bitcoin no momento da consulta.
        public double PrecoAnterior { get; set; }  // O preço do Bitcoin anteriormente, usado para calcular a variação.
        public double Variacao { get; set; }  // A variação do preço do Bitcoin entre o momento atual e o anterior.
    }
}
