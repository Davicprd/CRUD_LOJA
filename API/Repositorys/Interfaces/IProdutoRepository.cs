using API.Models;

namespace API.Repositórios.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<ProdutoModel>> GetALL();
        Task<ProdutoModel> Get(int Id);
        Task<DescontoModel> GetDesconto(int UsuarioId);
        Task<ProdutoModel> Add(ProdutoViewModel Produto);
        Task<ProdutoModel> Update(ProdutoViewModel Produto, int Id);
        Task<bool> Delete(int Id);
    }
}
