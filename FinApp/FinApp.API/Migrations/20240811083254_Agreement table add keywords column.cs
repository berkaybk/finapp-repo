using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinApp.API.Migrations
{
    /// <inheritdoc />
    public partial class Agreementtableaddkeywordscolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Keywords",
                table: "Agreements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Keywords",
                table: "Agreements");
        }
    }
}
