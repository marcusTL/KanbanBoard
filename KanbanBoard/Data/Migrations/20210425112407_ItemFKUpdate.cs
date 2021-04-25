using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanBoard.Data.Migrations
{
    public partial class ItemFKUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsInfo_AspNetUsers_UserId",
                table: "ItemsInfo");

            migrationBuilder.DropIndex(
                name: "IX_ItemsInfo_UserId",
                table: "ItemsInfo");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ItemsInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "ItemsInfo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsInfo_Id",
                table: "ItemsInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsInfo_AspNetUsers_Id",
                table: "ItemsInfo",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsInfo_AspNetUsers_Id",
                table: "ItemsInfo");

            migrationBuilder.DropIndex(
                name: "IX_ItemsInfo_Id",
                table: "ItemsInfo");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemsInfo");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ItemsInfo",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsInfo_UserId",
                table: "ItemsInfo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsInfo_AspNetUsers_UserId",
                table: "ItemsInfo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
