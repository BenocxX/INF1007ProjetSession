using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    Tps = table.Column<decimal>(type: "numeric", nullable: false),
                    Tvq = table.Column<decimal>(type: "numeric", nullable: false),
                    SubTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    ClientBillingInfoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_ClientBillingInfos_ClientBillingInfoId",
                        column: x => x.ClientBillingInfoId,
                        principalTable: "ClientBillingInfos",
                        principalColumn: "ClientBillingInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientBillingInfoId",
                table: "Orders",
                column: "ClientBillingInfoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

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
        }
    }
}
