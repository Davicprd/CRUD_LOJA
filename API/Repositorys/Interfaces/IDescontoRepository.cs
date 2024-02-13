using API.Models;

namespace API.Repositórios.Interfaces
{
    public interface IDescontoRepository
    {
        Task<List<DescontoModel>> GetALL();
        Task<DescontoModel> Get(int Id);
        Task<DescontoModel> Add(DescontoViewModel Desconto);
        Task<DescontoModel> Update(DescontoViewModel Desconto, int Id);
        Task<bool> Delete(int Id);
    }
}
