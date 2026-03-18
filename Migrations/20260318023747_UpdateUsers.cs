using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "roleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserId",
                table: "Users",
                newName: "IX_Users_roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rols_roleId",
                table: "Users",
                column: "roleId",
                principalTable: "Rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rols_roleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_roleId",
                table: "Users",
                newName: "IX_Users_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
