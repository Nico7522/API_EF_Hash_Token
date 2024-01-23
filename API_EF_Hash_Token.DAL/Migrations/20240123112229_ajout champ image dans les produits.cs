﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_EF_Hash_Token.DAL.Migrations
{
    public partial class ajoutchampimagedanslesproduits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "/default.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");
        }
    }
}
