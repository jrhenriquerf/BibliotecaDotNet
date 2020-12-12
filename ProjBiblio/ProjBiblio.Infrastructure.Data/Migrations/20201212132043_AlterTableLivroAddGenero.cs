using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjBiblio.Infrastructure.Data.Migrations
{
    public partial class AlterTableLivroAddGenero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneroID",
                table: "Livro",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livro_GeneroID",
                table: "Livro",
                column: "GeneroID");

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Genero_GeneroID",
                table: "Livro",
                column: "GeneroID",
                principalTable: "Genero",
                principalColumn: "GeneroID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Genero_GeneroID",
                table: "Livro");

            migrationBuilder.DropIndex(
                name: "IX_Livro_GeneroID",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "GeneroID",
                table: "Livro");
        }
    }
}
