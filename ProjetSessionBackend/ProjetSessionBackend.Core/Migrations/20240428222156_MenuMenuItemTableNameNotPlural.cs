using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class MenuMenuItemTableNameNotPlural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_MenuItems_MenuItemsMenuItemId",
                table: "MenuMenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_Menus_MenusMenuId",
                table: "MenuMenuItem");

            migrationBuilder.DropTable(
                name: "MenuMenuItems");

            migrationBuilder.RenameColumn(
                name: "MenusMenuId",
                table: "MenuMenuItem",
                newName: "MenuItemId");

            migrationBuilder.RenameColumn(
                name: "MenuItemsMenuItemId",
                table: "MenuMenuItem",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuMenuItem_MenusMenuId",
                table: "MenuMenuItem",
                newName: "IX_MenuMenuItem_MenuItemId");

            migrationBuilder.InsertData(
                table: "MenuMenuItem",
                columns: new[] { "MenuId", "MenuItemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 4 },
                    { 3, 6 },
                    { 4, 4 },
                    { 4, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$WGQgHxhjvpA0FrGY8VNyueJzeVEnlARUJBNeIZu7UoqOMLlwykkOO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$ivRdI.W3Kn74fXRaNkal.ea4lU7zyfWsYv3yPxcqMqR3aYJ0vE6Fa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$LnO8piOQ1/gY9D6Gi4QQs.wOP8lzIS.dpE48agrnufNMTVud/Yrxy");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItem_MenuItems_MenuItemId",
                table: "MenuMenuItem",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItem_Menus_MenuId",
                table: "MenuMenuItem",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_MenuItems_MenuItemId",
                table: "MenuMenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_Menus_MenuId",
                table: "MenuMenuItem");

            migrationBuilder.DeleteData(
                table: "MenuMenuItem",
                keyColumns: new[] { "MenuId", "MenuItemId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MenuMenuItem",
                keyColumns: new[] { "MenuId", "MenuItemId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MenuMenuItem",
                keyColumns: new[] { "MenuId", "MenuItemId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "MenuMenuItem",
                keyColumns: new[] { "MenuId", "MenuItemId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "MenuMenuItem",
                keyColumns: new[] { "MenuId", "MenuItemId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "MenuMenuItem",
                keyColumns: new[] { "MenuId", "MenuItemId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "MenuMenuItem",
                keyColumns: new[] { "MenuId", "MenuItemId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "MenuMenuItem",
                keyColumns: new[] { "MenuId", "MenuItemId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "MenuMenuItem",
                keyColumns: new[] { "MenuId", "MenuItemId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "MenuMenuItem",
                keyColumns: new[] { "MenuId", "MenuItemId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "MenuMenuItem",
                keyColumns: new[] { "MenuId", "MenuItemId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "MenuMenuItem",
                keyColumns: new[] { "MenuId", "MenuItemId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "MenuMenuItem",
                keyColumns: new[] { "MenuId", "MenuItemId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.RenameColumn(
                name: "MenuItemId",
                table: "MenuMenuItem",
                newName: "MenusMenuId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "MenuMenuItem",
                newName: "MenuItemsMenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuMenuItem_MenuItemId",
                table: "MenuMenuItem",
                newName: "IX_MenuMenuItem_MenusMenuId");

            migrationBuilder.CreateTable(
                name: "MenuMenuItems",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "integer", nullable: false),
                    MenuItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMenuItems", x => new { x.MenuId, x.MenuItemId });
                    table.ForeignKey(
                        name: "FK_MenuMenuItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuMenuItems_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MenuMenuItems",
                columns: new[] { "MenuId", "MenuItemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 4 },
                    { 3, 6 },
                    { 4, 4 },
                    { 4, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$NTLZOZDMCHQszhzRmbDAU.v8luhxiJEljRAMGrf3MF8FuYu/47I2q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$r17ccgEuvhWh.Y6r7FtkAuJ3K/wtLm9.WS5FyhZWBcO2OsSRt1OSK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$3wYaFTLHKp4OrH7dnKHxle/C8I0swnFprVUIXep0wJbVNAG/NF.yy");

            migrationBuilder.CreateIndex(
                name: "IX_MenuMenuItems_MenuItemId",
                table: "MenuMenuItems",
                column: "MenuItemId");

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
        }
    }
}
