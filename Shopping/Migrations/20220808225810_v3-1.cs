using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping.Migrations
{
    public partial class v31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_governments_GovernmentId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_ShippingPrice_ShippingPriceId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Order_OrderId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShippingPriceId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingPrice",
                table: "ShippingPrice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ShippingType",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "paymentType",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "ShippingPrice",
                newName: "ShippingPrices");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "products");

            migrationBuilder.RenameColumn(
                name: "ShippingPriceId",
                table: "Order",
                newName: "cityId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_OrderId",
                table: "products",
                newName: "IX_products_OrderId");

            migrationBuilder.AlterColumn<Guid>(
                name: "GovernmentId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ShipPriceId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Tovillage",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingPrices",
                table: "ShippingPrices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_cityId",
                table: "Order",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShipPriceId",
                table: "Order",
                column: "ShipPriceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_cities_cityId",
                table: "Order",
                column: "cityId",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_governments_GovernmentId",
                table: "Order",
                column: "GovernmentId",
                principalTable: "governments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ShippingPrices_ShipPriceId",
                table: "Order",
                column: "ShipPriceId",
                principalTable: "ShippingPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_Order_OrderId",
                table: "products",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_cities_cityId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_governments_GovernmentId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_ShippingPrices_ShipPriceId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_products_Order_OrderId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_Order_cityId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShipPriceId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingPrices",
                table: "ShippingPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ShipPriceId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Tovillage",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "ShippingPrices",
                newName: "ShippingPrice");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "cityId",
                table: "Order",
                newName: "ShippingPriceId");

            migrationBuilder.RenameIndex(
                name: "IX_products_OrderId",
                table: "Product",
                newName: "IX_Product_OrderId");

            migrationBuilder.AlterColumn<Guid>(
                name: "GovernmentId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingType",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "paymentType",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingPrice",
                table: "ShippingPrice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingPriceId",
                table: "Order",
                column: "ShippingPriceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_governments_GovernmentId",
                table: "Order",
                column: "GovernmentId",
                principalTable: "governments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ShippingPrice_ShippingPriceId",
                table: "Order",
                column: "ShippingPriceId",
                principalTable: "ShippingPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Order_OrderId",
                table: "Product",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
