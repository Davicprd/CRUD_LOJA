using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Map
{
    public class DescontoMap : IEntityTypeConfiguration<DescontoModel>
    {
        public void Configure(EntityTypeBuilder<DescontoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Taxa).IsRequired().HasColumnType("float");

            builder.HasOne(x => x.Usuario).WithMany(x => x.Descontos).IsRequired().HasForeignKey(x => x.UsuarioID);

        }
    }
}

