using API.Data;
using API.Models;
using API.Repositórios.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Repositórios
{
    public class DescontoRepository : IDescontoRepository
    {
        private readonly Contexto _context;
        public DescontoRepository(Contexto context)
        {
            _context = context;
        }

        public async Task<List<DescontoModel>> GetALL()
        {
            return await _context.desconto.ToListAsync();
        }

        public async Task<DescontoModel> Get(int id)
        {
            var Desconto = await _context.desconto.FirstOrDefaultAsync(x => x.Id == id);
            if (Desconto == null) 
            {
                throw new Exception($"Desconto com Id {id} não encontrado");
            }
            else { return Desconto; }
        }

        public async Task<DescontoModel> Add(DescontoViewModel DescontoModel)
        {
            if (DescontoModel.Nome == "" || DescontoModel.Nome == "string")
            {
                throw new Exception("Campo Nome Obrigatório!");
            }
            else if (DescontoModel.Taxa == 0)
            {
                throw new Exception("Campo Taxa Obrigatório!");
            }
            if (DescontoModel.Taxa > 1 || DescontoModel.Taxa < 0)
            {
                throw new Exception("Campo Taxa deve variar de 0 a 1!");
            }
            else
            {
                DescontoModel Desconto = new DescontoModel();
                Desconto.Nome = DescontoModel.Nome;
                Desconto.Taxa = DescontoModel.Taxa;
                Desconto.UsuarioID = DescontoModel.UsuarioID;
                await _context.desconto.AddAsync(Desconto);
                await _context.SaveChangesAsync();
                return Desconto;
            }
        }

        public async Task<DescontoModel> Update(DescontoViewModel DescontoModel, int id)
        {
            if (DescontoModel.Nome == "" || DescontoModel.Nome == "string")
            {
                throw new Exception("Campo Nome Obrigatório!");
            }
            else if (DescontoModel.Taxa == 0)
            {
                throw new Exception("Campo Taxa Obrigatório!");
            }
            if (DescontoModel.Taxa > 1 || DescontoModel.Taxa < 0)
            {
                throw new Exception("Campo Taxa deve variar de 0 a 1!");
            }
            else
            {
                DescontoModel DescontoId = await Get(id);
                DescontoId.Nome = DescontoModel.Nome;
                DescontoId.Taxa = DescontoModel.Taxa;
                DescontoId.UsuarioID = DescontoModel.UsuarioID;
                _context.desconto.Update(DescontoId);
                await _context.SaveChangesAsync();
                return DescontoId;
            }
        }

        public async Task<bool> Delete(int id)
        {
            DescontoModel DescontoId = await Get(id);
            _context.desconto.Remove(DescontoId);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

