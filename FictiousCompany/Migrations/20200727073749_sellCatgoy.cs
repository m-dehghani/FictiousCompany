using Microsoft.EntityFrameworkCore.Migrations;

namespace FictiousCompany.Migrations
{
    public partial class sellCatgoy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Category_CategoryId",
                table: "CategoryProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SellProducts_Sell_SellId",
                table: "SellProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sell",
                table: "Sell");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Sell",
                newName: "Sells");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sells",
                table: "Sells",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Categories_CategoryId",
                table: "CategoryProduct",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellProducts_Sells_SellId",
                table: "SellProducts",
                column: "SellId",
                principalTable: "Sells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Categories_CategoryId",
                table: "CategoryProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SellProducts_Sells_SellId",
                table: "SellProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sells",
                table: "Sells");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Sells",
                newName: "Sell");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sell",
                table: "Sell",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Category_CategoryId",
                table: "CategoryProduct",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellProducts_Sell_SellId",
                table: "SellProducts",
                column: "SellId",
                principalTable: "Sell",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
