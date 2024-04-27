using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddNaviguationMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$unldZxocbKRcLhWyY2pPJ.Z7jNcbBM7pf8/5JN9tgMQwHLulK66GG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$ETC/yj1ccukUGaYQfFxtWO2hk4RZ2wN4u.rH4RWnnXLHWEEo/uuJK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$03LIDJyTvxVQ5IijY9WhYuVbgqeaFNNt/kbXsAuOQKb75J2cEsgmi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$3yXAFk4muT2zfwGAc8zzy.RR4NojvV1i2fTftZR2mBP8DRN8.0bIm");
        }
    }
}
