using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Livraria.Migrations
{
    /// <inheritdoc />
    public partial class attmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Livros",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Estoque",
                table: "Livros",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Livros",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "imagemCapa",
                table: "Livros",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Biografia",
                table: "Autor",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "imagemCapa",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Biografia",
                table: "Autor");
        }
    }
}
