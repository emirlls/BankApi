using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankManagement.Migrations
{
    /// <inheritdoc />
    public partial class CreatedBranchAndBranchMapFeatureTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                schema: "BankManagement",
                table: "Accounts");

            migrationBuilder.DeleteData(
                schema: "BankManagement",
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("6c31cd15-a33f-4564-956f-5d87d0c6a4fe"));

            migrationBuilder.DeleteData(
                schema: "BankManagement",
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("773ce647-3ec2-4e6e-9eec-3ba8fce2c33a"));

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "BranchTypes",
                schema: "BankManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    Code = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                schema: "BankManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    BranchTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_BranchTypes_BranchTypeId",
                        column: x => x.BranchTypeId,
                        principalSchema: "BankManagement",
                        principalTable: "BranchTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BranchMapFeatures",
                schema: "BankManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Geom = table.Column<Geometry>(type: "geometry", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchMapFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchMapFeatures_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "BankManagement",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("3018286c-3eb3-4710-a2ea-a82948c80596"),
                column: "CreationTime",
                value: new DateTime(2025, 7, 27, 2, 45, 7, 810, DateTimeKind.Local).AddTicks(3947));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("d2333569-8720-4f19-97b3-ef8d7d1f19d1"),
                column: "CreationTime",
                value: new DateTime(2025, 7, 27, 2, 45, 7, 810, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.InsertData(
                schema: "BankManagement",
                table: "BranchTypes",
                columns: new[] { "Id", "Code", "CreationTime", "CreatorId", "IsActive", "Name", "TenantId" },
                values: new object[,]
                {
                    { new Guid("5126bb9a-4c1c-4284-96fd-58bed40a1689"), 1, new DateTime(2025, 7, 27, 2, 45, 7, 810, DateTimeKind.Local).AddTicks(4311), null, false, "Branch", null },
                    { new Guid("ff7a39f0-6b2e-46e1-a878-7a04de16a6e8"), 2, new DateTime(2025, 7, 27, 2, 45, 7, 810, DateTimeKind.Local).AddTicks(4317), null, false, "Atm", null }
                });

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "CardTypes",
                keyColumn: "Id",
                keyValue: new Guid("42f63785-93f9-4b53-9038-9499455d9cd5"),
                column: "CreationTime",
                value: new DateTime(2025, 7, 27, 2, 45, 7, 810, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "CardTypes",
                keyColumn: "Id",
                keyValue: new Guid("ea9295a9-610d-41b1-8c95-8766b8ec4055"),
                column: "CreationTime",
                value: new DateTime(2025, 7, 27, 2, 45, 7, 810, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("586dee74-6c05-4f4f-bd00-51724d0fe571"),
                columns: new[] { "CreationTime", "Name" },
                values: new object[] { new DateTime(2025, 7, 27, 2, 45, 7, 810, DateTimeKind.Local).AddTicks(4288), "ToCard" });

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("6707cd60-afa6-4be8-ad69-53436ae92aa3"),
                columns: new[] { "CreationTime", "Name" },
                values: new object[] { new DateTime(2025, 7, 27, 2, 45, 7, 810, DateTimeKind.Local).AddTicks(4283), "ToAccount" });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_BranchTypeId",
                schema: "BankManagement",
                table: "Branches",
                column: "BranchTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchMapFeatures_BranchId",
                schema: "BankManagement",
                table: "BranchMapFeatures",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                schema: "BankManagement",
                table: "Accounts",
                column: "CustomerId",
                principalSchema: "BankManagement",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                schema: "BankManagement",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "BranchMapFeatures",
                schema: "BankManagement");

            migrationBuilder.DropTable(
                name: "Branches",
                schema: "BankManagement");

            migrationBuilder.DropTable(
                name: "BranchTypes",
                schema: "BankManagement");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("3018286c-3eb3-4710-a2ea-a82948c80596"),
                column: "CreationTime",
                value: new DateTime(2025, 7, 25, 1, 24, 57, 725, DateTimeKind.Local).AddTicks(192));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("d2333569-8720-4f19-97b3-ef8d7d1f19d1"),
                column: "CreationTime",
                value: new DateTime(2025, 7, 25, 1, 24, 57, 725, DateTimeKind.Local).AddTicks(337));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "CardTypes",
                keyColumn: "Id",
                keyValue: new Guid("42f63785-93f9-4b53-9038-9499455d9cd5"),
                column: "CreationTime",
                value: new DateTime(2025, 7, 25, 1, 24, 57, 725, DateTimeKind.Local).AddTicks(604));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "CardTypes",
                keyColumn: "Id",
                keyValue: new Guid("ea9295a9-610d-41b1-8c95-8766b8ec4055"),
                column: "CreationTime",
                value: new DateTime(2025, 7, 25, 1, 24, 57, 725, DateTimeKind.Local).AddTicks(609));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("586dee74-6c05-4f4f-bd00-51724d0fe571"),
                columns: new[] { "CreationTime", "Name" },
                values: new object[] { new DateTime(2025, 7, 25, 1, 24, 57, 725, DateTimeKind.Local).AddTicks(636), "AccountToCard" });

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("6707cd60-afa6-4be8-ad69-53436ae92aa3"),
                columns: new[] { "CreationTime", "Name" },
                values: new object[] { new DateTime(2025, 7, 25, 1, 24, 57, 725, DateTimeKind.Local).AddTicks(632), "AccountToAccount" });

            migrationBuilder.InsertData(
                schema: "BankManagement",
                table: "TransactionTypes",
                columns: new[] { "Id", "Code", "CreationTime", "CreatorId", "IsActive", "Name", "TenantId" },
                values: new object[,]
                {
                    { new Guid("6c31cd15-a33f-4564-956f-5d87d0c6a4fe"), 4, new DateTime(2025, 7, 25, 1, 24, 57, 725, DateTimeKind.Local).AddTicks(639), null, false, "CardToCard", null },
                    { new Guid("773ce647-3ec2-4e6e-9eec-3ba8fce2c33a"), 3, new DateTime(2025, 7, 25, 1, 24, 57, 725, DateTimeKind.Local).AddTicks(638), null, false, "CardToAccount", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                schema: "BankManagement",
                table: "Accounts",
                column: "CustomerId",
                principalSchema: "BankManagement",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
