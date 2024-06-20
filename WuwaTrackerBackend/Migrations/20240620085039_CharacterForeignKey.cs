using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuwaTrackerBackend.Migrations
{
    /// <inheritdoc />
    public partial class CharacterForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Flowers_FlowerTypeID",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Materials_MaterialTypeID",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_TacetCores_TacetCoreTypeID",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_FlowerTypeID",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_MaterialTypeID",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_TacetCoreTypeID",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "TacetCoreTypeID",
                table: "Characters",
                newName: "TacetCoreID");

            migrationBuilder.RenameColumn(
                name: "MaterialTypeID",
                table: "Characters",
                newName: "MaterialID");

            migrationBuilder.RenameColumn(
                name: "FlowerTypeID",
                table: "Characters",
                newName: "FlowerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TacetCoreID",
                table: "Characters",
                newName: "TacetCoreTypeID");

            migrationBuilder.RenameColumn(
                name: "MaterialID",
                table: "Characters",
                newName: "MaterialTypeID");

            migrationBuilder.RenameColumn(
                name: "FlowerID",
                table: "Characters",
                newName: "FlowerTypeID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Flowers_FlowerTypeID",
                table: "Characters",
                column: "FlowerTypeID",
                principalTable: "Flowers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Materials_MaterialTypeID",
                table: "Characters",
                column: "MaterialTypeID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_TacetCores_TacetCoreTypeID",
                table: "Characters",
                column: "TacetCoreTypeID",
                principalTable: "TacetCores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
