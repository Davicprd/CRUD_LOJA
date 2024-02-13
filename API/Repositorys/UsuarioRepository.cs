using API.Data;
using API.Models;
using API.Repositórios.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Repositórios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _context;
        public UsuarioRepository(Contexto context)
        {
            _context = context;
        }

        public async Task<List<UsuarioModel>> GetALL()
        {

            return await _context.usuário.ToListAsync();
        }

        public async Task<UsuarioModel> Get(int id)
        {

            var Usuario = await _context.usuário.Include(x => x.Descontos).FirstOrDefaultAsync(x => x.Id == id);
            if (Usuario == null)
            {
                throw new Exception($"Usuário com Id {id} não encontrado!");
            }
            else
            {
                return Usuario;
            }
        }
        public async Task<List<DescontoModel>> GetDescontos(int id)
        {

            var Descontos = await _context.desconto.Where(x => x.UsuarioID == id).ToListAsync();
            if (Descontos == null)
            {
                throw new Exception($"Usuário com Id {id} não possui Descontos");
            }
            else { return Descontos; }
        }

        public async Task<UsuarioModel> Add(UsuarioViewModel UsuarioModel)
        {
            if (UsuarioModel.Nome == "" || UsuarioModel.Nome == "string")
            {
                throw new Exception("Campo Nome Obrigatório!");
            }
            else if (UsuarioModel.Email == "" || UsuarioModel.Email == "string")
            {
                throw new Exception("Campo Email Obrigatório!");
            }
            else
            {
                UsuarioModel Usuario = new UsuarioModel();
                Usuario.Nome = UsuarioModel.Nome;
                Usuario.Email = UsuarioModel.Email;
                Usuario.Telefone = UsuarioModel.Telefone;
                await _context.usuário.AddAsync(Usuario);
                await _context.SaveChangesAsync();
                return Usuario;
            }
        }

        public async Task<UsuarioModel> Update(UsuarioViewModel UsuarioModel, int id)
        {
            if (UsuarioModel.Nome == "" || UsuarioModel.Nome == "string")
            {
                throw new Exception("Campo Nome Obrigatório!");
            }
            else if (UsuarioModel.Email == "" || UsuarioModel.Email == "string")
            {
                throw new Exception("Campo Email Obrigatório!");
            }
            else
            {
                UsuarioModel UsuarioId = await Get(id);
                UsuarioId.Nome = UsuarioModel.Nome;
                UsuarioId.Email = UsuarioModel.Email;
                UsuarioId.Telefone = UsuarioModel.Telefone;
                _context.usuário.Update(UsuarioId);
                await _context.SaveChangesAsync();
                return UsuarioId;
            }
            

        }

        public async Task<bool> Delete(int id)
        {
            UsuarioModel UsuarioId = await Get(id);
            _context.usuário.Remove(UsuarioId);
            await _context.SaveChangesAsync();
            return true;
            
        }

    }
}
