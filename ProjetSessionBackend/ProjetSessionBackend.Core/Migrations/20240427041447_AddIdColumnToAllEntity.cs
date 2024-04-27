using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddIdColumnToAllEntity : Migration
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

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MenusMenuId",
                table: "MenuMenuItem",
                newName: "MenusId");

            migrationBuilder.RenameColumn(
                name: "MenuItemsMenuItemId",
                table: "MenuMenuItem",
                newName: "MenuItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuMenuItem_MenusMenuId",
                table: "MenuMenuItem",
                newName: "IX_MenuMenuItem_MenusId");

            migrationBuilder.RenameColumn(
                name: "MenuItemId",
                table: "MenuItem",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Menu",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$qhU/Yo0mhlAIFYTG0dBjh.QpgG.9EGTIDFERzisJ3Gqf/b/Bep7d.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$4vxeUF86BLAcwocdjwC0K.8TZCMqWp0/Rrf4ZiodBaclcnnw4/Jju");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItem_MenuItem_MenuItemsId",
                table: "MenuMenuItem",
                column: "MenuItemsId",
                principalTable: "MenuItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItem_Menu_MenusId",
                table: "MenuMenuItem",
                column: "MenusId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_MenuItem_MenuItemsId",
                table: "MenuMenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_Menu_MenusId",
                table: "MenuMenuItem");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "MenusId",
                table: "MenuMenuItem",
                newName: "MenusMenuId");

            migrationBuilder.RenameColumn(
                name: "MenuItemsId",
                table: "MenuMenuItem",
                newName: "MenuItemsMenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuMenuItem_MenusId",
                table: "MenuMenuItem",
                newName: "IX_MenuMenuItem_MenusMenuId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MenuItem",
                newName: "MenuItemId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Menu",
                newName: "MenuId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$39sFtr1LSN22W0alPTD8O.ciYW2VodRr3WfzqcbW0J/EGiT62NaJS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$5RwaYudPbNnBc/uYYkDyZuhrIcWFiJxCNfp1e5a1L63zn3Rjy9/ua");

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
        }
    }
}
