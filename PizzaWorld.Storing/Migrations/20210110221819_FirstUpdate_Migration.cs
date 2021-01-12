using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class FirstUpdate_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaToppings");

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "EntityId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Topping",
                table: "Pizzas");

            migrationBuilder.AddColumn<long>(
                name: "PriceEntityId",
                table: "Sizes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CrustsEntityId",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SizesEntityId",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "APizzaModelTopping",
                columns: table => new
                {
                    PizzasEntityId = table.Column<long>(type: "bigint", nullable: false),
                    ToppingsEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APizzaModelTopping", x => new { x.PizzasEntityId, x.ToppingsEntityId });
                    table.ForeignKey(
                        name: "FK_APizzaModelTopping_Pizzas_PizzasEntityId",
                        column: x => x.PizzasEntityId,
                        principalTable: "Pizzas",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_APizzaModelTopping_Toppings_ToppingsEntityId",
                        column: x => x.ToppingsEntityId,
                        principalTable: "Toppings",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_PriceEntityId",
                table: "Sizes",
                column: "PriceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustsEntityId",
                table: "Pizzas",
                column: "CrustsEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizesEntityId",
                table: "Pizzas",
                column: "SizesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_APizzaModelTopping_ToppingsEntityId",
                table: "APizzaModelTopping",
                column: "ToppingsEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crusts_CrustsEntityId",
                table: "Pizzas",
                column: "CrustsEntityId",
                principalTable: "Crusts",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizesEntityId",
                table: "Pizzas",
                column: "SizesEntityId",
                principalTable: "Sizes",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Prices_PriceEntityId",
                table: "Sizes",
                column: "PriceEntityId",
                principalTable: "Prices",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Crusts_CrustsEntityId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizesEntityId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Prices_PriceEntityId",
                table: "Sizes");

            migrationBuilder.DropTable(
                name: "APizzaModelTopping");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_PriceEntityId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_CrustsEntityId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_SizesEntityId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "PriceEntityId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "CrustsEntityId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "SizesEntityId",
                table: "Pizzas");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Topping",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PizzaToppings",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaEntityId = table.Column<long>(type: "bigint", nullable: true),
                    ToppingEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaToppings", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Pizzas_PizzaEntityId",
                        column: x => x.PizzaEntityId,
                        principalTable: "Pizzas",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Toppings_ToppingEntityId",
                        column: x => x.ToppingEntityId,
                        principalTable: "Toppings",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "EntityId", "Name" },
                values: new object[,]
                {
                    { 1L, "stuffed" },
                    { 2L, "thin" },
                    { 3L, "stuffed" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "EntityId", "Name", "OrderDate", "StoreEntityId", "StoreName", "TotalPrice", "UserEntityId" },
                values: new object[] { 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0f, null });

            migrationBuilder.InsertData(
                table: "PizzaToppings",
                columns: new[] { "EntityId", "PizzaEntityId", "ToppingEntityId" },
                values: new object[] { 1L, null, null });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "EntityId", "Crust", "Discriminator", "Name", "OrderEntityId", "OrderName", "Price", "Size", "Topping" },
                values: new object[,]
                {
                    { 1L, "stuffed", "MeatPizza", "meat Pizza", null, null, 10.99f, "small", null },
                    { 2L, "thick", "VegePizza", "vege Pizza", null, null, 12.99f, "medium", null }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "EntityId", "Price" },
                values: new object[,]
                {
                    { 2L, 12.99f },
                    { 1L, 10.99f },
                    { 3L, 14.99f }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "EntityId", "Name" },
                values: new object[,]
                {
                    { 1L, "small" },
                    { 2L, "medium" },
                    { 3L, "large" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityId", "Name" },
                values: new object[,]
                {
                    { 1L, "One" },
                    { 2L, "Two" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityId", "Name" },
                values: new object[,]
                {
                    { 1L, "tomato" },
                    { 2L, "grilled chicken" },
                    { 3L, "sauce" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "EntityId", "Name", "SelectedOrderEntityId", "SelectedStoreEntityId" },
                values: new object[] { 1L, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_PizzaEntityId",
                table: "PizzaToppings",
                column: "PizzaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_ToppingEntityId",
                table: "PizzaToppings",
                column: "ToppingEntityId");
        }
    }
}
