using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankManagement.Migrations
{
    /// <inheritdoc />
    public partial class DeletedCardOwnerColumnOnCardsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardOwner",
                schema: "BankManagement",
                table: "Cards");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "BankManagement",
                table: "Cards",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "BankManagement",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "CardOwner",
                schema: "BankManagement",
                table: "Cards",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
