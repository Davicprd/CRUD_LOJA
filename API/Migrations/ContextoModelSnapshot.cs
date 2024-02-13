﻿// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.DescontoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Taxa")
                        .HasColumnType("float");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioID");

                    b.ToTable("desconto");
                });

            modelBuilder.Entity("API.Models.LojaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Endereço")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("0");

                    b.HasKey("Id");

                    b.ToTable("loja");
                });

            modelBuilder.Entity("API.Models.ProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<int>("LojaID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Preço")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("LojaID");

                    b.ToTable("produto");
                });

            modelBuilder.Entity("API.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("usuário");
                });

            modelBuilder.Entity("API.Models.DescontoModel", b =>
                {
                    b.HasOne("API.Models.UsuarioModel", "Usuario")
                        .WithMany("Descontos")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API.Models.ProdutoModel", b =>
                {
                    b.HasOne("API.Models.LojaModel", "Loja")
                        .WithMany("Produtos")
                        .HasForeignKey("LojaID");

                    b.Navigation("Loja");
                });

            modelBuilder.Entity("API.Models.LojaModel", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("API.Models.UsuarioModel", b =>
                {
                    b.Navigation("Descontos");
                });
#pragma warning restore 612, 618
        }
    }
}
