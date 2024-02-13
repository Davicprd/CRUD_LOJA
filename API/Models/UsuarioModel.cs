using Microsoft.EntityFrameworkCore.Query.Internal;

namespace API.Models
{
    public class UsuarioModel
    {
        public int Id { get; init; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public ICollection<DescontoModel> Descontos { get; } = new List<DescontoModel>();
    }
}
