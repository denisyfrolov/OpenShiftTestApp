using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenShiftTestApp.Migrations
{
    public partial class TestDataCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SomeEntity",
                columns: new[] { "Title" },
                values: new object[] { "Test Entity Title!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SomeEntity",
                keyColumn: "Title",
                keyValue: "Test Entity Title!");
        }
    }
}
