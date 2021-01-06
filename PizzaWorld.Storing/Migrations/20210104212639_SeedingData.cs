using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Stores_StoreEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StoreEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StoreEntityId",
                table: "Users");

            migrationBuilder.AddColumn<long>(
                name: "SelectedStoreEntityId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserEntityId",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SelectedStoreEntityId",
                table: "Users",
                column: "SelectedStoreEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserEntityId",
                table: "Orders",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserEntityId",
                table: "Orders",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Stores_SelectedStoreEntityId",
                table: "Users",
                column: "SelectedStoreEntityId",
                principalTable: "Stores",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserEntityId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Stores_SelectedStoreEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SelectedStoreEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserEntityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SelectedStoreEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Orders");

            migrationBuilder.AddColumn<long>(
                name: "StoreEntityId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "EntityId",
                keyValue: 1L,
                column: "StoreEntityId",
                value: 1L);

            migrationBuilder.CreateIndex(
                name: "IX_Users_StoreEntityId",
                table: "Users",
                column: "StoreEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Stores_StoreEntityId",
                table: "Users",
                column: "StoreEntityId",
                principalTable: "Stores",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
