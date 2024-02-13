using API.Models;

namespace API.Repositórios.Interfaces
{
    public interface ILojaRepository
    {
       Task<List<LojaModel>> GetALL();
       Task<LojaModel> Get(int Id);
       Task<List<ProdutoModel>> GetProdutos(int id);  
       Task<LojaModel> Add(LojaViewModel Loja);
       Task<LojaModel> Update(LojaViewModel Loja, int Id);
       Task<bool> Delete(int Id);
    }
}
