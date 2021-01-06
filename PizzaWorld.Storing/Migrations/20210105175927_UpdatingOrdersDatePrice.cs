using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class UpdatingOrdersDatePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SelectedOrderEntityId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "Orders",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SelectedOrderEntityId",
                table: "Users",
                column: "SelectedOrderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Orders_SelectedOrderEntityId",
                table: "Users",
                column: "SelectedOrderEntityId",
                principalTable: "Orders",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Orders_SelectedOrderEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SelectedOrderEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SelectedOrderEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");
        }
    }
}
