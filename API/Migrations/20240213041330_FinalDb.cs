using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class FinalDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereço = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(50)", nullable: true, defaultValue: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuário",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuário", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Preço = table.Column<double>(type: "float", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    LojaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_produto_loja_LojaID",
                        column: x => x.LojaID,
                        principalTable: "loja",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "desconto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Taxa = table.Column<double>(type: "float", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_desconto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_desconto_usuário_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuário",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_desconto_UsuarioID",
                table: "desconto",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_produto_LojaID",
                table: "produto",
                column: "LojaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "desconto");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "usuário");

            migrationBuilder.DropTable(
                name: "loja");
        }
    }
}
