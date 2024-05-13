using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Service.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CompanyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompaniesRelation_Accounts_AccountDataModelId",
                schema: "AccountModule",
                table: "CompaniesRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_CompaniesRelation_Companies_CompanyDataModelId",
                schema: "AccountModule",
                table: "CompaniesRelation");

            migrationBuilder.AddForeignKey(
                name: "FK_CompaniesRelation_Accounts_AccountDataModelId",
                schema: "AccountModule",
                table: "CompaniesRelation",
                column: "AccountDataModelId",
                principalSchema: "AccountModule",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompaniesRelation_Companies_CompanyDataModelId",
                schema: "AccountModule",
                table: "CompaniesRelation",
                column: "CompanyDataModelId",
                principalSchema: "AccountModule",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompaniesRelation_Accounts_AccountDataModelId",
                schema: "AccountModule",
                table: "CompaniesRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_CompaniesRelation_Companies_CompanyDataModelId",
                schema: "AccountModule",
                table: "CompaniesRelation");

            migrationBuilder.AddForeignKey(
                name: "FK_CompaniesRelation_Accounts_AccountDataModelId",
                schema: "AccountModule",
                table: "CompaniesRelation",
                column: "AccountDataModelId",
                principalSchema: "AccountModule",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompaniesRelation_Companies_CompanyDataModelId",
                schema: "AccountModule",
                table: "CompaniesRelation",
                column: "CompanyDataModelId",
                principalSchema: "AccountModule",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
