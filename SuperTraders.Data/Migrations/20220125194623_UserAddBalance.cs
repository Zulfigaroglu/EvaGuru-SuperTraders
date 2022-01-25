using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperTraders.Data.Migrations
{
    public partial class UserAddBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<float>(
                name: "Balance",
                table: "Users",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "Shares",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { "32750800-9460-4a0c-9fb5-487cb76a14ff", "DSA", "Dolor Sit Amer" },
                    { "4ca0cf43-3352-4202-ae9d-44310bcc8891", "CAE", "Consectetur Adipiscing Elit" },
                    { "cfcb3110-e01e-41f0-90b4-f89d395d6b30", "LIP", "Lorem Ipsum" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthToken", "Balance", "EMail", "IsEMailVerified", "Password", "UserName" },
                values: new object[,]
                {
                    { "7d61da45-725a-4dbe-8fb5-a5172f2aa481", "", 0f, "lorem@ipsum.com", false, "123456", "lorem" },
                    { "b8e7456f-4eee-4ced-96ac-bc3c6ef77c44", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiIiwibmJmIjoxNjQzMTM1NDU0LCJleHAiOjE2NDU3Mjc0NTQsImlhdCI6MTY0MzEzNTQ1NH0.jb-M5NOTieF1GDR1mHsc9YtFLKUB4uSjZVSfZbh-APg", 0f, "osman@zulfigaroglu.com", false, "123456", "osman" },
                    { "fad28c98-06fc-45b2-8678-ab6ba5faece3", "", 0f, "dolor@sitamet.com", false, "123456", "dolor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "32750800-9460-4a0c-9fb5-487cb76a14ff");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "4ca0cf43-3352-4202-ae9d-44310bcc8891");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "cfcb3110-e01e-41f0-90b4-f89d395d6b30");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d61da45-725a-4dbe-8fb5-a5172f2aa481");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b8e7456f-4eee-4ced-96ac-bc3c6ef77c44");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "fad28c98-06fc-45b2-8678-ab6ba5faece3");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Users");

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
        }
    }
}
