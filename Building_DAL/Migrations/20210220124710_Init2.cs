using Microsoft.EntityFrameworkCore.Migrations;

namespace District.Dal.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Persons_EntranceId",
                table: "Apartments");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Entrances_EntranceId",
                table: "Apartments",
                column: "EntranceId",
                principalTable: "Entrances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Entrances_EntranceId",
                table: "Apartments");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Persons_EntranceId",
                table: "Apartments",
                column: "EntranceId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
