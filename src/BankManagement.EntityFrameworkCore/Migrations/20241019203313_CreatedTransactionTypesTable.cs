using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BankManagement.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTransactionTypesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                schema: "BankManagement",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "SendIban",
                schema: "BankManagement",
                table: "Transactions",
                newName: "SenderIban");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                schema: "BankManagement",
                table: "Transactions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverIban",
                schema: "BankManagement",
                table: "Transactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TransactionTypeId",
                schema: "BankManagement",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeId",
                schema: "BankManagement",
                table: "Transactions",
                column: "TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                schema: "BankManagement",
                table: "Transactions",
                column: "AccountId",
                principalSchema: "BankManagement",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionType_TransactionTypeId",
                schema: "BankManagement",
                table: "Transactions",
                column: "TransactionTypeId",
                principalTable: "TransactionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                schema: "BankManagement",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionType_TransactionTypeId",
                schema: "BankManagement",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionTypeId",
                schema: "BankManagement",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ReceiverIban",
                schema: "BankManagement",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                schema: "BankManagement",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "SenderIban",
                schema: "BankManagement",
                table: "Transactions",
                newName: "SendIban");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                schema: "BankManagement",
                table: "Transactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                schema: "BankManagement",
                table: "Transactions",
                column: "AccountId",
                principalSchema: "BankManagement",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
