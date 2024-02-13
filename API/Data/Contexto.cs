using API.Data.Map;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) 
            : base(options)
        {
        }  

        public DbSet<UsuarioModel> usuário { get; set; }
        public DbSet <LojaModel> loja { get; set; }
        public DbSet<ProdutoModel> produto { get; set; }
        public DbSet<DescontoModel> desconto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LojaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new DescontoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
