using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddPrecisionToMenuItemPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MenuItem",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 53, 54, 645, DateTimeKind.Utc).AddTicks(9180), new DateTime(2024, 4, 27, 3, 53, 54, 645, DateTimeKind.Utc).AddTicks(9180) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 53, 54, 645, DateTimeKind.Utc).AddTicks(9180), new DateTime(2024, 4, 27, 3, 53, 54, 645, DateTimeKind.Utc).AddTicks(9180) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 53, 54, 645, DateTimeKind.Utc).AddTicks(9180), new DateTime(2024, 4, 27, 3, 53, 54, 645, DateTimeKind.Utc).AddTicks(9180) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 53, 54, 645, DateTimeKind.Utc).AddTicks(9180), "$2a$12$ebWHLbphuF1vn1mY5RsAWOoQjmo7L6adiTSphksTLqr7oi9aeA44u", new DateTime(2024, 4, 27, 3, 53, 54, 645, DateTimeKind.Utc).AddTicks(9180) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 53, 54, 645, DateTimeKind.Utc).AddTicks(9180), "$2a$12$tf288zcxdvwIIEbkebl5R.Va3YbaRnG7M.uXEs8YA1BWwK1W2eQCu", new DateTime(2024, 4, 27, 3, 53, 54, 645, DateTimeKind.Utc).AddTicks(9180) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MenuItem",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 47, 41, 154, DateTimeKind.Utc).AddTicks(8470), new DateTime(2024, 4, 27, 3, 47, 41, 154, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 47, 41, 154, DateTimeKind.Utc).AddTicks(8470), new DateTime(2024, 4, 27, 3, 47, 41, 154, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 47, 41, 154, DateTimeKind.Utc).AddTicks(8470), new DateTime(2024, 4, 27, 3, 47, 41, 154, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 47, 41, 154, DateTimeKind.Utc).AddTicks(8470), "$2a$12$YvWcEUH8EMNvDp/t9L7T9OatOsIuBxKCaFSuGodxT97ydLDF8M87e", new DateTime(2024, 4, 27, 3, 47, 41, 154, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 47, 41, 154, DateTimeKind.Utc).AddTicks(8470), "$2a$12$Znkd3FtFXTmR38XCljKatuoicEdlD0McELauz8kmJXD6xmGY.0f.O", new DateTime(2024, 4, 27, 3, 47, 41, 154, DateTimeKind.Utc).AddTicks(8470) });
        }
    }
}
