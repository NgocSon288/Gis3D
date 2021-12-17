using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class AddAnotherColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Name" },
                values: new object[] { 18, "anotherColor" });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsNumber", "Name" },
                values: new object[] { 19, true, "offset" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 19);
        }
    }
}
