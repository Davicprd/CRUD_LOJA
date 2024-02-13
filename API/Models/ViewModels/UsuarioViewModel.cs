namespace API.Models
{
    public class UsuarioViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public ICollection<DescontoViewModel> Descontos { get; } = new List<DescontoViewModel>();
    }
}
