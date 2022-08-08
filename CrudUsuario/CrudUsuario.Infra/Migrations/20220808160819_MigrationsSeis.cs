using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudUsuario.Infra.Migrations
{
    public partial class MigrationsSeis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "users",
                type: "DATETIME",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "users");
        }
    }
}
