using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrmCustomers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    HoldingCompany = table.Column<string>(nullable: true),
                    ContactPoint = table.Column<string>(nullable: true),
                    AccountManagerId = table.Column<long>(nullable: true),
                    TimeCooperation = table.Column<DateTime>(nullable: true),
                    TimeStopCooperation = table.Column<DateTime>(nullable: true),
                    TimeSettlement = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrmCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreSale",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    ContractType = table.Column<int>(nullable: true),
                    Size = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ProjectManager = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreSale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerVisitHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrmCustomerId = table.Column<long>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    FinishDate = table.Column<DateTime>(nullable: true),
                    Ingredient = table.Column<string>(nullable: true),
                    Restaurant = table.Column<string>(nullable: true),
                    Gift = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerVisitHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerVisitHistory_CrmCustomers_CrmCustomerId",
                        column: x => x.CrmCustomerId,
                        principalTable: "CrmCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreSaleId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogHistory_PreSale_PreSaleId",
                        column: x => x.PreSaleId,
                        principalTable: "PreSale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notify",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogHistoryId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notify", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notify_LogHistory_LogHistoryId",
                        column: x => x.LogHistoryId,
                        principalTable: "LogHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerVisitHistory_CrmCustomerId",
                table: "CustomerVisitHistory",
                column: "CrmCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_LogHistory_PreSaleId",
                table: "LogHistory",
                column: "PreSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Notify_LogHistoryId",
                table: "Notify",
                column: "LogHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerVisitHistory");

            migrationBuilder.DropTable(
                name: "Notify");

            migrationBuilder.DropTable(
                name: "CrmCustomers");

            migrationBuilder.DropTable(
                name: "LogHistory");

            migrationBuilder.DropTable(
                name: "PreSale");
        }
    }
}
