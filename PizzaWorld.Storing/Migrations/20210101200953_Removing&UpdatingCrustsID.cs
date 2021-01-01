using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class RemovingUpdatingCrustsID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PizzaToppingsID",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "CrustId",
                table: "Crusts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PizzaToppingsID",
                table: "Toppings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CrustId",
                table: "Crusts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
