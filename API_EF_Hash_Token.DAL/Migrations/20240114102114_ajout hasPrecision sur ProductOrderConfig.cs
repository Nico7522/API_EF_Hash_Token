using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_EF_Hash_Token.DAL.Migrations
{
    public partial class ajouthasPrecisionsurProductOrderConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProductOrder",
                type: "decimal(11,2)",
                precision: 11,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProductOrder",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)",
                oldPrecision: 11,
                oldScale: 2);
        }
    }
}
