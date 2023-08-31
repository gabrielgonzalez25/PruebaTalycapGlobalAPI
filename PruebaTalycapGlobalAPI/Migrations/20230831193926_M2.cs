using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTalycapGlobalAPI.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Celular = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "LogisticaMaritima",
                columns: table => new
                {
                    NumeroGuia = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    TipoProducto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CantidadProducto = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioEnvio = table.Column<double>(type: "float", nullable: false),
                    NumeroFlota = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogisticaMaritima", x => x.NumeroGuia);
                });

            migrationBuilder.CreateTable(
                name: "LogisticaTerrestre",
                columns: table => new
                {
                    NumeroGuia = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    TipoProducto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CantidadProducto = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioEnvio = table.Column<double>(type: "float", nullable: false),
                    PlacaVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogisticaTerrestre", x => x.NumeroGuia);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "LogisticaMaritima");

            migrationBuilder.DropTable(
                name: "LogisticaTerrestre");
        }
    }
}
