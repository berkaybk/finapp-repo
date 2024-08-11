using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinApp.API.Migrations
{
    /// <inheritdoc />
    public partial class InıtialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RiskLevel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RiskLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agreements_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agreements_RiskLevel_RiskLevelId",
                        column: x => x.RiskLevelId,
                        principalTable: "RiskLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialStatements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgreementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Expenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialStatements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialStatements_Agreements_AgreementId",
                        column: x => x.AgreementId,
                        principalTable: "Agreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiskAnalyses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgreementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RiskScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskAnalyses_Agreements_AgreementId",
                        column: x => x.AgreementId,
                        principalTable: "Agreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgreementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Agreements_AgreementId",
                        column: x => x.AgreementId,
                        principalTable: "Agreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_PartnerId",
                table: "Agreements",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_RiskLevelId",
                table: "Agreements",
                column: "RiskLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialStatements_AgreementId",
                table: "FinancialStatements",
                column: "AgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskAnalyses_AgreementId",
                table: "RiskAnalyses",
                column: "AgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_AgreementId",
                table: "Subjects",
                column: "AgreementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialStatements");

            migrationBuilder.DropTable(
                name: "RiskAnalyses");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "RiskLevel");
        }
    }
}
