using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_EF_Hash_Token.DAL.Migrations
{
    public partial class removesizetablesizeetajoutsurmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Sizes");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "SizeProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "SizeProduct");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Sizes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
