using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanBoard.Data.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsInfo_UserInfo_ResponsibleUserId",
                table: "ItemsInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_ItemsInfo_ResponsibleUserId",
                table: "ItemsInfo");

            migrationBuilder.DropColumn(
                name: "ResponsibleUserId",
                table: "ItemsInfo");

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleUser",
                table: "ItemsInfo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsInfo_ResponsibleUser",
                table: "ItemsInfo",
                column: "ResponsibleUser");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsInfo_AspNetUsers_ResponsibleUser",
                table: "ItemsInfo",
                column: "ResponsibleUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsInfo_AspNetUsers_ResponsibleUser",
                table: "ItemsInfo");

            migrationBuilder.DropIndex(
                name: "IX_ItemsInfo_ResponsibleUser",
                table: "ItemsInfo");

            migrationBuilder.DropColumn(
                name: "ResponsibleUser",
                table: "ItemsInfo");

            migrationBuilder.AddColumn<int>(
                name: "ResponsibleUserId",
                table: "ItemsInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    ResponsibleUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.ResponsibleUserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsInfo_ResponsibleUserId",
                table: "ItemsInfo",
                column: "ResponsibleUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsInfo_UserInfo_ResponsibleUserId",
                table: "ItemsInfo",
                column: "ResponsibleUserId",
                principalTable: "UserInfo",
                principalColumn: "ResponsibleUserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
