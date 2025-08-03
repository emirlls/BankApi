using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace BankManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBalanceColumnInTransactionAndCardTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                schema: "BankManagement",
                table: "Transactions",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                schema: "BankManagement",
                table: "Cards",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<Geometry>(
                name: "Geom",
                schema: "BankManagement",
                table: "BranchMapFeatures",
                type: "geometry",
                nullable: true,
                oldClrType: typeof(Geometry),
                oldType: "geometry");

            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                schema: "BankManagement",
                table: "Accounts",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("3018286c-3eb3-4710-a2ea-a82948c80596"),
                column: "CreationTime",
                value: new DateTime(2025, 8, 3, 23, 32, 57, 566, DateTimeKind.Local).AddTicks(9592));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("d2333569-8720-4f19-97b3-ef8d7d1f19d1"),
                column: "CreationTime",
                value: new DateTime(2025, 8, 3, 23, 32, 57, 566, DateTimeKind.Local).AddTicks(9730));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "BranchTypes",
                keyColumn: "Id",
                keyValue: new Guid("5126bb9a-4c1c-4284-96fd-58bed40a1689"),
                column: "CreationTime",
                value: new DateTime(2025, 8, 3, 23, 32, 57, 567, DateTimeKind.Local).AddTicks(323));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "BranchTypes",
                keyColumn: "Id",
                keyValue: new Guid("ff7a39f0-6b2e-46e1-a878-7a04de16a6e8"),
                column: "CreationTime",
                value: new DateTime(2025, 8, 3, 23, 32, 57, 567, DateTimeKind.Local).AddTicks(331));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "CardTypes",
                keyColumn: "Id",
                keyValue: new Guid("42f63785-93f9-4b53-9038-9499455d9cd5"),
                column: "CreationTime",
                value: new DateTime(2025, 8, 3, 23, 32, 57, 567, DateTimeKind.Local).AddTicks(235));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "CardTypes",
                keyColumn: "Id",
                keyValue: new Guid("ea9295a9-610d-41b1-8c95-8766b8ec4055"),
                column: "CreationTime",
                value: new DateTime(2025, 8, 3, 23, 32, 57, 567, DateTimeKind.Local).AddTicks(246));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("586dee74-6c05-4f4f-bd00-51724d0fe571"),
                column: "CreationTime",
                value: new DateTime(2025, 8, 3, 23, 32, 57, 567, DateTimeKind.Local).AddTicks(291));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("6707cd60-afa6-4be8-ad69-53436ae92aa3"),
                column: "CreationTime",
                value: new DateTime(2025, 8, 3, 23, 32, 57, 567, DateTimeKind.Local).AddTicks(285));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Balance",
                schema: "BankManagement",
                table: "Transactions",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "Balance",
                schema: "BankManagement",
                table: "Cards",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<Geometry>(
                name: "Geom",
                schema: "BankManagement",
                table: "BranchMapFeatures",
                type: "geometry",
                nullable: false,
                oldClrType: typeof(Geometry),
                oldType: "geometry",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Balance",
                schema: "BankManagement",
                table: "Accounts",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

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

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "BranchTypes",
                keyColumn: "Id",
                keyValue: new Guid("5126bb9a-4c1c-4284-96fd-58bed40a1689"),
                column: "CreationTime",
                value: new DateTime(2025, 7, 27, 2, 45, 7, 810, DateTimeKind.Local).AddTicks(4311));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "BranchTypes",
                keyColumn: "Id",
                keyValue: new Guid("ff7a39f0-6b2e-46e1-a878-7a04de16a6e8"),
                column: "CreationTime",
                value: new DateTime(2025, 7, 27, 2, 45, 7, 810, DateTimeKind.Local).AddTicks(4317));

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
                column: "CreationTime",
                value: new DateTime(2025, 7, 27, 2, 45, 7, 810, DateTimeKind.Local).AddTicks(4288));

            migrationBuilder.UpdateData(
                schema: "BankManagement",
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("6707cd60-afa6-4be8-ad69-53436ae92aa3"),
                column: "CreationTime",
                value: new DateTime(2025, 7, 27, 2, 45, 7, 810, DateTimeKind.Local).AddTicks(4283));
        }
    }
}
