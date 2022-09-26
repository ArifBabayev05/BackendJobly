using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class _8ID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Images_CityId",
                table: "Vacancies");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Cities_CityId",
                table: "Vacancies",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Cities_CityId",
                table: "Vacancies");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Images_CityId",
                table: "Vacancies",
                column: "CityId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
