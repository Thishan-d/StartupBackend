using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartupCompanyInfrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StartupCompanies",
                columns: table => new
                {
                    StartupCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessDomain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossSales = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NetSales = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeCount = table.Column<int>(type: "int", nullable: false),
                    FounderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartupCompanies", x => x.StartupCompanyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StartupCompanies");
        }
    }
}
