using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudUsuario.Infra.Migrations
{
    public partial class MigrationsUm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
