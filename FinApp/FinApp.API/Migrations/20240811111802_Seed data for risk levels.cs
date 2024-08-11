using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinApp.API.Migrations
{
    /// <inheritdoc />
    public partial class Seeddataforrisklevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RiskLevel",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0b427ccc-94cd-47ed-b1e1-a2324c0ba332"), "High" },
                    { new Guid("9c3a85c1-09bb-4742-9d05-e4e1d6db7dd3"), "Low" },
                    { new Guid("f2ea49ae-1384-4f24-a0fb-6aac27ae76fb"), "Medium" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RiskLevel",
                keyColumn: "Id",
                keyValue: new Guid("0b427ccc-94cd-47ed-b1e1-a2324c0ba332"));

            migrationBuilder.DeleteData(
                table: "RiskLevel",
                keyColumn: "Id",
                keyValue: new Guid("9c3a85c1-09bb-4742-9d05-e4e1d6db7dd3"));

            migrationBuilder.DeleteData(
                table: "RiskLevel",
                keyColumn: "Id",
                keyValue: new Guid("f2ea49ae-1384-4f24-a0fb-6aac27ae76fb"));
        }
    }
}
