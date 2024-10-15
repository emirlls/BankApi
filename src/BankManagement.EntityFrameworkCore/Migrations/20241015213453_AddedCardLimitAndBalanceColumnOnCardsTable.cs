using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddedCardLimitAndBalanceColumnOnCardsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Balance",
                schema: "BankManagement",
                table: "Cards",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "CardLimit",
                schema: "BankManagement",
                table: "Cards",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                schema: "BankManagement",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardLimit",
                schema: "BankManagement",
                table: "Cards");
        }
    }
}
