using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProductWeight",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Order");

            migrationBuilder.AddColumn<Guid>(
                name: "ShippingPriceId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShippingTypesId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductWeight = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingPrice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromWeight = table.Column<int>(type: "int", nullable: false),
                    ToWeight = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    extraPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingPriceId",
                table: "Order",
                column: "ShippingPriceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingTypesId",
                table: "Order",
                column: "ShippingTypesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderId",
                table: "Product",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ShippingPrice_ShippingPriceId",
                table: "Order",
                column: "ShippingPriceId",
                principalTable: "ShippingPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ShippingTypes_ShippingTypesId",
                table: "Order",
                column: "ShippingTypesId",
                principalTable: "ShippingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_ShippingPrice_ShippingPriceId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_ShippingTypes_ShippingTypesId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ShippingPrice");

            migrationBuilder.DropTable(
                name: "ShippingTypes");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShippingPriceId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShippingTypesId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingPriceId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingTypesId",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductWeight",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
