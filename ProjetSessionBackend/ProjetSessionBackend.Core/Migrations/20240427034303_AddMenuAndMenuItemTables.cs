using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuAndMenuItemTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 43, 2, 565, DateTimeKind.Utc).AddTicks(6500), new DateTime(2024, 4, 27, 3, 43, 2, 565, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 43, 2, 565, DateTimeKind.Utc).AddTicks(6500), new DateTime(2024, 4, 27, 3, 43, 2, 565, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 43, 2, 565, DateTimeKind.Utc).AddTicks(6500), new DateTime(2024, 4, 27, 3, 43, 2, 565, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 43, 2, 565, DateTimeKind.Utc).AddTicks(6500), "$2a$12$YC7aahpJvYsBQv2aco8Z3OPzVMhR6F93nm8VwKDv6ntRDLbbSLe7u", new DateTime(2024, 4, 27, 3, 43, 2, 565, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 3, 43, 2, 565, DateTimeKind.Utc).AddTicks(6500), "$2a$12$Gyaw/hKCobbF9.I5xCZ01OgcfO1UCDuVFVHrDF13qn06K6n1VXhsC", new DateTime(2024, 4, 27, 3, 43, 2, 565, DateTimeKind.Utc).AddTicks(6500) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
