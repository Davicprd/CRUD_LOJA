using API.Models;

namespace API.Repositórios.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> GetALL();
        Task<UsuarioModel> Get(int Id);
        Task<List<DescontoModel>> GetDescontos(int Id);
        Task<UsuarioModel> Add(UsuarioViewModel Usuario);
        Task<UsuarioModel> Update(UsuarioViewModel Usuario, int Id);
        Task<bool> Delete(int Id);
    }
}
