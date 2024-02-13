namespace API.Models
{
    public class DescontoModel
    {
        public int Id { get; init; }
        public string Nome { get; set; }
        public float Taxa { get; set; }
        public int UsuarioID { get; set; }
        public virtual UsuarioModel? Usuario { get; set; } = null!;

    }
}
