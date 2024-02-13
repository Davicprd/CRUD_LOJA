using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Map
{
    public class LojaMap : IEntityTypeConfiguration<LojaModel>
    {
        public void Configure(EntityTypeBuilder<LojaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Endereço).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Telefone).HasColumnType("varchar(50)").IsRequired(false).HasDefaultValue("0");

            builder.HasMany(x => x.Produtos).WithOne(x => x.Loja).IsRequired().HasForeignKey(x => x.LojaID);
        }
    }
}
