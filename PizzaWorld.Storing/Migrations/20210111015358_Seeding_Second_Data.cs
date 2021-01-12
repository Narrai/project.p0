using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class Seeding_Second_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "EntityId", "Name", "OrderDate", "StoreEntityId", "StoreName", "TotalPrice", "UserEntityId" },
                values: new object[] { 1L, "Nar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "One", 20.98f, null });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "EntityId", "Crust", "CrustsEntityId", "Discriminator", "Name", "OrderEntityId", "OrderName", "Price", "Size", "SizesEntityId" },
                values: new object[,]
                {
                    { 1L, "stuffed", null, "Pizza", "meat Pizza", null, null, 10.99f, "small", null },
                    { 2L, "thick", null, "Pizza", "meat Pizza", null, null, 12.99f, "medium", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "EntityId", "Name", "SelectedOrderEntityId", "SelectedStoreEntityId" },
                values: new object[] { 1L, "Nar", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Users",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pizzas");
        }
    }
}
