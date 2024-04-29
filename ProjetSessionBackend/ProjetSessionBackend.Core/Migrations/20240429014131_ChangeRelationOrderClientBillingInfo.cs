using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationOrderClientBillingInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_ClientBillingInfoId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$F9gTDte0am0qFDsQKELv4uoYyqW3M/Xk0VfViGisVwwu65XlJL/Sy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$DqnP8DmqKqrgNa6fLwYXjOl5rRq5oGfKi7EcGVglfGnKclrw3ycIi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$Bc5WT83RXn98KTkoTVWjVO81FNUzLTEIc7djKb9ZA9Rz44Lv4E7uq");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientBillingInfoId",
                table: "Orders",
                column: "ClientBillingInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_ClientBillingInfoId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$S0CRZt3..CxZkIyh3PyxEOJh6jRzbsU3pEA7TgAlfFVsbJcwngHMK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$fZ.JC0vTrutqaPRYA16XeuzMecYmaZb9NA.rGm12Fb55sQgmnFV4i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$WOt6SdCJ7kAajS5.CQ/hhu1xC42zXE7YoGviAqM.pJhlJgaMNxMkK");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientBillingInfoId",
                table: "Orders",
                column: "ClientBillingInfoId",
                unique: true);
        }
    }
}
