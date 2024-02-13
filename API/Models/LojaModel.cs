using Microsoft.AspNetCore.Mvc;

namespace API.Models
{
    public class LojaModel
    {
        public int Id { get; init; }
        public string Nome { get; set; }
        public string Endereço { get; set; }
        public string Telefone { get; set; }
        public ICollection<ProdutoModel> Produtos { get; } = new List<ProdutoModel>();
    }
} 
