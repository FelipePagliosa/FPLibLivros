using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryLivros.Infra.Migrations
{
    public partial class TremAcompHistorico04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUserGateway",
                table: "User",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUserGateway",
                table: "User");
        }
    }
}
