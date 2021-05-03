using Microsoft.EntityFrameworkCore.Migrations;

namespace WymianaKsiazek.Api.Migrations
{
    public partial class AddAddressDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gmina",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Powiat",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wojewodztwo",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gmina",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Powiat",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Wojewodztwo",
                table: "Address");
        }
    }
}
