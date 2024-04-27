using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddCreateAndUpdateTimeToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 33, 15, 442, DateTimeKind.Utc).AddTicks(3010), new DateTime(2024, 4, 27, 3, 33, 15, 442, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 33, 15, 442, DateTimeKind.Utc).AddTicks(3010), new DateTime(2024, 4, 27, 3, 33, 15, 442, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 33, 15, 442, DateTimeKind.Utc).AddTicks(3010), new DateTime(2024, 4, 27, 3, 33, 15, 442, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 33, 15, 442, DateTimeKind.Utc).AddTicks(3010), "$2a$12$zUuir73jpUqq8st.QM2EJ.WdnWd9RpOk1D/hFewroZ7cyx89jCkma", new DateTime(2024, 4, 27, 3, 33, 15, 442, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 33, 15, 442, DateTimeKind.Utc).AddTicks(3010), "$2a$12$0fiuVeYMB7KDEEsR9n7EieKkN7ntIa3pWbai29JRJpc15SwqDLlYm", new DateTime(2024, 4, 27, 3, 33, 15, 442, DateTimeKind.Utc).AddTicks(3010) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$q270ybKSH1s5BR6euoLiXuAOYkVxu9W6HBwGfKTUgUbXnOPWA1fHa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$E.t9A2pO7pZlxfL4bi72gukjaqI3GGYcd2nI1GtjRo7zs7UOLlqy2");
        }
    }
}
