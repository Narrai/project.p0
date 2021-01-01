using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class UpdatingCrustSizeToppins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Crust",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "Topping",
                table: "Pizzas",
                newName: "Name");

            migrationBuilder.AddColumn<long>(
                name: "CrustEntityId",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SizeEntityId",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ToppingsEntityId",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrustId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaToppingsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PizzaToppingsEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Topping_Toppings_PizzaToppingsEntityId",
                        column: x => x.PizzaToppingsEntityId,
                        principalTable: "Toppings",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustEntityId",
                table: "Pizzas",
                column: "CrustEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeEntityId",
                table: "Pizzas",
                column: "SizeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_ToppingsEntityId",
                table: "Pizzas",
                column: "ToppingsEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Topping_PizzaToppingsEntityId",
                table: "Topping",
                column: "PizzaToppingsEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crusts_CrustEntityId",
                table: "Pizzas",
                column: "CrustEntityId",
                principalTable: "Crusts",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityId",
                table: "Pizzas",
                column: "SizeEntityId",
                principalTable: "Sizes",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Toppings_ToppingsEntityId",
                table: "Pizzas",
                column: "ToppingsEntityId",
                principalTable: "Toppings",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Crusts_CrustEntityId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Toppings_ToppingsEntityId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_CrustEntityId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_SizeEntityId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_ToppingsEntityId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "CrustEntityId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "SizeEntityId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "ToppingsEntityId",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pizzas",
                newName: "Topping");

            migrationBuilder.AddColumn<int>(
                name: "Crust",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Pizzas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
