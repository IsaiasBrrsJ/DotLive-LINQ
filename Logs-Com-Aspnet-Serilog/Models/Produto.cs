namespace ApiExec.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public decimal Preco { get; set;} = decimal.Zero;

        public DateTime DataValidade { get; set; }

        public DateTime DataFrabricacao { get; set; }

        public virtual Estoque Estoque { get; set; }
    }
}
