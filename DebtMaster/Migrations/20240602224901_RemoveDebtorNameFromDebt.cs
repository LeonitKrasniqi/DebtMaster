using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DebtMaster.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDebtorNameFromDebt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebtorName",
                table: "Debts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DebtorName",
                table: "Debts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
