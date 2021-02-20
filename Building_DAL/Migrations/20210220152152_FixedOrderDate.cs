using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace District.Dal.Migrations
{
    public partial class FixedOrderDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Persons");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Apartments",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Apartments");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Persons",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
