using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVenda.Migrations
{
    /// <inheritdoc />
    public partial class InclusaodacolunaproductemBatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batch_Products_ProductId",
                table: "Batch");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Batch",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Batch_Products_ProductId",
                table: "Batch",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batch_Products_ProductId",
                table: "Batch");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Batch",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Batch_Products_ProductId",
                table: "Batch",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
