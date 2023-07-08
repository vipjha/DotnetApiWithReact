using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class BasketEntityAddedBasketId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_BasketId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_BasketId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "BasketItems");

            migrationBuilder.AddColumn<int>(
                name: "BasetBasketId",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BasketsId",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketsId",
                table: "BasketItems",
                column: "BasketsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_BasketsId",
                table: "BasketItems",
                column: "BasketsId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_BasketsId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_BasketsId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "BasetBasketId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "BasketsId",
                table: "BasketItems");

            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "BasketItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_BasketId",
                table: "BasketItems",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id");
        }
    }
}
