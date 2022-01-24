using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperTraders.Data.Migrations
{
    public partial class Share : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Share",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Share", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserShare",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ShareId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserShare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserShare_Share_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Share",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserShare_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserShare_ShareId",
                table: "UserShare",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_UserShare_UserId",
                table: "UserShare",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserShare");

            migrationBuilder.DropTable(
                name: "Share");
        }
    }
}
