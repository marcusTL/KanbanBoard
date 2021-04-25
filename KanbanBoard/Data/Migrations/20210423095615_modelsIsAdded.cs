using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanBoard.Data.Migrations
{
    public partial class modelsIsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    ResponsibleUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.ResponsibleUserId);
                });

            migrationBuilder.CreateTable(
                name: "ItemsInfo",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardState = table.Column<int>(type: "int", nullable: false),
                    ResponsibleUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsInfo", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ItemsInfo_UserInfo_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "UserInfo",
                        principalColumn: "ResponsibleUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsInfo_ResponsibleUserId",
                table: "ItemsInfo",
                column: "ResponsibleUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
