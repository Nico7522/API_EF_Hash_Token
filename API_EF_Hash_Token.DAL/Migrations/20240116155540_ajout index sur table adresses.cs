using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_EF_Hash_Token.DAL.Migrations
{
    public partial class ajoutindexsurtableadresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Adresses_Number_Street_CityName_Country",
                table: "Adresses",
                columns: new[] { "Number", "Street", "CityName", "Country" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Adresses_Number_Street_CityName_Country",
                table: "Adresses");
        }
    }
}
