using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpApi.Migrations
{
    /// <inheritdoc />
    public partial class FixTypoError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Rols",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rols",
                newName: "name");
        }
    }
}
