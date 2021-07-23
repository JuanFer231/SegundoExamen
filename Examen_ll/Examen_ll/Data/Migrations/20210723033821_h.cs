using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen_ll.Data.Migrations
{
    public partial class h : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Categoria_CategoriaId1",
                table: "Tareas");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_CategoriaId1",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "CategoriaId1",
                table: "Tareas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId1",
                table: "Tareas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_CategoriaId1",
                table: "Tareas",
                column: "CategoriaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Categoria_CategoriaId1",
                table: "Tareas",
                column: "CategoriaId1",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
