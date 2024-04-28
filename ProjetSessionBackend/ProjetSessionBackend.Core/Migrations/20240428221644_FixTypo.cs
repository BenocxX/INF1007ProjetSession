using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class FixTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$G1S6XkSrcummCIiYHf6EBut4y4ABOYeQozBzO7uZ8VUAHNW3pmMY6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$nT5kV7xP/epurge.JJfaGe7KlW4mt/VIdIeUzC7JG3wKHEKaIFB.K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$eyJsCBk5onHPiJRadJTgg.KHBI65hw/7oLMPv49SosAU8LphCgaua");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$MUq3c/FDAdS2eaJFuthv0ON9c6tA0ox1Ni164bcyfV187m.M5Y/i2");
        }
    }
}
