using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRepository.Data.Migrations
{
    public partial class Ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dateofmanufac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarInform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarPrice = table.Column<double>(type: "float", nullable: false),
                    CarPriceGel = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abs = table.Column<bool>(type: "bit", nullable: false),
                    PowerWindows = table.Column<bool>(type: "bit", nullable: false),
                    Hatch = table.Column<bool>(type: "bit", nullable: false),
                    Bluetooth = table.Column<bool>(type: "bit", nullable: false),
                    Signaling = table.Column<bool>(type: "bit", nullable: false),
                    ParkingControl = table.Column<bool>(type: "bit", nullable: false),
                    Navigation = table.Column<bool>(type: "bit", nullable: false),
                    OnboardComputer = table.Column<bool>(type: "bit", nullable: false),
                    MultiWheel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_models", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "models");
        }
    }
}
