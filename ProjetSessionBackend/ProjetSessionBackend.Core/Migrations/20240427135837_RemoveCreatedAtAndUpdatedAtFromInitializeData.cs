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
                values: new object[] { null, "$2a$12$03LIDJyTvxVQ5IijY9WhYuVbgqeaFNNt/kbXsAuOQKb75J2cEsgmi", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { null, "$2a$12$3yXAFk4muT2zfwGAc8zzy.RR4NojvV1i2fTftZR2mBP8DRN8.0bIm", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 13, 57, 35, 898, DateTimeKind.Utc).AddTicks(3710), new DateTime(2024, 4, 27, 13, 57, 35, 898, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 13, 57, 35, 898, DateTimeKind.Utc).AddTicks(3710), new DateTime(2024, 4, 27, 13, 57, 35, 898, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 13, 57, 35, 898, DateTimeKind.Utc).AddTicks(3710), new DateTime(2024, 4, 27, 13, 57, 35, 898, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 13, 57, 35, 898, DateTimeKind.Utc).AddTicks(3710), "$2a$12$g2JpLRhwHQnSTRrnL4/fZ.T/XDRG8ZLwwwqxTkdLXIpjzD2OT3Nsu", new DateTime(2024, 4, 27, 13, 57, 35, 898, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 27, 13, 57, 35, 898, DateTimeKind.Utc).AddTicks(3710), "$2a$12$DbYgRHWjLInh8taJ.HADPONR8iQD0U0YkKpKUielG3peXu2mxTRxi", new DateTime(2024, 4, 27, 13, 57, 35, 898, DateTimeKind.Utc).AddTicks(3710) });
        }
    }
}
