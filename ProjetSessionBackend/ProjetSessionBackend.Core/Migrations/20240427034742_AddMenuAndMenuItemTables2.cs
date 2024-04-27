using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuAndMenuItemTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    MenuId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.MenuItemId);
                });

            migrationBuilder.CreateTable(
                name: "MenuMenuItem",
                columns: table => new
                {
                    MenuItemsMenuItemId = table.Column<int>(type: "integer", nullable: false),
                    MenusMenuId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMenuItem", x => new { x.MenuItemsMenuItemId, x.MenusMenuId });
                    table.ForeignKey(
                        name: "FK_MenuMenuItem_MenuItem_MenuItemsMenuItemId",
                        column: x => x.MenuItemsMenuItemId,
                        principalTable: "MenuItem",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuMenuItem_Menu_MenusMenuId",
                        column: x => x.MenusMenuId,
                        principalTable: "Menu",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_MenuMenuItem_MenusMenuId",
                table: "MenuMenuItem",
                column: "MenusMenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuMenuItem");

            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "Menu");

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
    }
}
