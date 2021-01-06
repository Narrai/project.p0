using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class SeedingPizzaData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "EntityId", "Crust", "Discriminator", "Name", "OrderEntityId", "Price", "Size", "Topping" },
                values: new object[] { 2L, "thick", "VegePizza", "vege Pizza", null, 12.99f, "medium", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "EntityId", "Crust", "Discriminator", "Name", "OrderEntityId", "Price", "Size", "Topping" },
                values: new object[] { 2L, "thin", "MeatPizza", "vege Pizza", null, 12.99f, "medium", null });
        }
    }
}
