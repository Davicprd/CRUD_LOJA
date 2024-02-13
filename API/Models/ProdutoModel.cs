namespace API.Models
{
    public class ProdutoModel
    {
        public int Id { get; init; }
        public string Nome { get; set; }
        public float Preço { get; set; }
        public int Estoque { get; set; }
        public int LojaID { get; set; }
        public virtual LojaModel? Loja { get; set; } = null!;

    }
}
