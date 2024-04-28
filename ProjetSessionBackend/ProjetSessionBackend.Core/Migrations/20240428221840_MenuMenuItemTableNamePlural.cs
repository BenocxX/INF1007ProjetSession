using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class MenuMenuItemTableNamePlural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
