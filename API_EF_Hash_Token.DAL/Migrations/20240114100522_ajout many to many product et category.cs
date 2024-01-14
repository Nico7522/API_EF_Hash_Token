using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_EF_Hash_Token.DAL.Migrations
{
    public partial class ajoutmanytomanyproductetcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderEntity_Orders_OrderId",
                table: "ProductOrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderEntity_Products_ProductId",
                table: "ProductOrderEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrderEntity",
                table: "ProductOrderEntity");

            migrationBuilder.RenameTable(
                name: "ProductOrderEntity",
                newName: "ProductOrder");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrderEntity_OrderId",
                table: "ProductOrder",
                newName: "IX_ProductOrder_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder",
                columns: new[] { "ProductId", "OrderId" });

            migrationBuilder.CreateTable(
                name: "ProductCategoryEntity",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryEntity", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategoryEntity_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoryEntity_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "PrdoductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryEntity_CategoryId",
                table: "ProductCategoryEntity",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Orders_OrderId",
                table: "ProductOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Products_ProductId",
                table: "ProductOrder",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "PrdoductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Orders_OrderId",
                table: "ProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Products_ProductId",
                table: "ProductOrder");

            migrationBuilder.DropTable(
                name: "ProductCategoryEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder");

            migrationBuilder.RenameTable(
                name: "ProductOrder",
                newName: "ProductOrderEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrder_OrderId",
                table: "ProductOrderEntity",
                newName: "IX_ProductOrderEntity_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrderEntity",
                table: "ProductOrderEntity",
                columns: new[] { "ProductId", "OrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderEntity_Orders_OrderId",
                table: "ProductOrderEntity",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderEntity_Products_ProductId",
                table: "ProductOrderEntity",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "PrdoductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
