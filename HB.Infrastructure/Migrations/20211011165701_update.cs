using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HB.Infrastructure.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_Categories_Category_Id",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_Category_Id",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "Category_Id",
                table: "StockItems");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_CategoryId",
                table: "StockItems",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_Categories_CategoryId",
                table: "StockItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_Categories_CategoryId",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_CategoryId",
                table: "StockItems");

            migrationBuilder.AddColumn<Guid>(
                name: "Category_Id",
                table: "StockItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_Category_Id",
                table: "StockItems",
                column: "Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_Categories_Category_Id",
                table: "StockItems",
                column: "Category_Id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
