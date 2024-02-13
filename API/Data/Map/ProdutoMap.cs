using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Preço).IsRequired().HasColumnType("float");
            builder.Property(x => x.Estoque).HasColumnType("int");

            builder.HasOne(x => x.Loja).WithMany(x => x.Produtos).IsRequired(false).HasForeignKey(x => x.LojaID);
        }
    }
}
