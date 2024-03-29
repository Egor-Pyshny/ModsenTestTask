using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_user_email",
                table: "tbl_user");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_email",
                table: "tbl_user",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_user_email",
                table: "tbl_user");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_email",
                table: "tbl_user",
                column: "email");
        }
    }
}
