using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_EF_Hash_Token.DAL.Migrations
{
    public partial class ajoutmanytooneentreproductOrderetSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "ProductOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_SizeId",
                table: "ProductOrder",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Sizes_SizeId",
                table: "ProductOrder",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Sizes_SizeId",
                table: "ProductOrder");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrder_SizeId",
                table: "ProductOrder");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "ProductOrder");
        }
    }
}
