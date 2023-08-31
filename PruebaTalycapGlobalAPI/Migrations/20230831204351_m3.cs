using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTalycapGlobalAPI.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Descuento",
                table: "LogisticaTerrestre",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrecioEnvioNormal",
                table: "LogisticaTerrestre",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Descuento",
                table: "LogisticaMaritima",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrecioEnvioNormal",
                table: "LogisticaMaritima",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descuento",
                table: "LogisticaTerrestre");

            migrationBuilder.DropColumn(
                name: "PrecioEnvioNormal",
                table: "LogisticaTerrestre");

            migrationBuilder.DropColumn(
                name: "Descuento",
                table: "LogisticaMaritima");

            migrationBuilder.DropColumn(
                name: "PrecioEnvioNormal",
                table: "LogisticaMaritima");
        }
    }
}
