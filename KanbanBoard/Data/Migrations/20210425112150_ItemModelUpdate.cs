using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanBoard.Data.Migrations
{
    public partial class ItemModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsInfo_AspNetUsers_ResponsibleUser",
                table: "ItemsInfo");

            migrationBuilder.RenameColumn(
                name: "ResponsibleUser",
                table: "ItemsInfo",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsInfo_ResponsibleUser",
                table: "ItemsInfo",
                newName: "IX_ItemsInfo_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsInfo_AspNetUsers_UserId",
                table: "ItemsInfo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsInfo_AspNetUsers_UserId",
                table: "ItemsInfo");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ItemsInfo",
                newName: "ResponsibleUser");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsInfo_UserId",
                table: "ItemsInfo",
                newName: "IX_ItemsInfo_ResponsibleUser");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsInfo_AspNetUsers_ResponsibleUser",
                table: "ItemsInfo",
                column: "ResponsibleUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
