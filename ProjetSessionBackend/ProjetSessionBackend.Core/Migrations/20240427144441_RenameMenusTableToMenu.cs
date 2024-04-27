using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class RenameMenusTableToMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$xFHKyRgnnYnNTj3wIzBXSeHx25blBlDxLsLDzclQq9h9GC9sSfP9G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$qwxdX9VSz4aM4LOBlJSnoeITR6tndWZX.PgE3KdS4K0XSe41xE.sy");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItem_Menu_MenusMenuId",
                table: "MenuMenuItem",
                column: "MenusMenuId",
                principalTable: "Menu",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$unldZxocbKRcLhWyY2pPJ.Z7jNcbBM7pf8/5JN9tgMQwHLulK66GG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$ETC/yj1ccukUGaYQfFxtWO2hk4RZ2wN4u.rH4RWnnXLHWEEo/uuJK");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItem_Menus_MenusMenuId",
                table: "MenuMenuItem",
                column: "MenusMenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
