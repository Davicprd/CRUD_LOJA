namespace API.Models
{
    public class LojaViewModel
    {
        public string Nome { get; set; }
        public string Endereço { get; set; }
        public string Telefone { get; set; }
        public ICollection<ProdutoViewModel> Produtos { get; } = new List<ProdutoViewModel>();
    }
} 
