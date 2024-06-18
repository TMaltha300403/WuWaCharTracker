using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuwaTrackerBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flowers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flowers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameLow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameMedium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameHigh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameHighest = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TacetCores",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacetCores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlowerTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TacetCoreTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Characters_Flowers_FlowerTypeID",
                        column: x => x.FlowerTypeID,
                        principalTable: "Flowers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Materials_MaterialTypeID",
                        column: x => x.MaterialTypeID,
                        principalTable: "Materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_TacetCores_TacetCoreTypeID",
                        column: x => x.TacetCoreTypeID,
                        principalTable: "TacetCores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_FlowerTypeID",
                table: "Characters",
                column: "FlowerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MaterialTypeID",
                table: "Characters",
                column: "MaterialTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_TacetCoreTypeID",
                table: "Characters",
                column: "TacetCoreTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Flowers");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "TacetCores");
        }
    }
}
