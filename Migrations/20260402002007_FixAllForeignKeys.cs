using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpApi.Migrations
{
    /// <inheritdoc />
    public partial class FixAllForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Workers_WorkerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Departments_DepartmentId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_DepartmentId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ClientId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IdOwner",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "Orders",
                newName: "IdClient");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_WorkerId",
                table: "Orders",
                newName: "IX_Orders_IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_IdDepartment",
                table: "Workers",
                column: "IdDepartment");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCategory",
                table: "Products",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdWorker",
                table: "Orders",
                column: "IdWorker");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_IdClient",
                table: "Orders",
                column: "IdClient",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Workers_IdWorker",
                table: "Orders",
                column: "IdWorker",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_IdCategory",
                table: "Products",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Departments_IdDepartment",
                table: "Workers",
                column: "IdDepartment",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_IdClient",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Workers_IdWorker",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_IdCategory",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Departments_IdDepartment",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_IdDepartment",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdCategory",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IdWorker",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "IdClient",
                table: "Orders",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_IdClient",
                table: "Orders",
                newName: "IX_Orders_WorkerId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Workers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdOwner",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_DepartmentId",
                table: "Workers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Workers_WorkerId",
                table: "Orders",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Departments_DepartmentId",
                table: "Workers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
