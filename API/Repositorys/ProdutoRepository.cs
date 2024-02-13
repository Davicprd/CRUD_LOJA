using API.Data;
using API.Models;
using API.Repositórios.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Repositórios
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Contexto _context;
        public ProdutoRepository(Contexto context)
        {
            _context = context;
        }

        public async Task<List<ProdutoModel>> GetALL()
        {
            return await _context.produto.ToListAsync();
        }

        public async Task<ProdutoModel> Get(int id)
        {
            var Produto = await _context.produto.FirstOrDefaultAsync(x => x.Id == id);
            if (Produto == null) 
            {
                throw new Exception($"Produto com Id {id} não encontrado");
            }
            else { return Produto; }
        }
        public async Task<DescontoModel> GetDesconto(int UsuarioId)
        {

            var Desconto =  await _context.desconto.OrderByDescending(x => x.Taxa).FirstOrDefaultAsync();
            if (Desconto == null)
            {
                throw new Exception($"Usuário com Id {UsuarioId} não possui Descontos");
            }
            else { return  Desconto; }
        }

        public async Task<ProdutoModel> Add(ProdutoViewModel ProdutoModel)
        {
            if (ProdutoModel.Nome == "" || ProdutoModel.Nome == "string")
            {
                throw new Exception("Campo Nome Obrigatório!");
            }
            else if (ProdutoModel.Preço == 0)
            {
                throw new Exception("Campo Preço Obrigatório!");
            }
            else
            {
                ProdutoModel Produto = new ProdutoModel();
                Produto.Nome = ProdutoModel.Nome;
                Produto.Preço = ProdutoModel.Preço;
                Produto.Estoque = ProdutoModel.Estoque;
                Produto.LojaID = ProdutoModel.LojaID;
                await _context.produto.AddAsync(Produto);
                await _context.SaveChangesAsync();
                return Produto;
            }
        }

        public async Task<ProdutoModel> Update(ProdutoViewModel ProdutoModel, int id)
        {
            if (ProdutoModel.Nome == "" || ProdutoModel.Nome == "string")
            {
                throw new Exception("Campo Nome Obrigatório!");
            }
            else if (ProdutoModel.Preço == 0)
            {
                throw new Exception("Campo Preço Obrigatório!");
            }
            else
            {
                ProdutoModel ProdutoId = await Get(id);
                ProdutoId.Nome = ProdutoModel.Nome;
                ProdutoId.Preço = ProdutoModel.Preço;
                ProdutoId.Estoque = ProdutoModel.Estoque;
                _context.produto.Update(ProdutoId);
                await _context.SaveChangesAsync();
                return ProdutoId;
            }

        }

        public async Task<bool> Delete(int id)
        {
            ProdutoModel ProdutoId = await Get(id);
            _context.produto.Remove(ProdutoId);
            await _context.SaveChangesAsync();
            return true;
            
        }
    }
}

