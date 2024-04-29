using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$4hxp4AuRy10PERoms8hD6O.f0MMJ7pEeGXH4UsXW346k4Nf95YTn6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$z6UrbV8rGuslVO9OSEaQj.Qv4w7xRjQvtegjGvWGOs57JSE7mkRgu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$xlR8UG.MSSmk9fQvg/i3zu4dzCrczf/PWW6it20nBWb2q8rTBjUza");
        }
    }
}
