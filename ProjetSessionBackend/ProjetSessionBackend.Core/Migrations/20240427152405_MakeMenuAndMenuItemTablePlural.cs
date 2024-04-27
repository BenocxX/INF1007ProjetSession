using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class MakeMenuAndMenuItemTablePlural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_MenuItem_MenuItemsMenuItemId",
                table: "MenuMenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_Menu_MenusMenuId",
                table: "MenuMenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Menu_MenuId",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.RenameTable(
                name: "MenuItem",
                newName: "MenuItems");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems",
                column: "MenuItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "MenuId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$bARAV0XTVzGiHZUG6c/kSe5.xaX7vYPnqBRq1ibns5G/gVSPWDrGG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$tIwmIGyUZExvnSEX3eDUnOFfPCQFzOb4JJlFMqSYSw8Ul2gnbyCoy");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItem_MenuItems_MenuItemsMenuItemId",
                table: "MenuMenuItem",
                column: "MenuItemsMenuItemId",
                principalTable: "MenuItems",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItem_Menus_MenusMenuId",
                table: "MenuMenuItem",
                column: "MenusMenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Menus_MenuId",
                table: "Restaurants",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_MenuItems_MenuItemsMenuItemId",
                table: "MenuMenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_Menus_MenusMenuId",
                table: "MenuMenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Menus_MenuId",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.RenameTable(
                name: "MenuItems",
                newName: "MenuItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem",
                column: "MenuItemId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$4t5WGOsK2niscPmvEwGuleOGhNX/5DLFXksU5RMD3BauNldDVHEPW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$Z0oxOZ6e62tXo.9/7XOrfuxlus.FmwrIr2XEjoYhLlYL9irJt5zuq");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItem_MenuItem_MenuItemsMenuItemId",
                table: "MenuMenuItem",
                column: "MenuItemsMenuItemId",
                principalTable: "MenuItem",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItem_Menu_MenusMenuId",
                table: "MenuMenuItem",
                column: "MenusMenuId",
                principalTable: "Menu",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Menu_MenuId",
                table: "Restaurants",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
