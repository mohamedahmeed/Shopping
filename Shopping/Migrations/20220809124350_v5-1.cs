using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping.Migrations
{
    public partial class v51 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_ShippingPrices_ShipPriceId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShipPriceId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShipPriceId",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShipPriceId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShipPriceId",
                table: "Order",
                column: "ShipPriceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ShippingPrices_ShipPriceId",
                table: "Order",
                column: "ShipPriceId",
                principalTable: "ShippingPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
