using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping.Migrations
{
    public partial class v23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Government",
                table: "Order");

            migrationBuilder.AddColumn<Guid>(
                name: "GovernmentId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Order_GovernmentId",
                table: "Order",
                column: "GovernmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_governments_GovernmentId",
                table: "Order",
                column: "GovernmentId",
                principalTable: "governments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_governments_GovernmentId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_GovernmentId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "GovernmentId",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "Government",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
