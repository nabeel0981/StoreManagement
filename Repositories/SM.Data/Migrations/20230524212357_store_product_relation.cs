using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SM.Data.Migrations
{
    /// <inheritdoc />
    public partial class store_product_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "stores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_stores_StoreId",
                table: "stores",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_products_StoreId",
                table: "products",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_stores_StoreId",
                table: "products",
                column: "StoreId",
                principalTable: "stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stores_stores_StoreId",
                table: "stores",
                column: "StoreId",
                principalTable: "stores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_stores_StoreId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_stores_stores_StoreId",
                table: "stores");

            migrationBuilder.DropIndex(
                name: "IX_stores_StoreId",
                table: "stores");

            migrationBuilder.DropIndex(
                name: "IX_products_StoreId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "stores");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "products");
        }
    }
}
