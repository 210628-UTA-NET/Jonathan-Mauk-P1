using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreAppData.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItems_Orders_OrdersId",
                table: "OrderLineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_StoreFronts_StoreFrontId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreLineItems_StoreFronts_StoreFrontId",
                table: "StoreLineItems");

            migrationBuilder.DropColumn(
                name: "FkId",
                table: "StoreLineItems");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FkId",
                table: "OrderLineItems");

            migrationBuilder.AlterColumn<int>(
                name: "StoreFrontId",
                table: "StoreLineItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StoreFrontId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOrdered",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "OrdersId",
                table: "OrderLineItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItems_Orders_OrdersId",
                table: "OrderLineItems",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_StoreFronts_StoreFrontId",
                table: "Orders",
                column: "StoreFrontId",
                principalTable: "StoreFronts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreLineItems_StoreFronts_StoreFrontId",
                table: "StoreLineItems",
                column: "StoreFrontId",
                principalTable: "StoreFronts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItems_Orders_OrdersId",
                table: "OrderLineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_StoreFronts_StoreFrontId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreLineItems_StoreFronts_StoreFrontId",
                table: "StoreLineItems");

            migrationBuilder.DropColumn(
                name: "DateOrdered",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "StoreFrontId",
                table: "StoreLineItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FkId",
                table: "StoreLineItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StoreFrontId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "OrdersId",
                table: "OrderLineItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FkId",
                table: "OrderLineItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItems_Orders_OrdersId",
                table: "OrderLineItems",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_StoreFronts_StoreFrontId",
                table: "Orders",
                column: "StoreFrontId",
                principalTable: "StoreFronts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreLineItems_StoreFronts_StoreFrontId",
                table: "StoreLineItems",
                column: "StoreFrontId",
                principalTable: "StoreFronts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
