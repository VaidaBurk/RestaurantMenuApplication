using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurants.Migrations
{
    public partial class onDeleteRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Menu_DishId",
                table: "Restaurants");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Menu_DishId",
                table: "Restaurants",
                column: "DishId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Menu_DishId",
                table: "Restaurants");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Menu_DishId",
                table: "Restaurants",
                column: "DishId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
