using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "MenuItems",
                columns: new[] { "MenuItemId", "CreatedAt", "Description", "MenuId", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, "Frites, sauce, fromage", 0, "Poutine", 10.99m, null },
                    { 2, null, "Tomate, fromage, pepperoni", 0, "Pizza", 12.99m, null },
                    { 3, null, "Poulet, frites", 0, "Poulet", 15.99m, null },
                    { 4, null, "Laitue, tomate, concombre", 0, "Salade", 8.99m, null },
                    { 5, null, "Poisson, riz", 0, "Poisson", 14.99m, null },
                    { 6, null, "Pâtes, sauce, fromage", 0, "Pâtes", 11.99m, null }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, "Menu classique", null },
                    { 2, null, "Menu santé", null },
                    { 3, null, "Menu végétarien", null },
                    { 4, null, "Menu enfant", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$wp43.8JPtgdbW74Z93krFuJn2Mj2QMTiLViLHitbIO4kIcA1Qo58e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$Gp8ZRgYymgvKZU/PpYldcekA/a4yYw1XZpHd6crr2xSgzP99aZrDK");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "Firstname", "Lastname", "Password", "Phone", "RoleId", "UpdatedAt" },
                values: new object[] { 3, null, "john.doe@outlook.com", "John", "Doe", "$2a$12$MUq3c/FDAdS2eaJFuthv0ON9c6tA0ox1Ni164bcyfV187m.M5Y/i2", "1234567890", 3, null });

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

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Address", "CreatedAt", "MenuId", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "123 rue de la rue", null, 1, "Sorel-Tracy", null },
                    { 2, "456 rue de la rue", null, 2, "Montréal", null },
                    { 3, "789 rue de la rue", null, 3, "Québec", null },
                    { 4, "1011 rue de la rue", null, 4, "Laval", null },
                    { 5, "1213 rue de la rue", null, 1, "Longueuil", null },
                    { 6, "1415 rue de la rue", null, 2, "Sherbrooke", null },
                    { 7, "1617 rue de la rue", null, 3, "Trois-Rivières", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuMenuItems_MenuItemId",
                table: "MenuMenuItems",
                column: "MenuItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuMenuItems");

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$fZBQghsg5cNqTSRC.JVkhOkzQp.zylv0ysrq//DbUv8W7K3QGFRFm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$f2jn1zcta7/5tcikxWp0HuFwi5UuGLcB7LRffmsQ2Rx5rdJjhQWui");
        }
    }
}
