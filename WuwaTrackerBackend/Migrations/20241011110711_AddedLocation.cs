using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuwaTrackerBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FlowerLocation",
                columns: table => new
                {
                    FlowersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerLocation", x => new { x.FlowersID, x.LocationsID });
                    table.ForeignKey(
                        name: "FK_FlowerLocation_Flowers_FlowersID",
                        column: x => x.FlowersID,
                        principalTable: "Flowers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowerLocation_Location_LocationsID",
                        column: x => x.LocationsID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlowerLocation_LocationsID",
                table: "FlowerLocation",
                column: "LocationsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowerLocation");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
