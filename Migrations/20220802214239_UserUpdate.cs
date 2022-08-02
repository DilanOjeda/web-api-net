using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "tb_user");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_user",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "tb_user",
                newName: "birthdate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_user",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_user",
                table: "tb_user",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_user",
                table: "tb_user");

            migrationBuilder.RenameTable(
                name: "tb_user",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "birthdate",
                table: "Users",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
