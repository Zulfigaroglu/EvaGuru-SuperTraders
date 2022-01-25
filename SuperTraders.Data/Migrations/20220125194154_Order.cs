using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperTraders.Data.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserShare_Share_ShareId",
                table: "UserShare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Share",
                table: "Share");

            migrationBuilder.RenameTable(
                name: "Share",
                newName: "Shares");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "UserShare",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shares",
                table: "Shares",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BuyOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UnitPrice = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    RemainingAmount = table.Column<int>(type: "integer", nullable: false),
                    IsTransactionPerformed = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ShareId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyOrders_Shares_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Shares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UnitPrice = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    RemainingAmount = table.Column<int>(type: "integer", nullable: false),
                    IsTransactionPerformed = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ShareId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellOrders_Shares_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Shares",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.NoAction,
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.NoAction,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    SellOrderId = table.Column<string>(type: "text", nullable: false),
                    BuyOrderId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_BuyOrders_BuyOrderId",
                        column: x => x.BuyOrderId,
                        principalTable: "BuyOrders",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.NoAction,
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_SellOrders_SellOrderId",
                        column: x => x.SellOrderId,
                        principalTable: "SellOrders",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.NoAction,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shares",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { "7ec214a8-252e-4b5b-96d9-bff6bc87caae", "DSA", "Dolor Sit Amer" },
                    { "8d238de0-1f08-4fc0-b49d-febdea62dc67", "LIP", "Lorem Ipsum" },
                    { "b1e7f7ca-5353-4071-a308-09fcca0efe94", "CAE", "Consectetur Adipiscing Elit" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthToken", "EMail", "IsEMailVerified", "Password", "UserName" },
                values: new object[,]
                {
                    { "10e5b64b-6584-41d3-b559-15303e09dff3", "", "dolor@sitamet.com", false, "123456", "dolor" },
                    { "6027a78b-5feb-489e-94ca-615c5434bfa0", "", "lorem@ipsum.com", false, "123456", "lorem" },
                    { "d697322e-bc77-4c3f-ad29-0388b5949b06", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiIiwibmJmIjoxNjQzMTM1NDU0LCJleHAiOjE2NDU3Mjc0NTQsImlhdCI6MTY0MzEzNTQ1NH0.jb-M5NOTieF1GDR1mHsc9YtFLKUB4uSjZVSfZbh-APg", "osman@zulfigaroglu.com", false, "123456", "osman" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyOrders_ShareId",
                table: "BuyOrders",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyOrders_UserId",
                table: "BuyOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SellOrders_ShareId",
                table: "SellOrders",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_SellOrders_UserId",
                table: "SellOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BuyOrderId",
                table: "Transactions",
                column: "BuyOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SellOrderId",
                table: "Transactions",
                column: "SellOrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserShare_Shares_ShareId",
                table: "UserShare",
                column: "ShareId",
                principalTable: "Shares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserShare_Shares_ShareId",
                table: "UserShare");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "BuyOrders");

            migrationBuilder.DropTable(
                name: "SellOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shares",
                table: "Shares");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "7ec214a8-252e-4b5b-96d9-bff6bc87caae");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "8d238de0-1f08-4fc0-b49d-febdea62dc67");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "b1e7f7ca-5353-4071-a308-09fcca0efe94");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10e5b64b-6584-41d3-b559-15303e09dff3");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6027a78b-5feb-489e-94ca-615c5434bfa0");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "d697322e-bc77-4c3f-ad29-0388b5949b06");

            migrationBuilder.RenameTable(
                name: "Shares",
                newName: "Share");

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "UserShare",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Share",
                table: "Share",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserShare_Share_ShareId",
                table: "UserShare",
                column: "ShareId",
                principalTable: "Share",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
