using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Telefone).HasColumnType("varchar(50)");

            builder.HasMany(x => x.Descontos).WithOne(x => x.Usuario).IsRequired().HasForeignKey(x => x.UsuarioID);

        }
    }
}

