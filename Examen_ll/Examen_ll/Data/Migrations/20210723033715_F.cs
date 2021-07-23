using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen_ll.Data.Migrations
{
    public partial class F : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId1",
                table: "Tareas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNombre = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Categoria_CategoriaId1",
                table: "Tareas");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_CategoriaId1",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "CategoriaId1",
                table: "Tareas");
        }
    }
}
