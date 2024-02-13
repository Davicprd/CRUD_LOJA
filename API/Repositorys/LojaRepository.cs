using API.Data;
using API.Models;
using API.Repositórios.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Repositórios
{
    public class LojaRepository : ILojaRepository
    {
        private readonly Contexto _context;
        public LojaRepository(Contexto context)
        { 
            _context = context;
        }

        public async Task<List<LojaModel>> GetALL()
        {
            return await _context.loja.ToListAsync();
        }

        public async Task<LojaModel> Get(int id)
        {
            var Loja = await _context.loja.Include(x => x.Produtos).FirstOrDefaultAsync(x => x.Id == id);
            if (Loja == null)
            {
                throw new Exception($"Loja com Id {id} não encontrada!");
            }
            else { return Loja; }

        }

        public async Task<List<ProdutoModel>> GetProdutos(int id)
        {

            var Produtos = await _context.produto.Where(x => x.LojaID == id).ToListAsync();
            if (Produtos == null)
            {
                throw new Exception($"Loja com Id {id} não possui Produtos");
            }
            else { return Produtos; }
        }

        public async Task<LojaModel> Add(LojaViewModel LojaModel)
        {
            if ( LojaModel.Nome == "string" || LojaModel.Nome == "")
            {
                throw new Exception("Campo Nome Obrigatório!");
            }
            else if ( LojaModel.Endereço == "string" || LojaModel.Nome == "")
            {
                throw new Exception("Campo Endereço Obrigatório!");
            }
            else 
            { 
                LojaModel Loja = new LojaModel();
                Loja.Nome = LojaModel.Nome;
                Loja.Endereço = LojaModel.Endereço;
                Loja.Telefone = LojaModel.Telefone;
                await _context.loja.AddAsync(Loja);
                await _context.SaveChangesAsync();
                return await Get(Loja.Id);
            }
        }

        public async Task<LojaModel> Update(LojaViewModel LojaModel, int id)
        {
            if (LojaModel.Nome == "" || LojaModel.Nome == "string")
            {
                throw new Exception("Campo Nome Obrigatório!");
            }
            else if (LojaModel.Endereço == "" || LojaModel.Endereço == "string")
            {
                throw new Exception("Campo Endereço Obrigatório!");
            }
            else
            {
                LojaModel LojaId = await Get(id);
                LojaId.Nome = LojaModel.Nome;
                LojaId.Endereço = LojaModel.Endereço;
                LojaId.Telefone = LojaModel.Telefone;
                _context.loja.Update(LojaId);
                await _context.SaveChangesAsync();
                return LojaId;
            }

        }

        public async Task<bool> Delete(int id)
        {
            LojaModel LojaId = await Get(id);
            _context.loja.Remove(LojaId);
            await _context.SaveChangesAsync();
            return true;
            
        }

    }
}
