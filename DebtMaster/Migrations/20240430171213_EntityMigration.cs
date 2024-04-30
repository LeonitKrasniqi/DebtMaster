using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DebtMaster.Migrations
{
    /// <inheritdoc />
    public partial class EntityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Debts",
                newName: "DebtorId");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Debts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Debts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Debts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Debts");

            migrationBuilder.RenameColumn(
                name: "DebtorId",
                table: "Debts",
                newName: "Id");
        }
    }
}
