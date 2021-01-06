using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class updateseedingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreEntityId",
                        column: x => x.StoreEntityId,
                        principalTable: "Stores",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Users_Stores_StoreEntityId",
                        column: x => x.StoreEntityId,
                        principalTable: "Stores",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crust = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Topping = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Pizzas_Orders_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "Orders",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                columns: new[] { "EntityId", "StoreEntityId" },
                values: new object[] { 1L, null });

            migrationBuilder.InsertData(
                table: "PizzaToppings",
                columns: new[] { "EntityId", "PizzaEntityId", "ToppingEntityId" },
                values: new object[] { 1L, null, null });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "EntityId", "Crust", "Discriminator", "Name", "OrderEntityId", "Price", "Size", "Topping" },
                values: new object[,]
                {
                    { 2L, "thin", "MeatPizza", "vege Pizza", null, 12.99f, "medium", null },
                    { 1L, "stuffed", "MeatPizza", "meat Pizza", null, 10.99f, "small", null }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "EntityId", "Price" },
                values: new object[,]
                {
                    { 1L, 10.99f },
                    { 2L, 12.99f },
                    { 3L, 14.99f }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "EntityId", "Name" },
                values: new object[,]
                {
                    { 2L, "medium" },
                    { 3L, "large" },
                    { 1L, "small" }
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
                    { 2L, "grilled chicken" },
                    { 3L, "sauce" },
                    { 1L, "tomato" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "EntityId", "StoreEntityId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreEntityId",
                table: "Orders",
                column: "StoreEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderEntityId",
                table: "Pizzas",
                column: "OrderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_PizzaEntityId",
                table: "PizzaToppings",
                column: "PizzaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_ToppingEntityId",
                table: "PizzaToppings",
                column: "ToppingEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StoreEntityId",
                table: "Users",
                column: "StoreEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "PizzaToppings");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
