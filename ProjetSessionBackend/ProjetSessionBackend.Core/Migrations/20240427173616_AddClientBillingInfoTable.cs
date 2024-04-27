using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddClientBillingInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientBillingInfos",
                columns: table => new
                {
                    ClientBillingInfoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CardName = table.Column<string>(type: "text", nullable: false),
                    CardNumber = table.Column<string>(type: "text", nullable: false),
                    ExpiryDate = table.Column<string>(type: "text", nullable: false),
                    CVV = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientBillingInfos", x => x.ClientBillingInfoId);
                    table.ForeignKey(
                        name: "FK_ClientBillingInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ClientBillingInfos_UserId",
                table: "ClientBillingInfos",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientBillingInfos");

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
        }
    }
}
