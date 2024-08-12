using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinApp.API.Migrations
{
    /// <inheritdoc />
    public partial class risklevelstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_RiskLevel_RiskLevelId",
                table: "Agreements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RiskLevel",
                table: "RiskLevel");

            migrationBuilder.RenameTable(
                name: "RiskLevel",
                newName: "RiskLevels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RiskLevels",
                table: "RiskLevels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_RiskLevels_RiskLevelId",
                table: "Agreements",
                column: "RiskLevelId",
                principalTable: "RiskLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_RiskLevels_RiskLevelId",
                table: "Agreements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RiskLevels",
                table: "RiskLevels");

            migrationBuilder.RenameTable(
                name: "RiskLevels",
                newName: "RiskLevel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RiskLevel",
                table: "RiskLevel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_RiskLevel_RiskLevelId",
                table: "Agreements",
                column: "RiskLevelId",
                principalTable: "RiskLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
