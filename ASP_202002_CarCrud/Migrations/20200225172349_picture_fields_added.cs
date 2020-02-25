using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_202002_CarCrud.Migrations
{
    public partial class picture_fields_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoData",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PhotoData",
                table: "Cars");
        }
    }
}
