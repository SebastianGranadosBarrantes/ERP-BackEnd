using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpApi.Migrations
{
    /// <inheritdoc />
    public partial class FixUserRoleFKAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rols_roleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_roleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "roleId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRol",
                table: "Users",
                column: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rols_IdRol",
                table: "Users",
                column: "IdRol",
                principalTable: "Rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rols_IdRol",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdRol",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "roleId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleId",
                table: "Users",
                column: "roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rols_roleId",
                table: "Users",
                column: "roleId",
                principalTable: "Rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
