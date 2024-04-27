using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class RenameMenuItemTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_Menu_MenusMenuId",
                table: "MenuMenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "MenuId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItem_Menus_MenusMenuId",
                table: "MenuMenuItem",
                column: "MenusMenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_Menus_MenusMenuId",
                table: "MenuMenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "MenuId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItem_Menu_MenusMenuId",
                table: "MenuMenuItem",
                column: "MenusMenuId",
                principalTable: "Menu",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
