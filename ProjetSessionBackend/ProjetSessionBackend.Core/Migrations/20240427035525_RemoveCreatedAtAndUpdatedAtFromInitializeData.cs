using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCreatedAtAndUpdatedAtFromInitializeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { null, "$2a$12$39sFtr1LSN22W0alPTD8O.ciYW2VodRr3WfzqcbW0J/EGiT62NaJS", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { null, "$2a$12$5RwaYudPbNnBc/uYYkDyZuhrIcWFiJxCNfp1e5a1L63zn3Rjy9/ua", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
