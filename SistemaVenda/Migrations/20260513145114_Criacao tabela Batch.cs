using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVenda.Migrations
{
    /// <inheritdoc />
    public partial class CriacaotabelaBatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batch_Products_ProductId",
                table: "Batch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batch",
                table: "Batch");

            migrationBuilder.RenameTable(
                name: "Batch",
                newName: "Batchs");

            migrationBuilder.RenameIndex(
                name: "IX_Batch_ProductId",
                table: "Batchs",
                newName: "IX_Batchs_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batchs",
                table: "Batchs",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Products_ProductId",
                table: "Batchs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Products_ProductId",
                table: "Batchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batchs",
                table: "Batchs");

            migrationBuilder.RenameTable(
                name: "Batchs",
                newName: "Batch");

            migrationBuilder.RenameIndex(
                name: "IX_Batchs_ProductId",
                table: "Batch",
                newName: "IX_Batch_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batch",
                table: "Batch",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batch_Products_ProductId",
                table: "Batch",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
