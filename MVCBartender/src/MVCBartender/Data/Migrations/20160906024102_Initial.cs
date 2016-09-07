using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCBartender.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkOrder_drinkInv_drinkInvID",
                table: "DrinkOrder");

            migrationBuilder.DropIndex(
                name: "IX_DrinkOrder_drinkInvID",
                table: "DrinkOrder");

            migrationBuilder.DropColumn(
                name: "DrinkID",
                table: "DrinkOrder");

            migrationBuilder.DropColumn(
                name: "drinkInvID",
                table: "DrinkOrder");

            migrationBuilder.CreateTable(
                name: "drinkOrd",
                columns: table => new
                {
                    drinkOrdID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<int>(nullable: false),
                    drinkQuant = table.Column<int>(nullable: false),
                    orderComplete = table.Column<bool>(nullable: true),
                    totalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drinkOrd", x => x.drinkOrdID);
                    table.ForeignKey(
                        name: "FK_drinkOrd_drinkInv_Id",
                        column: x => x.Id,
                        principalTable: "drinkInv",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_drinkOrd_Id",
                table: "drinkOrd",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drinkOrd");

            migrationBuilder.AddColumn<int>(
                name: "DrinkID",
                table: "DrinkOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "drinkInvID",
                table: "DrinkOrder",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DrinkOrder_drinkInvID",
                table: "DrinkOrder",
                column: "drinkInvID");

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkOrder_drinkInv_drinkInvID",
                table: "DrinkOrder",
                column: "drinkInvID",
                principalTable: "drinkInv",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
