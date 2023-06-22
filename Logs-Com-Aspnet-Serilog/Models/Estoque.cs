namespace ApiExec.Models
{
    public class Estoque
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public virtual Produto Produto { get; set; } = null!;

        public int ProdutoId { get; set; }

    }
}
