using Microsoft.EntityFrameworkCore.Migrations;

namespace District.Dal.Migrations
{
    public partial class added_PersonType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonType",
                table: "Persons",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonType",
                table: "Persons");
        }
    }
}
