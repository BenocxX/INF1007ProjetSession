using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddNameColumnToRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Roles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "Name",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "Name",
                value: "Employee");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "Name",
                value: "Client");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$q270ybKSH1s5BR6euoLiXuAOYkVxu9W6HBwGfKTUgUbXnOPWA1fHa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$E.t9A2pO7pZlxfL4bi72gukjaqI3GGYcd2nI1GtjRo7zs7UOLlqy2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$OGH/I2a8d9jtHLp8s39.ROyX9IAk9OGnTmDWINAWELfbAHEolhUmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$AUKu52b2EY0smuwzNZMQQuCllXnrN6yIjAI33XrxUpFffUaA1B1nW");
        }
    }
}
