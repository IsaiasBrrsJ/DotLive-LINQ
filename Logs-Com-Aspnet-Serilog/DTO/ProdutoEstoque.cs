using ApiExec.Models;

namespace ApiExec.DTO
{
    public class ProdutoEstoque
    {
        public string Nome { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public decimal Preco { get; set; } = decimal.Zero;

        public DateTime DataValidade { get; set; }

        public DateTime DataFrabricacao { get; set; }

        public int Quantidade { get; set; }




    }
}
