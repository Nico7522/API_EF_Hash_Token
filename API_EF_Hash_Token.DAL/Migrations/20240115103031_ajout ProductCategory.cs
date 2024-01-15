using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_EF_Hash_Token.DAL.Migrations
{
    public partial class ajoutProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryEntity_Categories_CategoryId",
                table: "ProductCategoryEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryEntity_Products_ProductId",
                table: "ProductCategoryEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategoryEntity",
                table: "ProductCategoryEntity");

            migrationBuilder.RenameTable(
                name: "ProductCategoryEntity",
                newName: "ProductCategory");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategoryEntity_CategoryId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Categories_CategoryId",
                table: "ProductCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Products_ProductId",
                table: "ProductCategory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "PrdoductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Categories_CategoryId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Products_ProductId",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "ProductCategoryEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategoryEntity",
                newName: "IX_ProductCategoryEntity_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategoryEntity",
                table: "ProductCategoryEntity",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryEntity_Categories_CategoryId",
                table: "ProductCategoryEntity",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryEntity_Products_ProductId",
                table: "ProductCategoryEntity",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "PrdoductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
